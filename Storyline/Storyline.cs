using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Storyline.Story;

namespace Storyline
{
    internal class Storyline
    {
        private readonly Row _row;

        public Storyline(Row row)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            _row = row;
        }

        private void FitSize(int width)
        {
            var borders = new SizeF(width, width);

            var olddiff = float.MaxValue;
            var done = false;
            while (!done)
            {
                var diff = _row.Iterate(borders);
                var progress = Math.Abs(diff - olddiff);
                if (progress < 0.00001)
                    done = true;
                olddiff = diff;
            }
        }

        public Bitmap GetImage(int width, bool drawDebugInfo = false)
        {
            FitSize(width);

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
