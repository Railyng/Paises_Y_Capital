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

        public async void BuscarPais()
        {
            string pais = view.PaisBuscado;
            if (string.IsNullOrEmpty(pais))
            {
                view.MostrarResultado("Ingrese un país para buscar.");
                return;
            }

            var paisEncontrado = await service.ObtenerPais(pais);
            view.MostrarResultado(paisEncontrado ?? "País no encontrado.");
        }
    }
}
