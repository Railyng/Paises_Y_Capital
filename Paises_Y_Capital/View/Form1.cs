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
            presenter = new CountryPresenter(this);
        }

        public string PaisBuscado => txtBuscar.Text.Trim();
        public void MostrarResultado(string resultado)
        {
            lblResultado.Text = resultado;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            presenter.BuscarPais();
        }
    }
}
