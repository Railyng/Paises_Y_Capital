using System.Linq;
using Paises_Y_Capital.Model;
using Paises_Y_Capital.View;

namespace Paises_Y_Capital.presenter
{
    public class CountryPresenter
    {
        private readonly ICountryView view;
        private readonly Service service;

        public CountryPresenter(ICountryView view)
        {
            this.view = view;
            service = new Service();
        }

        public async void BuscarPais()// Metodo asincrono
        {
            string pais = view.PaisBuscado;
            if (string.IsNullOrEmpty(pais))
            {
                view.MostrarResultado("Ingrese un país", "", "");
                return;
            }

            var paisEncontrado = await service.ObtenerPais(pais);
            if (paisEncontrado != null)
            {
                string capital = paisEncontrado.capital?.FirstOrDefault() ?? "No disponible";
                string bandera = paisEncontrado.flags?.png ?? "";

                view.MostrarResultado(paisEncontrado.name.common, capital, bandera);
            }
            else
            {
                view.MostrarResultado("País no encontrado", "", "");
            }
        }
    }
}
