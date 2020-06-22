using HelloWorld.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Repository
{
    public class TodoRepository
    {
        private string ConnectionString { get; set; }

        public TodoRepository(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("TodoConnection");
        }

        public void Save(Aniversariante aniversariante)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var sql = @" INSERT INTO TASK(Id, primeiroNome, segundoNome, dataAniversario)
                             VALUES (@P1, @P2, @P3, @P4)
                ";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1", aniversariante.Id);
                sqlCommand.Parameters.AddWithValue("P2", aniversariante.primeiroNome);
                sqlCommand.Parameters.AddWithValue("P3", aniversariante.segundoNome);
                sqlCommand.Parameters.AddWithValue("P4", aniversariante.dataAniversario);


                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Update(Aniversariante aniversariante)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {


                var sql = @" UPDATE TASK 
                             SET primeiroNome = @P1,
                             segundoNome = @P2
                             WHERE Id = @P3 
                ";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1", aniversariante.primeiroNome);
                sqlCommand.Parameters.AddWithValue("P2", aniversariante.segundoNome);
                sqlCommand.Parameters.AddWithValue("P3", aniversariante.Id);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {

                var sql = @" DELETE FROM TASK
                             WHERE Id = @P1 
                ";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1", id);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Aniversariante> GetAll()
        {
            List<Aniversariante> result = new List<Aniversariante>();

            using (var connection = new SqlConnection(this.ConnectionString))
            {

                var sql = @" SELECT Id, primeiroNome, segundoNome, dataAniversario FROM TASK ORDER BY dataAniversario DESC";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Aniversariante aniversariante = new Aniversariante()
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        primeiroNome = reader["primeiroNome"].ToString(),
                        segundoNome = reader["segundoNome"].ToString(),
                        dataAniversario = Convert.ToDateTime(reader["dataAniversario"])
                    };

                    result.Add(aniversariante);
                }

                connection.Close();
            }

            return result;
        }

        public Aniversariante GetById(Guid id)
        {
            List<Aniversariante> result = new List<Aniversariante>();

            using (var connection = new SqlConnection(this.ConnectionString))
            {

                var sql = @" SELECT Id, primeiroNome, segundoNome, dataAniversario 
                             FROM TASK
                             WHERE Id = @P1
                ";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1", id);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Aniversariante aniversariante = new Aniversariante()
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        primeiroNome = reader["primeiroNome"].ToString(),
                        segundoNome = reader["segundoNome"].ToString(),
                        dataAniversario = DateTime.Parse(reader["dataAniversario"].ToString())
                    };

                    result.Add(aniversariante);
                }

                connection.Close();
            }

            return result.FirstOrDefault();
        }
        public List<Aniversariante> Pesquisar(string nome)
        {
            List<Aniversariante> todos = new List<Aniversariante>();

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlcommand = connection.CreateCommand();

                sqlcommand.CommandText = "SELECT Id, primeiroNome, segundoNome, dataAniversario FROM TASK WHERE primeiroNome LIKE '%'+@P1+'%'";
                sqlcommand.Parameters.AddWithValue("P1", nome);

                SqlDataReader reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    Aniversariante aniversariante = new Aniversariante()
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        primeiroNome = reader["primeiroNome"].ToString().Split(" ").First(),
                        segundoNome = reader["segundoNome"].ToString().Split(" ").Last(),
                        dataAniversario = DateTime.Parse(reader["dataAniversario"].ToString())
                    };
                    todos.Add(aniversariante);
                }


                connection.Close();

            }
            return todos;

        }
    }
}
