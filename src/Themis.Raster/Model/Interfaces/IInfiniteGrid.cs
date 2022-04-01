namespace Themis.Raster.Model.Interfaces
{
    public interface IInfiniteGrid<T>
    {
        T Get(double x, double y);
        T Get(long xIdx, long yIdx);

        bool Contains(double x);
        bool Contains(double x, double y);
    }
}
