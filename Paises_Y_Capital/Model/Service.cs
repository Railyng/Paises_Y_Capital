using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Paises_Y_Capital.Model
{
    public class Service
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<string> ObtenerPais(string pais)
        {
            string url = "https://countriesnow.space/api/v0.1/countries/capital";
            try
            {
                var response = await client.GetStringAsync(url);
                var resultado = JsonConvert.DeserializeObject<Countries>(response);
                var paisEncontrado = resultado.data.Find(p => p.name.Equals(pais, StringComparison.OrdinalIgnoreCase));
                return paisEncontrado != null ? $"País: {paisEncontrado.name}\nCapital: {paisEncontrado.capital}" : null;
            }
            catch (Exception)
            {
                return "Error al obtener los datos.";
            }
        }
    }
}
