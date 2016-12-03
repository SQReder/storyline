using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Storyline.Story
{
    internal class Row : StoryItem
    {
        public override SizeF Size
        {
            get
            {
                var width = Sizeables.Sum(x => x.Size.Width);
                var height = Sizeables.Max(x => x.Size.Height);
                return new SizeF(width, height);
            }
        }


        protected override SizeF SizeFromAveragingAndFitting(float averaging, float fitting)
        {
            return new SizeF(fitting, averaging);
        }

        protected override PointF MoveOffsetPoint(PointF location, IStoryItem sizeable)
        {
            return new PointF(location.X + sizeable.Size.Width, 0);
        }

        protected override float FittingDimension(SizeF size) => size.Width;
        protected override float AveragingDimension(SizeF size) => size.Height;
    }
}