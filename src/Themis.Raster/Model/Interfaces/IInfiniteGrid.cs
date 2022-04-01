namespace Themis.Raster.Model.Interfaces
{
    public interface IInfiniteGrid<T>
    {
        double CellSize { get; }

        IInfiniteGrid<T> Add(T value, long xIdx, long yIdx);
        IInfiniteGrid<T> Add(T value, double x, double y);
        IInfiniteGrid<T> Add(T value, IEnumerable<double> pos);
        IInfiniteGrid<T> Remove(double x, double y);
        IInfiniteGrid<T> Remove(long xIdx, long yIdx);

        T Get(double x, double y);
        T Get(long xIdx, long yIdx);

        bool Contains(long xIdx);
        bool Contains(long xIdx, long yIdx);
        bool Contains(double x);
        bool Contains(double x, double y);
    }
}
