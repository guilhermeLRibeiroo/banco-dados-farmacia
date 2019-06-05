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
    public partial class ProdutosHigienicosEditar : Form
    {
        public ProdutosHigienicosEditar()
        {
            InitializeComponent();
        }

        public ProdutosHigienicosEditar(ProdutoHigienico produtoHigienico)
        {
            InitializeComponent();
            txtNome.Text = produtoHigienico.Nome;
            txtValor.Text = produtoHigienico.Preco.ToString();
            cbCategoria.SelectedItem = produtoHigienico.Categoria;
            lblId.Text = produtoHigienico.Id.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoHigienico produto = new ProdutoHigienico();
            produto.Id = Convert.ToInt32(lblId.Text);
            produto.Nome = txtNome.Text;
            produto.Categoria = cbCategoria.SelectedItem.ToString();
            produto.Preco = Convert.ToDecimal(txtValor.Text);

            ProdutosHigienicosRepository repositorio = new ProdutosHigienicosRepository();
            repositorio.Atualizar(produto);

            MessageBox.Show("Atualizado com sucesso!");
            Close();
        }
    }
}
