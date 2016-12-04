using System;
using System.Drawing;

namespace Storyline
{
    /// <summary>
    /// Хранит значения отступов
    /// </summary>
    public struct Padding
    {
        public readonly float Top;
        public readonly float Bottom;

        public readonly float Left;
        public readonly float Right;

        public Padding(float left, float right, float top, float bottom)
        {
            if (left < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(left), left, "Must be non-negative value");
            }

            if (right < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(right), right, "Must be non-negative value");
            }
            if (top < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(top), top, "Must be non-negative value");
            }
            if (bottom < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bottom), bottom, "Must be non-negative value");
            }

            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public Padding(float horizontal, float vertical)
            : this(horizontal, horizontal, vertical, vertical)
        {
        }

        public Padding(float size)
            : this(size, size, size, size)
        {
        }

        public override string ToString()
        {
            return $"{nameof(Top)}: {Top}, {nameof(Bottom)}: {Bottom}, {nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }

        public SizeF Size => new SizeF(Left + Right, Top + Bottom);

        public Padding Scaled(float factor)
        {
            return new Padding(Left * factor, Right * factor, Top * factor, Bottom * factor);
        }
    }
}