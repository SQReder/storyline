using System.Drawing;

namespace Storyline.Extensions
{
    public static class SizeExtensions
    {
        public static SizeF Multiply(this SizeF size, float factor)
        {
            return new SizeF(size.Width * factor, size.Height * factor);
        }

        public static SizeF Multiply(this Size size, float factor)
        {
            return new SizeF(size.Width * factor, size.Height * factor);
        }
    }
}