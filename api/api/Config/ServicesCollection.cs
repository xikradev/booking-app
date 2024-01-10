using api.Data.Interfaces;
using api.Data.Repositories;
using api.Domain.Interfaces;
using api.Domain.Services;

namespace api.Config
{
    public static class ServicesCollection
    {
        public static void AddServices(this IServiceCollection services)
        {
            #region Service
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPlaceService, PLaceService>();
            #endregion

            #region Repository
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            #endregion
        }
    }
}
