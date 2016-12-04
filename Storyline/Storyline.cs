using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Storyline.Story;

namespace Storyline
{
    internal class Storyline
    {
        private readonly Row _row;

        public bool IsPaddingReduced { get; private set; }

        public Storyline(Row row)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            _row = row;
        }

        private float MakeBestFit(int width)
        {
            var borders = new SizeF(width, width);

            var olderror = float.MaxValue;
            var done = false;
            while (!done)
            {
                var error = _row.Iterate(borders);
                var diff = Math.Abs(error - olderror);
                if (diff < 0.00001)
                    done = true;
                olderror = error;
            }

            return olderror;
        }

        private void FitImages(int width)
        {
            IsPaddingReduced = false;
            _row.ResetPaddingScaling();

            var error = MakeBestFit(width);

            while (error > 0.001)
            {
                IsPaddingReduced = true;
                _row.ScalePadding(0.95f);
                error = MakeBestFit(width);
            }
        }

        public Bitmap GetImage(int width, bool drawDebugInfo = false)
        {
            FitImages(width);

            var drawTargets = _row.GetDrawTargets();

            var bgRect = new RectangleF();
            foreach (var target in drawTargets)
            {
                bgRect.X = Math.Min(bgRect.X, target.Location.X);
                bgRect.Y = Math.Min(bgRect.Y, target.Location.Y);
                bgRect.Width = Math.Max(bgRect.Width, (target.Location + target.GetSize()).X);
                bgRect.Height = Math.Max(bgRect.Height, (target.Location + target.GetSize()).Y);
            }

            var bitmap = new Bitmap((int)Math.Ceiling(bgRect.Width), (int)Math.Ceiling(bgRect.Height));

            var g = Graphics.FromImage(bitmap);

            g.FillRectangle(Brushes.Black, bgRect);

            foreach (var item in drawTargets)
            {
                var imageRectangle = item.GetImageRectangle();
                if (imageRectangle.Width > 0 && imageRectangle.Height > 0)
                    g.DrawImage(item.ImageWrapper.Image, imageRectangle);

                if (drawDebugInfo)
                {
                    var rect = new RectangleF(item.Location, item.ImageWrapper.Size);
                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        var pen = new Pen(Color.FromArgb(128, 255, 255, 255)) { DashStyle = DashStyle.Dash };
                        g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }

            return bitmap;
        }
    }
}
