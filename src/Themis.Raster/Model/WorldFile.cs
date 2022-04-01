using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Model
{
    public class WorldFile : IWorldFile, IEquatable<WorldFile>
    {
        private const int MinimumDimensionality = 2;
        private const double MaxRotationalAllowance = 0.000001;
        
        public double Top { get; set; } = double.NaN;
        public double Left { get; set; } = double.NaN;

        public double PixelSize { get; set; } = double.NaN;

        #region Fluent Interface
        public IWorldFile SetPixelSize(double pixelSize)
        {
            this.PixelSize = pixelSize;
            return this;
        }

        public IWorldFile SetTopLeft(double x, double y)
        {
            this.Top = y;
            this.Left = x;
            return this;
        }
        #endregion

        #region Static Members
        public static WorldFile Generate(double x, double y, double pixelSize)
        {
            return new WorldFile
            {
                Top = y,
                Left = x,
                PixelSize = pixelSize
            };
        }

        public static WorldFile Generate(IEnumerable<double> xy, double pixelSize)
        {
            if (xy.Count() < MinimumDimensionality) throw new ArgumentException($"Top-Left coordinate must have at least {MinimumDimensionality} dimensions", nameof(xy));
            if (pixelSize <= 0) throw new ArgumentException($"PixelSize must be a positive, non-zero decimal number", nameof(pixelSize));

            return Generate(xy.ElementAt(0), xy.ElementAt(1), pixelSize);
        }

        public static WorldFile FromFile(string filePath)
        {
            //< Parse all values into memory (whole file is just doubles, bruh)
            var values = File.ReadAllLines(filePath).Select(double.Parse).ToList();

            //< Ensure we have square pixels, rotation is something I'm too lazy to support
            if (Math.Abs(values[0] + values[3]) > MaxRotationalAllowance) throw new NotImplementedException($"Non-square pixels are not currently supported, ya non-square.");

            return new WorldFile
            {
                //< Snake the top-left (x, y) coordinate of the image frame
                Top = values[4],
                Left = values[5],
                //< Grab the pixel size (in projected units)
                PixelSize = values[0]
            };
        }
        #endregion

        #region IEquatable
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            return Equals(obj as WorldFile);
        }

        public bool Equals(WorldFile? other)
        {
            return other != null &&
                   Top.Equals(other.Top) &&
                   Left.Equals(other.Left) &&
                   PixelSize.Equals(other.PixelSize);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Top, Left, PixelSize);
        }
        #endregion
    }
}
