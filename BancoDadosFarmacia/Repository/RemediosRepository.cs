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
    public class RemediosRepository
    {
        private string CadeiaDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65975\Documents\ExercicioDataBase.mdf;Integrated Security=True;Connect Timeout=30";

        public List<Remedio> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_remedios";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            List<Remedio> remedios = new List<Remedio>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                Remedio remedio = new Remedio();

                remedio.Id = Convert.ToInt32(row["id"]);
                remedio.Nome = row["nome"].ToString();
                remedio.Faixa = row["faixa"].ToString();
                remedio.Bula = row["bula"].ToString();
                remedio.Categoria = row["categoria"].ToString();
                remedio.Generico = Convert.ToBoolean(row["generico"]);
                remedio.Solido = Convert.ToBoolean(row["solido"]);
                remedio.PrecisaReceita = Convert.ToBoolean(row["precisa_receita"]);

                remedios.Add(remedio);
            }

            return remedios;
        }

        public Remedio ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM produtos_remedios WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            if(dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                Remedio remedio = new Remedio();

                remedio.Id = Convert.ToInt32(row["id"]);
                remedio.Nome = row["nome"].ToString();
                remedio.Faixa = row["faixa"].ToString();
                remedio.Bula = row["bula"].ToString();
                remedio.Categoria = row["categoria"].ToString();
                remedio.Generico = Convert.ToBoolean(row["generico"]);
                remedio.Solido = Convert.ToBoolean(row["solido"]);
                remedio.PrecisaReceita = Convert.ToBoolean(row["precisa_receita"]);

                return remedio;
            }
            return null;
        }

        public void Inserir(Remedio remedio)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO produtos_remedios (nome, faixa, categoria, generico, solido, precisa_receita, bula)
VALUES 
(@NOME,
@FAIXA,
@CATEGORIA,
@GENERICO,
@SOLIDO,
@PRECISA_RECEITA,
@BULA)";
            comando.Parameters.AddWithValue("@NOME", remedio.Nome);
            comando.Parameters.AddWithValue("@FAIXA", remedio.Faixa);
            comando.Parameters.AddWithValue("@CATEGORIA", remedio.Categoria);
            comando.Parameters.AddWithValue("@GENERICO", remedio.Generico);
            comando.Parameters.AddWithValue("@SOLIDO", remedio.Solido);
            comando.Parameters.AddWithValue("@PRECISA_RECEITA", remedio.PrecisaReceita);
            comando.Parameters.AddWithValue("@BULA", remedio.Bula);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Atualizar(Remedio remedio)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaDeConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "UPDATE produtos_remedios SET nome = @NOME, faixa = @FAIXA, categoria = @CATEGORIA, generico = @GENERICO, solido = @SOLIDO, precisa_receita = @PRECISA_RECEITA, bula = @BULA WHERE id = @ID";

            comando.Parameters.AddWithValue("@NOME", remedio.Nome);
            comando.Parameters.AddWithValue("@FAIXA", remedio.Faixa);
            comando.Parameters.AddWithValue("@CATEGORIA", remedio.Categoria);
            comando.Parameters.AddWithValue("@GENERICO", remedio.Generico);
            comando.Parameters.AddWithValue("@SOLIDO", remedio.Solido);
            comando.Parameters.AddWithValue("@PRECISA_RECEITA", remedio.PrecisaReceita);
            comando.Parameters.AddWithValue("@BULA", remedio.Bula);
            comando.Parameters.AddWithValue("@ID", remedio.Id);

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
            comando.CommandText = "DELETE FROM produtos_remedios WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
