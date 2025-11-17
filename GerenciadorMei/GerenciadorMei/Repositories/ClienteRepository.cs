using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GerenciadorMei.Database;
using GerenciadorMei.Models;

namespace GerenciadorMei.Repositories
{
    public class ClienteRepository
    {
        public void Add(Cliente c)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Clientes 
                    (Nome, Telefone, Email, DataNascimento, Cpf, Cnpj, Endereco)
                    VALUES
                    (@Nome, @Telefone, @Email, @DataNascimento, @Cpf, @Cnpj, @Endereco);
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", c.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@Email", c.Email);
                    cmd.Parameters.AddWithValue("@DataNascimento",
                        c.DataNascimento.HasValue ? c.DataNascimento.Value.ToString("yyyy-MM-dd") : null);
                    cmd.Parameters.AddWithValue("@Cpf", c.Cpf);
                    cmd.Parameters.AddWithValue("@Cnpj", c.Cnpj);
                    cmd.Parameters.AddWithValue("@Endereco", c.Endereco);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> GetAll()
        {
            var lista = new List<Cliente>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Clientes ORDER BY Nome ASC;";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader["Nome"].ToString(),
                            Telefone = reader["Telefone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Endereco = reader["Endereco"].ToString(),
                            Cpf = reader["Cpf"].ToString(),
                            Cnpj = reader["Cnpj"].ToString()
                        };

                        string data = reader["DataNascimento"]?.ToString();
                        if (!string.IsNullOrEmpty(data))
                            cliente.DataNascimento = DateTime.Parse(data);

                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }

        public Cliente GetById(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Clientes WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader["Nome"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Email = reader["Email"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Cpf = reader["Cpf"].ToString(),
                                Cnpj = reader["Cnpj"].ToString()
                            };

                            string data = reader["DataNascimento"]?.ToString();
                            if (!string.IsNullOrEmpty(data))
                                cliente.DataNascimento = DateTime.Parse(data);

                            return cliente;
                        }
                    }
                }
            }

            return null;
        }

        public void Update(Cliente c)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Clientes SET
                        Nome=@Nome,
                        Telefone=@Telefone,
                        Email=@Email,
                        DataNascimento=@DataNascimento,
                        Cpf=@Cpf,
                        Cnpj=@Cnpj,
                        Endereco=@Endereco
                    WHERE Id=@Id;
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", c.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@Email", c.Email);
                    cmd.Parameters.AddWithValue("@DataNascimento",
                        c.DataNascimento.HasValue ? c.DataNascimento.Value.ToString("yyyy-MM-dd") : null);
                    cmd.Parameters.AddWithValue("@Cpf", c.Cpf);
                    cmd.Parameters.AddWithValue("@Cnpj", c.Cnpj);
                    cmd.Parameters.AddWithValue("@Endereco", c.Endereco);
                    cmd.Parameters.AddWithValue("@Id", c.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Clientes WHERE Id=@Id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
