using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class RasterCell<T> : IRasterCell<T>
    {
        readonly T? value;

        public T? Value => value;

        public long XIndex { get; set; }
        public long YIndex { get; set; }

        public double CellSize => throw new NotImplementedException();

        public RasterCell(T value)
        {
            this.value = value;
        }

        public IRasterCell<T> SetCellSize(double cellSize)
        {
            throw new NotImplementedException();
        }

        public IRasterCell<T> SetValue(T value)
        {
            throw new NotImplementedException();
        }

        public IRasterCell<T> SetXIndex(long xIndex)
        {
            throw new NotImplementedException();
        }

        public IRasterCell<T> SetYIndex(long yIndex)
        {
            throw new NotImplementedException();
        }

        public static long GetIndex(double val, double cellSize)
        {
            return (long)Math.Floor(val / cellSize);
        }

        public static double GetProjectedDimension(double index, double cellSize)
        {
            return index * cellSize;
        }
    }
}
