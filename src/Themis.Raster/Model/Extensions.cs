namespace Themis.Raster.Model
{
    public static class Extensions
    {
        public static long ToGridIndex(this double val, double cellSize)
        {
            return (long)Math.Floor(val / cellSize);
        }

        public static double ToProjectedDimension(this double index, double cellSize)
        {
            return index * cellSize;
        }
    }
}
