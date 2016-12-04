using System;
using System.Drawing;
using Storyline.Extensions;

namespace Storyline.Story
{
    internal class ImageWrapper : IStoryItem
    {
        public Image Image { get; }

        private float _imageScale = 1;
        public SizeF ImageSize => Image.Size.Multiply(_imageScale);
        public SizeF Size => Image.Size.Multiply(_imageScale) + Padding.Size;

        private float _paddingScale = 1;
        private readonly Padding _padding;
        public Padding Padding => _padding.Scaled(_paddingScale);

        private readonly float _iterationScale;

        public ImageWrapper(Image image, Padding padding = default(Padding))
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            Image = image;
            _padding = padding;
            _iterationScale = 10f / Math.Max(Image.Width, Image.Height);
        }

        public DrawTarget[] GetDrawTargets()
        {
            var drawTarget = new DrawTarget
            {
                ImageWrapper = this,
            };

            return new[] {drawTarget};
        }

        public float Iterate(SizeF targetSize)
        {
            var errW = targetSize.Width - Size.Width;
            var errH = targetSize.Height - Size.Height;

            var uW = 0.1f * errW;
            var uH = 0.1f * errH;

            var u = uW + uH;

            _imageScale += u * _iterationScale;

            if (_imageScale < 0) _imageScale = 0;
            if (_imageScale > 100) _imageScale = 100;

            return Math.Abs(u);
        }

        public void Prepare(SizeF targetSize)
        {
            if (targetSize.Width < targetSize.Height)
            {
                _imageScale = targetSize.Width / Size.Width;
            }
            else
            {
                _imageScale = targetSize.Height / Size.Height;
            }
        }

        public void ResetPaddingScaling()
        {
            _paddingScale = 1f;
        }

        public void ScalePadding(float factor)
        {
            _paddingScale *= factor;
        }
    }
}