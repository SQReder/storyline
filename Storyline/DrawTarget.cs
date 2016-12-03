using System.Drawing;
using Storyline.Story;

namespace Storyline
{
    internal class DrawTarget
    {
        public ImageWrapper ImageWrapper { get; set; }

        public PointF Location { get; set; }

        public SizeF GetSize()
        {
            return ImageWrapper.Size;
        }

        public RectangleF GetImageRectangle()
        {
            return new RectangleF(new PointF(Location.X + ImageWrapper.Padding.Left, Location.Y + ImageWrapper.Padding.Top), ImageWrapper.ImageSize);
        }
    }
}