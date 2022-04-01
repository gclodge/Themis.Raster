using Themis.Raster.Model.Interfaces;

namespace Themis.Raster.Builders.Interfaces
{
    public interface IElevationRasterBuilder : IFluentBuilder<IRaster<double>>
    {
        IElevationRasterBuilder SetMinZ(double minZ);
        IElevationRasterBuilder SetMaxZ(double maxZ);
        IElevationRasterBuilder SetMinMaxZ(double minZ, double maxZ);
    }
}
