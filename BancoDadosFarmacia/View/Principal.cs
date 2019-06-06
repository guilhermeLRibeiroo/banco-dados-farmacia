using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnProdutosComestiveis_Click(object sender, EventArgs e)
        {
            ProdutosComestiveisLista form = new ProdutosComestiveisLista();
            form.ShowDialog();
        }

        private void btnProdutosHigienicos_Click(object sender, EventArgs e)
        {
            ProdutosHigienicosLista form = new ProdutosHigienicosLista();
            form.ShowDialog();
        }

        private void btnRemedios_Click(object sender, EventArgs e)
        {

        }
    }
}
