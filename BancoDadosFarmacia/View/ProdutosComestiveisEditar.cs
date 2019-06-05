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
    public partial class ProdutosComestiveisEditar : Form
    {
        public ProdutosComestiveisEditar()
        {
            InitializeComponent();
        }

        public ProdutosComestiveisEditar(Comestivel comestivel)
        {
            InitializeComponent();
            txtNome.Text = comestivel.Nome;
            txtMarca.Text = comestivel.Marca;
            txtQuantidade.Text = comestivel.Quantidade.ToString();
            txtValor.Text = comestivel.Valor.ToString();
            dtpVencimento.Value = comestivel.Vencimento;
            lblId.Text = comestivel.Id.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Comestivel comestivel = new Comestivel();
            comestivel.Id = Convert.ToInt32(lblId.Text);
            comestivel.Nome = txtNome.Text;
            comestivel.Marca = txtMarca.Text;
            comestivel.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            comestivel.Valor = Convert.ToDecimal(txtValor.Text);
            comestivel.Vencimento = dtpVencimento.Value;
            
            ComestiveisRepository repositorio = new ComestiveisRepository();
            repositorio.Atualizar(comestivel);
            
            MessageBox.Show("Atualizado com sucesso!");
            Close();
        }
    }
}
