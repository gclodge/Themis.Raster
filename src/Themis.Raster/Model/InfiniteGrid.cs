using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class InfiniteGrid<T> : IInfiniteGrid<T>
    {
        public double CellSize { get; } = double.NaN;

        readonly Dictionary<long, Dictionary<long, T>> map;

        public InfiniteGrid(double cellSize)
        {
            this.CellSize = cellSize;
            this.map = new();
        }

        public IInfiniteGrid<T> Add(T value, long xIdx, long yIdx)
        {
            throw new NotImplementedException();
        }

        public IInfiniteGrid<T> Add(T value, double x, double y)
        {
            long xIdx = x.ToGridIndex(CellSize);
            long yIdx = y.ToGridIndex(CellSize);

            return Add(value, xIdx, yIdx);
        }

        public IInfiniteGrid<T> Add(T value, IEnumerable<double> pos)
        {
            if (pos.Count() < 2) throw new ArgumentException($"Position must be at least 2D", nameof(pos));

            return Add(value, pos.ElementAt(0), pos.ElementAt(1));
        }

        public IInfiniteGrid<T> Remove(long xIdx, long yIdx)
        {
            if (!Contains(xIdx, yIdx)) return this;

            //< Remove the item at the cell [xidx,yidx]
            map[xIdx].Remove(yIdx);
            //< If we only have one value for the x-index, remove it as well
            if (map[xIdx].Values.Count == 1) map.Remove(xIdx);

            return this;
        }

        public IInfiniteGrid<T> Remove(double x, double y)
        {
            long xIdx = x.ToGridIndex(CellSize);
            long yIdx = y.ToGridIndex(CellSize);

            return Remove(xIdx, yIdx);
        }

        public T Get(double x, double y)
        {
            long xIdx = x.ToGridIndex(CellSize);
            long yIdx = y.ToGridIndex(CellSize);

            return Get(xIdx, yIdx);
        }

        public T Get(long xIdx, long yIdx)
        {
            if (!Contains(xIdx, yIdx)) throw new IndexOutOfRangeException($"InfiniteGrid does not contain item for indices: [{xIdx},{yIdx}]");

            return map[xIdx][yIdx];
        }

        public bool Contains(long xIdx)
        {
            return map.ContainsKey(xIdx);
        }

        public bool Contains(long xIdx, long yIdx)
        {
            if (!map.ContainsKey(xIdx)) return false;

            return map[xIdx].ContainsKey(yIdx);
        }

        public bool Contains(double x)
        {
            long idx = x.ToGridIndex(CellSize);
            return Contains(idx);
        }

        public bool Contains(double x, double y)
        {
            long xIdx = x.ToGridIndex(CellSize);
            long yIdx = y.ToGridIndex(CellSize);
            return Contains(xIdx, yIdx);
        }
    }
}
