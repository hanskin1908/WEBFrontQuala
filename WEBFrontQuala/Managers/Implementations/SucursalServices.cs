
using Newtonsoft.Json;
using WEBFrontQuala.Managers.Services;
using WEBFrontQuala.Models;

namespace WEBFrontQuala.Managers.Implementations
{
    public class SucursalServices:ISucursalServicescs

    {
        HttpClient client = new HttpClient();

        public void general()
        {

        }


        public async Task<HttpResponseMessage> CreatsucursaltAsync(Sucursal sucursal)
        {
            client.BaseAddress = new Uri("https://localhost:7052/");
            HttpResponseMessage response = await client.PostAsJsonAsync(
               "api/Sucursals/guardarsucursal", sucursal);

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                return response;

            }
            else
            {

            }
            return null;


        }
        public async Task<Response<Moneda_Sucursal>> consultartodassucursales()
        {
            Response<Moneda_Sucursal> response = new Response<Moneda_Sucursal>();

            client.BaseAddress = new Uri("https://localhost:7052/");
            var res = await client.GetAsync(
               "api/Sucursals/GetSucursales");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                response.Lst = JsonConvert.DeserializeObject<List<Moneda_Sucursal>>(results);
                return response;

            }
            else
            {

            }
            return null;


        }


        public async Task<Response<Sucursal>> consultarsucursal(int id)
        {
            Response<Sucursal> response = new Response<Sucursal>();

            client.BaseAddress = new Uri("https://localhost:7052/");
            var res = await client.GetAsync(
               "api/Sucursals/GetSucursal/"+id);

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                response.UnitResp = JsonConvert.DeserializeObject<Sucursal>(results);
                return response;

            }
            else
            {

            }
            return null;


        }


        public async Task<HttpResponseMessage> EliminarSucursal(int id)
        {


            client.BaseAddress = new Uri("https://localhost:7052/");
            var res = await client.DeleteAsync(
               "api/Sucursals/eliminarsucursal/" + id);

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                return res;

            }
            else
            {
                return res;
            }
            return null;


        }

    }
}
