using System.Drawing;

namespace Storyline.Story
{
    /// <summary>
    /// Описывает интерфейс объекта сторилайна
    /// </summary>
    internal interface IStoryItem
    {
        /// <summary>
        /// Производит одну итерацию линейного приближения расположения ячеек в наборе
        /// </summary>
        /// <param name="targetSize">Размер в который необходимо вписаться</param>
        /// <returns>Неотрицательная количественная оценка изменений расположений ячеек за итерацию</returns>
        float Iterate(SizeF targetSize);

        /// <summary>
        /// Производит предварительное усреднение размеров ячеек
        /// </summary>
        /// <param name="targetSize">Размер в который небходимо ввписаться</param>
        void Prepare(SizeF targetSize);

        /// <summary>
        /// Размер прямоугольника, ограничивающего ячейки на плоскости
        /// </summary>
        SizeF Size { get; }

        /// <summary>
        /// Позволяет получить набор объектов для отрисовки
        /// </summary>
        /// <returns>Набор объектов для отрисовки</returns>
        DrawTarget[] GetDrawTargets();
    }
}