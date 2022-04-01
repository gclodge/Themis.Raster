namespace Themis.Raster.Model.Interfaces
{
    public interface IRasterCell<T>
    {
        T? Value { get; }

        public long XIndex { get; }
        public long YIndex { get; }

        public double CellSize { get; }

        IRasterCell<T> SetValue(T value);
        IRasterCell<T> SetXIndex(long xIndex);
        IRasterCell<T> SetYIndex(long yIndex);
        IRasterCell<T> SetCellSize(double cellSize);
    }
}
