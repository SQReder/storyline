using System;
using System.Drawing;

namespace Storyline
{
    /// <summary>
    /// Хранит значения отступов
    /// </summary>
    public struct Padding
    {
        public readonly int Top;
        public readonly int Bottom;

        public readonly int Left;
        public readonly int Right;

        public Padding(int left, int right, int top, int bottom)
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

        public Padding(int horizontal, int vertical)
            : this(horizontal, horizontal, vertical, vertical)
        {
        }

        public Padding(int size)
            : this(size, size, size, size)
        {
        }

        public override string ToString()
        {
            return $"{nameof(Top)}: {Top}, {nameof(Bottom)}: {Bottom}, {nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }

        public SizeF Size => new SizeF(Left + Right, Top + Bottom);
    }
}