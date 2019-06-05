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
    public partial class ProdutosHigienicosCadastro : Form
    {
        public ProdutosHigienicosCadastro()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoHigienico produtoHigienico = new ProdutoHigienico();
            produtoHigienico.Nome = txtNome.Text;
            produtoHigienico.Preco = Convert.ToDecimal(txtValor.Text);
            produtoHigienico.Categoria = cbCategoria.SelectedItem.ToString();

            ProdutosHigienicosRepository repositorio = new ProdutosHigienicosRepository();
            repositorio.Inserir(produtoHigienico);

            MessageBox.Show("Cadastrado com sucesso!");
            Close();
        }
    }
}
