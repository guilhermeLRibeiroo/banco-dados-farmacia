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

        private void ProdutosComestiveisLista_Load(object sender, EventArgs e)
        {
            ComestiveisRepository repositorio = new ComestiveisRepository();
            List<Comestivel> comestiveis = repositorio.ObterTodos();

            dataGridView1.Rows.Clear();

            for(int i = 0; i < comestiveis.Count; i++)
            {
                Comestivel comestivel = comestiveis[i];
                dataGridView1.Rows.Add(new object[] {
                    comestivel.Id, comestivel.Nome, comestivel.Marca, comestivel.Valor, comestivel.Quantidade, comestivel.Vencimento.ToString("dd/MM/yyyy")
                });
            }
        }
    }
}
