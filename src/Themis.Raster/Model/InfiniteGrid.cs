using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class InfiniteGrid<T> : IInfiniteGrid<T>
    {
        public bool Contains(double x)
        {
            throw new NotImplementedException();
        }

        public bool Contains(double x, double y)
        {
            throw new NotImplementedException();
        }

        public T Get(double x, double y)
        {
            throw new NotImplementedException();
        }

        public T Get(long xIdx, long yIdx)
        {
            throw new NotImplementedException();
        }
    }
}
