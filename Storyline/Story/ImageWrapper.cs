using System;
using System.Drawing;
using Storyline.Extensions;

namespace Storyline.Story
{
    internal class ImageWrapper : IStoryItem
    {
        public Image Image { get; }
        public Padding Padding { get; }
        private readonly float _iterationScale;
        public float Scale { get; private set; } = 1;

        public SizeF ImageSize => Image.Size.Multiply(Scale);
        public SizeF Size => Image.Size.Multiply(Scale) + Padding.Size;

        public ImageWrapper(Image image, Padding padding = default(Padding))
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            Image = image;
            Padding = padding;
            _iterationScale = 10f / Math.Max(Image.Width, Image.Height);
        }

        public DrawTarget[] GetDrawTargets()
        {
            var drawTarget = new DrawTarget
            {
                ImageWrapper = this,
            };

            return new[] { drawTarget };
        }

        public float Iterate(SizeF targetSize)
        {
            var errW = targetSize.Width - Size.Width;
            var errH = targetSize.Height - Size.Height;

            var uW = 0.1f * errW;
            var uH = 0.1f * errH;

            var u = uW + uH;

            Scale += u * _iterationScale;

            if (Scale < 0) Scale = 0;
            if (Scale > 100) Scale = 100;

            return Math.Abs(u);
        }

        public void Prepare(SizeF targetSize)
        {
            if (targetSize.Width < targetSize.Height)
            {
                Scale = targetSize.Width / Size.Width;
            }
            else
            {
                Scale = targetSize.Height / Size.Height;
            }
        }

        public bool Prepared => true;
    }
}