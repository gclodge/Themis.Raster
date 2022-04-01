using Themis.Geometry;
using Themis.Geometry.Boundary;
using Themis.Geometry.Boundary.Interfaces;

using Themis.Raster.Model.Interfaces;

using MathNet.Numerics.LinearAlgebra;

namespace Themis.Raster.Model
{
    public class Raster<T> : IRaster<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public double PixelSize { get; private set; }

        public double Top => bb.MaxY;
        public double Left => bb.MinX;
        public double Right => bb.MaxX;
        public double Bottom => bb.MinY;

        public Vector<double> Minimum => new[] { Top, Left }.ToVector();
        public Vector<double> Maximum => new[] { Right, Bottom }.ToVector();

        public IBoundingBox BoundingBox => bb;
        public IInfiniteGrid<RasterCell<T>> Grid => grid;

        private readonly IBoundingBox bb;
        private readonly IInfiniteGrid<RasterCell<T>> grid;

        public Raster(int width, int height, double pixelSize)
        {
            this.Width = width;
            this.Height = height;
            this.PixelSize = pixelSize;

            bb = new BoundingBox();
            grid = new InfiniteGrid<RasterCell<T>>(pixelSize);
        }

        public bool TryGetValue(double x, double y, out T? value)
        {
            value = default(T);
            if (!grid.Contains(x, y)) return false;

            value = grid.Get(x, y).Value;
            return true;
        }

        public void CheckExtrema(IEnumerable<T> values)
        {
            throw new NotImplementedException();
        }
    }
}
