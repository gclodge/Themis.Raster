using Themis.Geometry.Boundary;

using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class Raster<T> : IRaster<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public double PixelSize { get; private set; }

        public double MinX => BoundingBox.MinX;
        public double MinY => BoundingBox.MinY;
        public double MinZ => BoundingBox.MaxZ;
        public double MaxX => BoundingBox.MaxX;
        public double MaxY => BoundingBox.MaxY;
        public double MaxZ => BoundingBox.MaxZ;

        public BoundingBox BoundingBox { get; private set; }

        private readonly IInfiniteGrid<T> grid;

        public Raster(int width, int height, double pixelSize)
        {
            this.Width = width;
            this.Height = height;
            this.PixelSize = pixelSize;

            this.BoundingBox = new BoundingBox();
            this.grid = new InfiniteGrid<T>(pixelSize);
        }

        public IRaster<T> Add(T value, long xIdx, long yIdx)
        {
            grid.Add(value, xIdx, yIdx);
            return this;
        }

        public IRaster<T> Add(T value, double x, double y)
        {
            grid.Add(value, x, y);
            return this;
        }

        public IRaster<T> Add(T value, IEnumerable<double> pos)
        {
            grid.Add(value, pos);
            return this;
        }

        public IRaster<T> Remove(double x, double y)
        {
            grid.Remove(x, y);
            return this;
        }

        public IRaster<T> Remove(long xIdx, long yIdx)
        {
            grid.Remove(xIdx, yIdx);
            return this;
        }

        public bool TryGetValue(double x, double y, out T? value)
        {
            value = default;
            if (!grid.Contains(x, y)) return false;

            value = grid.Get(x, y);
            return true;
        }

        public void AdjustExtrema(IEnumerable<double> pos)
        {
            if (pos.Count() < 2) throw new ArgumentException($"Position must be at least 2D", nameof(pos));

            BoundingBox.MinX = Math.Min(BoundingBox.MinX, pos.ElementAt(0));
            BoundingBox.MinY = Math.Min(BoundingBox.MinY, pos.ElementAt(1));
            BoundingBox.MinZ = pos.Count() > 2 ? Math.Min(BoundingBox.MinZ, pos.ElementAt(2)) : double.NaN;

            BoundingBox.MaxX = Math.Max(BoundingBox.MaxX, pos.ElementAt(0));
            BoundingBox.MaxY = Math.Max(BoundingBox.MaxY, pos.ElementAt(1));
            BoundingBox.MaxZ = pos.Count() > 2 ? Math.Max(BoundingBox.MaxZ, pos.ElementAt(2)) : double.NaN;
        }
    }
}
