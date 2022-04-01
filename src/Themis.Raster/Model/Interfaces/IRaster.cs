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

        public IBoundingBox BoundingBox { get; }

        public Vector<double> Minimum { get; }
        public Vector<double> Maximum { get; }

        T GetValue(double x, double y);
        void CheckExtrema(IEnumerable<T> values);
    }
}
