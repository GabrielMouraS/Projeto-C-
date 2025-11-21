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
                    SELECT 
                        o.id, 
                        o.data, 
                        o.status, 
                        o.cliente_id,
                        c.nome AS NomeCliente
                    FROM ordens o
                    LEFT JOIN clientes c ON o.cliente_id = c.id
                    ORDER BY o.id DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Servico
                        {
                            Id = Convert.ToInt32(reader["id"]),

                            
                            Nome = reader["NomeCliente"] != DBNull.Value ? reader["NomeCliente"].ToString() : "Cliente Excluído",

                            ClienteId = Convert.ToInt32(reader["cliente_id"]),
                            Data = Convert.ToDateTime(reader["data"]),
                            Status = reader["status"].ToString(),

                          
                            Preco = 0
                        });
                    }
                }
            }
            return lista;
        }

        
        public void Create(Servico servico)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

               
                string sql = "INSERT INTO ordens (cliente_id, data, status) VALUES (@cli, @data, @status)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cli", servico.ClienteId);
                    // Salva a data no formato ano-mês-dia para o SQLite ordenar certo
                    cmd.Parameters.AddWithValue("@data", servico.Data.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", "Aberto");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        public void UpdateStatus(int id, string novoStatus)
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

        // --- DELETE (Apagar do Histórico) ---
        public void Delete(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                
                string sql = "DELETE FROM ordens WHERE id = @id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}