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
    public partial class ProdutosHigienicosLista : Form
    {
        public ProdutosHigienicosLista()
        {
            InitializeComponent();
        }

        private void ProdutosHigienicosLista_Activated(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        public void AtualizarTabela()
        {
            ProdutosHigienicosRepository repositorio = new ProdutosHigienicosRepository();
            List<ProdutoHigienico> produtosHigienicos = repositorio.ObterTodos();

            dataGridView1.Rows.Clear();

            for(int i = 0; i < produtosHigienicos.Count; i++)
            {
                ProdutoHigienico produto = produtosHigienicos[i];
                dataGridView1.Rows.Add(new object[] {
                    produto.Id, produto.Nome, produto.Categoria, produto.Preco
                });
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            ProdutosHigienicosRepository repositorio = new ProdutosHigienicosRepository();
            repositorio.Apagar(id);
            MessageBox.Show("Apagado com sucesso!");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ProdutosHigienicosCadastro form = new ProdutosHigienicosCadastro();
            form.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            ProdutosHigienicosRepository repositorio = new ProdutosHigienicosRepository();
            ProdutoHigienico produto = repositorio.ObterPeloId(id);

            ProdutosHigienicosEditar form = new ProdutosHigienicosEditar(produto);
            form.ShowDialog();
        }
    }
}
