using Themis.Geometry.Boundary;

namespace Themis.Raster.Model.Interfaces
{
    public interface IRaster<T>
    {
        public int Width { get; }
        public int Height { get; }

        public double MinX { get; }
        public double MinY { get; }
        public double MinZ { get; }
        public double MaxX { get; }
        public double MaxY { get; }
        public double MaxZ { get; }
        
        public double PixelSize { get; }

        BoundingBox BoundingBox { get; }

        IRaster<T> Add(T value, long xIdx, long yIdx);
        IRaster<T> Add(T value, double x, double y);
        IRaster<T> Add(T value, IEnumerable<double> pos);
        IRaster<T> Remove(double x, double y);
        IRaster<T> Remove(long xIdx, long yIdx);

        bool TryGetValue(double x, double y, out T? value);
        void AdjustExtrema(IEnumerable<double> pos);
    }
}
