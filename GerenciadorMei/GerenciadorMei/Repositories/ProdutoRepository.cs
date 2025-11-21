using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GerenciadorMei.Models;
using GerenciadorMei.Database; // Importante para achar a classe Db

namespace GerenciadorMei.Repositories
{
    public class ProdutoRepository
    {
        // Não precisa mais da string connectionString aqui!

        public List<Produto> GetAll()
        {
            var lista = new List<Produto>();

            // USA A CONEXÃO CENTRALIZADA DA SUA CLASSE DB
            using (var conn = Db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, Nome, Preco FROM produtos"; // minúsculo igual no create table

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var produto = new Produto
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nome = reader["nome"].ToString(),
                                    Preco = Convert.ToDecimal(reader["preco"])
                                };
                                lista.Add(produto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro no SQLite: " + ex.Message);
                }
            }
            return lista;
        }
    }
}