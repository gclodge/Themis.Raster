using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Themis.Geometry;
using Themis.Geometry.Boundary;
using Themis.Geometry.Boundary.Interfaces;

using Themis.Raster.Model.Interfaces;

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

        private readonly IBoundingBox bb;
        public IBoundingBox BoundingBox => bb;

        public T GetValue(double x, double y)
        {
            throw new NotImplementedException();
        }

        public void CheckExtrema(IEnumerable<T> values)
        {
            throw new NotImplementedException();
        }
    }
}
