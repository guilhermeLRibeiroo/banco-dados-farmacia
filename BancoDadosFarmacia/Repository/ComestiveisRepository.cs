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
    public class ComestiveisRepository
    {
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65975\Documents\ExercicioDataBase.mdf;Integrated Security=True;Connect Timeout=30";

        public void Inserir(Comestivel comestivel)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO produtos_comestiveis
(quantidade, nome, marca, valor, data_vencimento) 
VALUES(@QUANTIDADE, @NOME, @MARCA, @VALOR, @DATA_VENCIMENTO)";
            comando.Parameters.AddWithValue("@QUANTIDADE", comestivel.Quantidade);
            comando.Parameters.AddWithValue("@NOME", comestivel.Nome);
            comando.Parameters.AddWithValue("@MARCA", comestivel.Marca);
            comando.Parameters.AddWithValue("@VALOR", comestivel.Valor);
            comando.Parameters.AddWithValue("@DATA_VENCIMENTO", Convert.ToDateTime(comestivel.Vencimento.ToString("yyyy-MM-dd")));
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Atualizar(Comestivel comestivel)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE produtos_comestiveis SET
nome = @NOME,
quantidade = @QUANTIDADE,
marca = @MARCA,
valor = @VALOR,
data_vencimento = @DATA_VENCIMENTO
WHERE id = @ID
";
            comando.Parameters.AddWithValue("@NOME", comestivel.Nome);
            comando.Parameters.AddWithValue("@QUANTIDADE", comestivel.Quantidade);
            comando.Parameters.AddWithValue("@MARCA", comestivel.Marca);
            comando.Parameters.AddWithValue("@VALOR", comestivel.Valor);
            comando.Parameters.AddWithValue("@DATA_VENCIMENTO", comestivel.Vencimento);
            comando.Parameters.AddWithValue("@ID", comestivel.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public List<Comestivel> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_comestiveis";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            List<Comestivel> comestiveis = new List<Comestivel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Comestivel comestivel = new Comestivel();
                comestivel.Id = Convert.ToInt32(row["id"]);
                comestivel.Nome = row["nome"].ToString();
                comestivel.Marca = row["marca"].ToString();
                comestivel.Valor = Convert.ToDecimal(row["valor"]);
                comestivel.Vencimento = Convert.ToDateTime(row["data_vencimento"]);
                comestivel.Quantidade = Convert.ToInt32(row["quantidade"]);

                comestiveis.Add(comestivel);
            }
            conexao.Close();
            return comestiveis;
        }

        public Comestivel ObterPeloID(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_comestiveis WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());
            conexao.Close();
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                Comestivel comestivel = new Comestivel();
                comestivel.Id = Convert.ToInt32(row["id"]);
                comestivel.Nome = row["nome"].ToString();
                comestivel.Marca = row["marca"].ToString();
                comestivel.Valor = Convert.ToDecimal(row["valor"]);
                comestivel.Vencimento = Convert.ToDateTime(row["data_vencimento"]);
                comestivel.Quantidade = Convert.ToInt32(row["quantidade"]);

                return comestivel;
            }
            return null;
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "DELETE FROM produtos_comestiveis WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
