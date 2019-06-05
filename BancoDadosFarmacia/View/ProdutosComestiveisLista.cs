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
    public partial class ProdutosComestiveisLista : Form
    {
        public ProdutosComestiveisLista()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ProdutosComestiveisCadastro form = new ProdutosComestiveisCadastro();
            form.ShowDialog();
        }

        private void ProdutosComestiveisLista_Activated(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            ComestiveisRepository repositorio = new ComestiveisRepository();
            List<Comestivel> comestiveis = repositorio.ObterTodos();

            dataGridView1.Rows.Clear();

            for (int i = 0; i < comestiveis.Count; i++)
            {
                Comestivel comestivel = comestiveis[i];
                dataGridView1.Rows.Add(new object[] {
                    comestivel.Id, comestivel.Nome, comestivel.Marca, comestivel.Valor, comestivel.Quantidade, comestivel.Vencimento.ToString("dd/MM/yyyy")
                });
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            ComestiveisRepository repositorio = new ComestiveisRepository();
            repositorio.Apagar(id);
            MessageBox.Show("Apagado com sucesso!");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            ComestiveisRepository repositorio = new ComestiveisRepository();
            Comestivel comestivel = repositorio.ObterPeloID(id);

            ProdutosComestiveisEditar editar = new ProdutosComestiveisEditar(comestivel);
            editar.ShowDialog();
        }
    }
}
