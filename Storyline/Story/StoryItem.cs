using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Storyline.Story
{
    internal abstract class StoryItem: IStoryItem, IStoryContainer
    {
        protected readonly List<IStoryItem> Sizeables = new List<IStoryItem>();
        private bool _prepared;

        /// <summary>
        ///  Добавляет ячейку в набор для расположения
        /// </summary>
        /// <param name="wrapper"></param>
        public void Add(IStoryItem wrapper)
        {
            Sizeables.Add(wrapper);
        }

        public float Iterate(SizeF targetSize)
        {
            Prepare(targetSize);

            var fittingError = GetFittingDimensionError(targetSize);

            var averageSize = GetAveragingDimensionSize();

            var difference = 0f;

            foreach (var item in Sizeables)
            {
                var averaging = AveragingDimension(item.Size);
                var fitting = FittingDimension(item.Size);

                var averagingError = averageSize - averaging;

                difference += item.Iterate(SizeFromAveragingAndFitting(averaging + averagingError, fitting + fittingError));
            }

            return Math.Abs(difference);
        }

        /// <summary>
        /// Создает объект размера по значениям усредняемого и вписываемого направлений
        /// </summary>
        /// <param name="averaging">Величина по направлению усреднения размера</param>
        /// <param name="fitting">Величина по направлению вписывания размера</param>
        /// <returns>Размер</returns>
        protected abstract SizeF SizeFromAveragingAndFitting(float averaging, float fitting);

        public DrawTarget[] GetDrawTargets()
        {
            var drawTargets = new List<DrawTarget>();

            var location = new PointF();

            foreach (var sizeable in Sizeables)
            {
                var targets = sizeable.GetDrawTargets();
                foreach (var target in targets)
                {
                    target.Location = new PointF(location.X + target.Location.X, location.Y + target.Location.Y);
                }
                drawTargets.AddRange(targets);
                location = MoveOffsetPoint(location, sizeable);
            }

            return drawTargets.ToArray();
        }

        /// <summary>
        /// Возвращает наибольший размер ячейки по стороне которая выравниваеися
        /// Дл строки наименьшая высота, для колонки наименьшая ширина
        /// </summary>
        /// <returns>Наибольший размер выравниваемой стороны</returns>
        private float GetAveragingDimensionSize()
        {
            return Sizeables.Average(i => AveragingDimension(i.Size));
        }

        /// <summary>
        /// Позволяет получить среднее отклонение размера ячейки по стороне которая вписывается
        /// Для строки отклонение ширины, для колонки отклонение высоты.
        /// </summary>
        /// <param name="targetSize">Размеры в которые должнен вписаться набор ячеек</param>
        /// <returns>Среднее отклонение от усредненного размера ячейки</returns>
        private float GetFittingDimensionError(SizeF targetSize)
        {
            var summary = Sizeables.Select(i => FittingDimension(i.Size)).Sum();

            var averageError = (FittingDimension(targetSize) - summary) / Sizeables.Count;

            return averageError;
        }

        /// <summary>
        /// Перемещает опорную точку для расположения ячеек в наборе
        /// </summary>
        /// <param name="location">Текущее положение опорной точки</param>
        /// <param name="sizeable">Значение на которое нужно переместить точку</param>
        /// <returns>Точка смещенная согласно ориентации набора ячеек</returns>
        protected abstract PointF MoveOffsetPoint(PointF location, IStoryItem sizeable);

        public void Prepare(SizeF targetSize)
        {
            if (_prepared) return;

            var minAveragingSize = Sizeables.Select(x => AveragingDimension(x.Size)).Min();

            foreach (var sizeable in Sizeables)
            {
                var size = SizeFromAveragingAndFitting(minAveragingSize, FittingDimension(sizeable.Size) * minAveragingSize / AveragingDimension(sizeable.Size));
                sizeable.Prepare(size);
            }

            _prepared = true;
        }

        /// <summary>
        /// Позволяет получить размер по вписываемому направлению
        /// </summary>
        /// <param name="size">Размер</param>
        /// <returns>Величина по вписываемому направлению</returns>
        protected abstract float FittingDimension(SizeF size);

        /// <summary>
        /// Позволяет получить размер по усредняемому направлению
        /// </summary>
        /// <param name="size">Размер ячейки</param>
        /// <returns>Величина по усредняемому направлению</returns>
        protected abstract float AveragingDimension(SizeF size);

        public abstract SizeF Size { get; }

        public void ScalePadding(float factor)
        {
            foreach (var storyItem in Sizeables)
            {
                storyItem.ScalePadding(factor);
            }
        }

        public void ResetPaddingScaling()
        {
            foreach (var storyItem in Sizeables)
            {
                storyItem.ResetPaddingScaling();
            }
        }
    }
}