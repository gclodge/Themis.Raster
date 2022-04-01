namespace Themis.Raster.Model.Interfaces
{
    public interface IWorldFile
    {
        double Top { get; }
        double Left { get; }

        double PixelSize { get; }

        IWorldFile SetPixelSize(double pixelSiez);
        IWorldFile SetTopLeft(double top, double left);
    }
}
