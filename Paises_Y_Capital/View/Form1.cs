using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paises_Y_Capital.View;
using Paises_Y_Capital.Model;
using Paises_Y_Capital.presenter;
using System.Net;

namespace Paises_Y_Capital
{
    public partial class Form1 : Form, ICountryView
    {
        private CountryPresenter presenter;
        public Form1()
        {
            InitializeComponent();
            presenter = new CountryPresenter(this); // Crea una instancia del presentador
        }

        public string PaisBuscado => txtBuscar.Text.Trim();// Obtiene el nombre del país ingresado en el TextBox por el usuario


        // Muestra los resultados en el Label y carga la imagen de la bandera en el PictureBox
        public void MostrarResultado(string nombre, string capital, string bandera)
        {
            // Verifica si la URL de la bandera no está vacía
            lblResultado.Text = $"País: {nombre}\nCapital: {capital}";

            if (!string.IsNullOrEmpty(bandera))
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(bandera); // Descarga la imagen de la URL
                    using (var ms = new System.IO.MemoryStream(imageBytes)) // Convierte los bytes en una imagen
                    {
                        pictureBoxBandera.Image = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                pictureBoxBandera.Image = null;// Limpia la imagen si no hay bandera disponible
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            presenter.BuscarPais(); // Llama al método para buscar el país
        }
    }
}
