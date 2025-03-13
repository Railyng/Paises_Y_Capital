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
        private readonly HttpClient client = new HttpClient(); // Cliente HTTP para realizar solicitudes a la API

        // Método asincrónico para obtener los datos de un país
        public async Task<Country> ObtenerPais(string pais)
        {
            string url = "https://restcountries.com/v3.1/all"; // URL de la API
            try
            {
                var response = await client.GetStringAsync(url); //Se obtiene el contenido de la respuesta en formato Json
                var resultado = JsonConvert.DeserializeObject<List<Country>>(response); // Se deserializa el JSON obtenido y se convierte

                // Busca el país ingresado en la lista de resultados
                var paisEncontrado = resultado.FirstOrDefault(p =>
                    p.name.common.Equals(pais, StringComparison.OrdinalIgnoreCase));

                return paisEncontrado; // Retorna el país encontrado o null si no existe
            }
            catch (Exception)
            {
                return null; // Maneja posibles errores de conexión o deserialización
            }
        }
    }
}
