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
        /// <returns>Неотрицательная суммарная оценка ошибки оценки расположений ячеек</returns>
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

        /// <summary>
        /// Сбрасывает масштабирование отступов
        /// </summary>
        void ResetPaddingScaling();

        /// <summary>
        /// Позволяет изменить масштабирование отступов
        /// </summary>
        /// <param name="factor">Коэффицент масштабирования размер отступов</param>
        void ScalePadding(float factor);
    }
}