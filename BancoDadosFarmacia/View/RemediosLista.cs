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
    public partial class RemediosLista : Form
    {
        public RemediosLista()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            RemediosCadastro form = new RemediosCadastro();
            form.ShowDialog();
        }

        private void RemediosLista_Activated(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            dataGridView1.Rows.Clear();

            RemediosRepository repositorio = new RemediosRepository();
            List<Remedio> remedios = repositorio.ObterTodos();

            for (int i = 0; i < remedios.Count; i++)
            {
                Remedio remedio = remedios[i];
                dataGridView1.Rows.Add(new object[] {
                    remedio.Id, remedio.Nome, remedio.Faixa, remedio.Solido, remedio.Generico
                });
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            RemediosRepository repositorio = new RemediosRepository();
            Remedio remedio = repositorio.ObterPeloId(id);

            RemediosEditar editar = new RemediosEditar(remedio);
            editar.ShowDialog();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            RemediosRepository repositorio = new RemediosRepository();

            if (MessageBox.Show("Desejas apagar este registro?", "ATENÇÃO!!!!!!!!!!!!!!!!!!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                repositorio.Apagar(id);
                MessageBox.Show("Apagado com sucesso!");
            }
        }
    }
}
