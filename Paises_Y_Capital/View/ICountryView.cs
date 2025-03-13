
namespace Paises_Y_Capital.View
{
    public interface ICountryView
    {
        string PaisBuscado { get; }
        void MostrarResultado(string resultado);
    }
}
