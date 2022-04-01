using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class RasterCell<T> : IRasterCell<T>
    {
        public T Value { get; set; }

        public long XIndex { get; set; }
        public long YIndex { get; set; }

        public double CellSize { get; set; } = double.NaN;

        public RasterCell(T value, double cellSize)
        {
            this.Value = value;
            this.CellSize = cellSize;
        }

        #region Fluent Interface
        public IRasterCell<T> SetCellSize(double cellSize)
        {
            if (cellSize < 0) throw new ArgumentException($"CellSize must be a non-zero, positive decimal value", nameof(cellSize));

            this.CellSize = cellSize;
            return this;
        }

        public IRasterCell<T> SetValue(T value)
        {
            this.Value = value;
            return this;
        }

        public IRasterCell<T> SetXIndex(long xIndex)
        {
            this.XIndex = xIndex;
            return this;
        }

        public IRasterCell<T> SetYIndex(long yIndex)
        {
            this.YIndex = yIndex;
            return this;
        }

        public IRasterCell<T> SetIndices(long xIndex, long yIndex)
        {
            this.XIndex = xIndex;
            this.YIndex = yIndex;
            return this;
        }
        #endregion

        #region Static Members
        public static IRasterCell<T> Generate(T value, double cellSize)
        {
            return new RasterCell<T>(value, cellSize);
        }

        public static IRasterCell<T> Generate(T value, double cellSize, IEnumerable<double> pos)
        {
            if (pos.Count() < 2) throw new ArgumentException($"Position must be at least 2D", nameof(pos));

            return Generate(value, cellSize, pos.ElementAt(0), pos.ElementAt(1));
        }

        public static IRasterCell<T> Generate(T value, double cellSize, double xPos, double yPos)
        {
            long xIdx = xPos.ToGridIndex(cellSize);
            long yIdx = yPos.ToGridIndex(cellSize);

            return Generate(value, cellSize).SetIndices(xIdx, yIdx);
        }
        #endregion
    }
}
