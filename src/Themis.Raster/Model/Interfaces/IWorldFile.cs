namespace Themis.Raster.Model.Interfaces
{
    public interface IWorldFile
    {
        /// <summary>
        /// The Y (in source units) of the top-left corner of the BoundingBox represented by this WorldFile
        /// </summary>
        double Top { get; }
        /// <summary>
        /// The X (in source units) of the top-left corner of the BoundingBox represented by this WorldFile
        /// </summary>
        double Left { get; }
        /// <summary>
        /// The total square size (in source units) of each raster cell
        /// </summary>
        double PixelSize { get; }

        /// <summary>
        /// Set the total square size of each raster cell
        /// </summary>
        /// <param name="pixelSize">Size to be set (in source units)</param>
        /// <returns></returns>
        IWorldFile SetPixelSize(double pixelSize);
        /// <summary>
        /// Set the top-left coordinate of the BoundingBox represented by this WorldFile
        /// </summary>
        /// <param name="x">The X (in source units) of the top-left corner</param>
        /// <param name="y">The Y (in source units) of the top-left corner</param>
        /// <returns></returns>
        IWorldFile SetTopLeft(double x, double y);
    }
}
