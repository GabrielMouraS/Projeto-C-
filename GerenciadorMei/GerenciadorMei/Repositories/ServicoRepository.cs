using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GerenciadorMei.Database;
using GerenciadorMei.Models;

namespace GerenciadorMei.Repositories
{
    public class ServicoRepository
    {
        
        public List<Servico> GetAll()
        {
            var lista = new List<Servico>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                
                string sql = @"
                    SELECT o.id, o.data, o.status, o.nome, o.valor_total, o.cliente_id, c.nome AS NomeCliente
                    FROM ordens o
                    LEFT JOIN clientes c ON o.cliente_id = c.id
                    ORDER BY o.data DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Servico
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            ClienteId = Convert.ToInt32(reader["cliente_id"]),
                            Data = DateTime.Parse(reader["data"].ToString()),
                            Status = reader["status"].ToString(),
                            Nome = reader["nome"] != DBNull.Value ? reader["nome"].ToString() : "",
                            Preco = reader["valor_total"] != DBNull.Value ? Convert.ToDouble(reader["valor_total"]) : 0.0,
                            NomeCliente = reader["NomeCliente"] != DBNull.Value ? reader["NomeCliente"].ToString() : "Cliente Removido"
                        });
                    }
                }
            }
            return lista;
        }

        
        public Servico GetById(int id)
        {
            Servico s = null;
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                
                string sql = @"
                    SELECT o.id, o.cliente_id, o.data, o.status, o.nome, o.valor_total, c.nome AS NomeCliente
                    FROM ordens o
                    LEFT JOIN clientes c ON o.cliente_id = c.id
                    WHERE o.id = @id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s = new Servico
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ClienteId = Convert.ToInt32(reader["cliente_id"]),
                                Data = DateTime.Parse(reader["data"].ToString()),
                                Status = reader["status"].ToString(),
                                Nome = reader["nome"] != DBNull.Value ? reader["nome"].ToString() : "",
                                Preco = reader["valor_total"] != DBNull.Value ? Convert.ToDouble(reader["valor_total"]) : 0.0,
                                NomeCliente = reader["NomeCliente"] != DBNull.Value ? reader["NomeCliente"].ToString() : ""
                            };
                        }
                    }
                }

               
                if (s != null)
                {
                    s.Produtos = new List<int>();
                    string sqlProd = "SELECT produto_id FROM ordens_produtos WHERE ordem_id = @id";
                    using (var cmd = new SQLiteCommand(sqlProd, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                s.Produtos.Add(Convert.ToInt32(reader["produto_id"]));
                            }
                        }
                    }
                }
            }
            return s;
        }

        
        public void Create(Servico servico)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlOrdem = @"
                            INSERT INTO ordens (cliente_id, data, status, nome, valor_total) 
                            VALUES (@cli, @data, 'Aberto', @nome, @total);
                            SELECT last_insert_rowid();";

                        long idOrdemGerada;

                        using (var cmd = new SQLiteCommand(sqlOrdem, conn))
                        {
                            cmd.Parameters.AddWithValue("@cli", servico.ClienteId);
                            cmd.Parameters.AddWithValue("@data", servico.Data.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@nome", servico.Nome);
                            cmd.Parameters.AddWithValue("@total", servico.Preco);
                            idOrdemGerada = (long)cmd.ExecuteScalar();
                        }

                        if (servico.Produtos != null && servico.Produtos.Count > 0)
                        {
                            string sqlProd = "INSERT INTO ordens_produtos (ordem_id, produto_id) VALUES (@oid, @pid)";
                            foreach (int prodId in servico.Produtos)
                            {
                                using (var cmdProd = new SQLiteCommand(sqlProd, conn))
                                {
                                    cmdProd.Parameters.AddWithValue("@oid", idOrdemGerada);
                                    cmdProd.Parameters.AddWithValue("@pid", prodId);
                                    cmdProd.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        
        public void Update(Servico servico)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string sql = @"
                            UPDATE ordens 
                            SET cliente_id=@cli, data=@data, nome=@nome, valor_total=@total 
                            WHERE id=@id";

                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@cli", servico.ClienteId);
                            cmd.Parameters.AddWithValue("@data", servico.Data.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@nome", servico.Nome);
                            cmd.Parameters.AddWithValue("@total", servico.Preco);
                            cmd.Parameters.AddWithValue("@id", servico.Id);
                            cmd.ExecuteNonQuery();
                        }

                        
                        string delSql = "DELETE FROM ordens_produtos WHERE ordem_id=@id";
                        using (var cmdDel = new SQLiteCommand(delSql, conn))
                        {
                            cmdDel.Parameters.AddWithValue("@id", servico.Id);
                            cmdDel.ExecuteNonQuery();
                        }

                        if (servico.Produtos != null && servico.Produtos.Count > 0)
                        {
                            string sqlProd = "INSERT INTO ordens_produtos (ordem_id, produto_id) VALUES (@oid, @pid)";
                            foreach (int prodId in servico.Produtos)
                            {
                                using (var cmdProd = new SQLiteCommand(sqlProd, conn))
                                {
                                    cmdProd.Parameters.AddWithValue("@oid", servico.Id);
                                    cmdProd.Parameters.AddWithValue("@pid", prodId);
                                    cmdProd.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        
        public void Excluir(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM ordens_produtos WHERE ordem_id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand("DELETE FROM ordens WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE ordens SET status = @status WHERE id = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", novoStatus);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}