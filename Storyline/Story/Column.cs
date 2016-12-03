using System.Drawing;
using System.Linq;

namespace Storyline.Story
{
    internal class Column : StoryItem
    {

        public override SizeF Size
        {
            get
            {
                var width = Sizeables.Max(x => x.Size.Width);
                var height = Sizeables.Sum(x => x.Size.Height);
                return new SizeF(width, height);
            }
        }

        protected override SizeF SizeFromAveragingAndFitting(float averaging, float fitting)
        {
            return new SizeF(averaging, fitting);
        }

        protected override PointF MoveOffsetPoint(PointF location, IStoryItem sizeable)
        {
            return new PointF(0, location.Y + sizeable.Size.Height);
        }

        protected override float FittingDimension(SizeF size) => size.Height;
        protected override float AveragingDimension(SizeF size) => size.Width;
    }
}