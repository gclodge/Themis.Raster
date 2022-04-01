using Themis.Raster.Model.Interfaces;
using Themis.Geometry.Boundary.Interfaces;

using MathNet.Numerics.LinearAlgebra;

namespace Themis.Raster.Model.Interfaces
{
    public interface IRaster<T>
    {
        public int Width { get; }
        public int Height { get; }

        public double Top { get; }
        public double Left { get; }
        public double Right { get; }
        public double Bottom { get; }
        public double PixelSize { get; }

        IBoundingBox BoundingBox { get; }
        IInfiniteGrid<RasterCell<T>> Grid { get; }

        public Vector<double> Minimum { get; }
        public Vector<double> Maximum { get; }

        bool TryGetValue(double x, double y, out T? value);
        void CheckExtrema(IEnumerable<T> values);
    }
}
