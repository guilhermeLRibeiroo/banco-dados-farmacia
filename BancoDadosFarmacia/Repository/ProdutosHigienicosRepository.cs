using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutosHigienicosRepository
    {
        private string CadeiaDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65975\Documents\ExercicioDataBase.mdf;Integrated Security=True;Connect Timeout=30";

        public List<ProdutoHigienico> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_higienicos";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            conexao.Close();
            List<ProdutoHigienico> produtosHigienicos = new List<ProdutoHigienico>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                ProdutoHigienico produtoHigienico = new ProdutoHigienico();
                produtoHigienico.Id = Convert.ToInt32(row["id"]);
                produtoHigienico.Nome = row["nome"].ToString();
                produtoHigienico.Categoria = row["categoria"].ToString();
                produtoHigienico.Preco = Convert.ToDecimal(row["preco"]);

                produtosHigienicos.Add(produtoHigienico);
            }
        
            return produtosHigienicos;
        }

        public ProdutoHigienico ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_higienicos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            conexao.Close();

            if(dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                ProdutoHigienico produtoHigienico = new ProdutoHigienico();
                produtoHigienico.Id = Convert.ToInt32(row["id"]);
                produtoHigienico.Nome = row["nome"].ToString();
                produtoHigienico.Categoria = row["categoria"].ToString();
                produtoHigienico.Preco = Convert.ToDecimal(row["preco"]);

                return produtoHigienico;
            }
            return null;
        }
        
        public void Inserir(ProdutoHigienico produtoHigienico)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "INSERT INTO produtos_higienicos(nome, categoria, preco) VALUES (@NOME, @CATEGORIA, @PRECO)";
            comando.Parameters.AddWithValue("@NOME", produtoHigienico.Nome);
            comando.Parameters.AddWithValue("@CATEGORIA", produtoHigienico.Categoria);
            comando.Parameters.AddWithValue("@PRECO", produtoHigienico.Preco);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "DELETE FROM produtos_higienicos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Atualizar(ProdutoHigienico produtoHigienico)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "UPDATE produtos_higienicos SET nome = @NOME, categoria = @CATEGORIA, preco = @PRECO WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", produtoHigienico.Id);
            comando.Parameters.AddWithValue("@NOME", produtoHigienico.Nome);
            comando.Parameters.AddWithValue("@CATEGORIA", produtoHigienico.Categoria);
            comando.Parameters.AddWithValue("@PRECO", produtoHigienico.Preco);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
