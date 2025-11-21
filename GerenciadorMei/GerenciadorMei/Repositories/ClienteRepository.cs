using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GerenciadorMei.Database;
using GerenciadorMei.Models;

namespace GerenciadorMei.Repositories
{
    public class ClienteRepository
    {
        
        public void Inserir(Cliente c)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Clientes 
                    (Nome, Telefone, Email, data_nascimento, Cpf, Cnpj, Endereco)
                    VALUES
                    (@Nome, @Telefone, @Email, @data_nascimento, @Cpf, @Cnpj, @Endereco);
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", c.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", c.Telefone ?? ""); 
                    cmd.Parameters.AddWithValue("@Email", c.Email ?? "");

                    
                    cmd.Parameters.AddWithValue("@data_nascimento",
                        c.DataNascimento.HasValue ? c.DataNascimento.Value.ToString("yyyy-MM-dd") : null);

                    cmd.Parameters.AddWithValue("@Cpf", c.Cpf ?? "");
                    cmd.Parameters.AddWithValue("@Cnpj", c.Cnpj ?? "");
                    cmd.Parameters.AddWithValue("@Endereco", c.Endereco ?? "");

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
                           
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nome = reader["nome"].ToString(),
                            Telefone = reader["telefone"].ToString(),
                            Email = reader["email"].ToString(),
                            Endereco = reader["endereco"].ToString(),
                            Cpf = reader["cpf"].ToString(),
                            Cnpj = reader["cnpj"].ToString()
                        };

                        string data = reader["data_nascimento"]?.ToString();
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
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Nome = reader["nome"].ToString(),
                                Telefone = reader["telefone"].ToString(),
                                Email = reader["email"].ToString(),
                                Endereco = reader["endereco"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                Cnpj = reader["cnpj"].ToString()
                            };

                            string data = reader["data_nascimento"]?.ToString();
                            if (!string.IsNullOrEmpty(data))
                                cliente.DataNascimento = DateTime.Parse(data);

                            return cliente;
                        }
                    }
                }
            }
            return null;
        }

       
        public void Atualizar(Cliente c)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Clientes SET
                        Nome=@Nome,
                        Telefone=@Telefone,
                        Email=@Email,
                        data_nascimento=@data_nascimento,
                        Cpf=@Cpf,
                        Cnpj=@Cnpj,
                        Endereco=@Endereco
                    WHERE Id=@Id;
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", c.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", c.Telefone ?? "");
                    cmd.Parameters.AddWithValue("@Email", c.Email ?? "");

                    cmd.Parameters.AddWithValue("@data_nascimento",
                        c.DataNascimento.HasValue ? c.DataNascimento.Value.ToString("yyyy-MM-dd") : null);

                    cmd.Parameters.AddWithValue("@Cpf", c.Cpf ?? "");
                    cmd.Parameters.AddWithValue("@Cnpj", c.Cnpj ?? "");
                    cmd.Parameters.AddWithValue("@Endereco", c.Endereco ?? "");
                    cmd.Parameters.AddWithValue("@Id", c.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        public void Excluir(int id)
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