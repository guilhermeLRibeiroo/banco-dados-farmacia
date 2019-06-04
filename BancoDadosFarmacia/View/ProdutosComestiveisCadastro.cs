using Model;
using Repository;
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
    public partial class ProdutosComestiveisCadastro : Form
    {
        public ProdutosComestiveisCadastro()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Comestivel comestivel = new Comestivel();
            comestivel.Nome = txtNome.Text;
            comestivel.Marca = txtMarca.Text;
            comestivel.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            comestivel.Valor = Convert.ToDecimal(txtValor.Text);
            comestivel.Vencimento = dtpVencimento.Value;

            ComestiveisRepository repositorio = new ComestiveisRepository();
            repositorio.Inserir(comestivel);

            MessageBox.Show("Cadastrado com sucesso!");
            Close();
        }
    }
}
