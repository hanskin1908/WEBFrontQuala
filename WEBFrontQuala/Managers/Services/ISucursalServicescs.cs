using WEBFrontQuala.Models;

namespace WEBFrontQuala.Managers.Services
{
    public interface ISucursalServicescs
    {
         Task<HttpResponseMessage> CreatsucursaltAsync(Sucursal sucursal);
         Task<Response<Moneda_Sucursal>> consultartodassucursales();
           Task<HttpResponseMessage> EliminarSucursal(int id);
        Task<Response<Sucursal>> consultarsucursal(int id);
    }
}
