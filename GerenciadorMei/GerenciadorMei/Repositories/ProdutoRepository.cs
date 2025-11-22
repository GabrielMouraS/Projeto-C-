using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GerenciadorMei.Database;
using GerenciadorMei.Models;

namespace GerenciadorMei.Repositories
{
    public class ProdutoRepository
    {
        public void Inserir(Produto p)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO produtos (nome, preco) VALUES (@Nome, @Preco)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Preco", p.Preco);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Produto p)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE produtos SET nome = @Nome, preco = @Preco WHERE id = @Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Preco", p.Preco);
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM produtos WHERE id = @Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> GetAll()
        {
            var lista = new List<Produto>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, nome, preco FROM produtos ORDER BY nome";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Produto
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString(),
                            Preco = Convert.ToDecimal(reader["preco"])
                        });
                    }
                }
            }
            return lista;
        }

        // --- O MÉTODO ABAIXO FOI ADICIONADO (NECESSÁRIO PARA O ERRO CS1061) ---
        public Produto GetById(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM produtos WHERE id = @Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                // Mantive ToDecimal conforme seu padrão
                                Preco = Convert.ToDecimal(reader["preco"])
                            };
                        }
                    }
                }
            }
            return null;
        }
        // ----------------------------------------------------------------------
    }
}