using System;
using System.Data.SQLite;
using GerenciadorMei.Models;
using GerenciadorMei.Database;

namespace GerenciadorMei.Repositories
{
    class UsuarioRepository
    {
        public void CriarTabela()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS usuarios (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        Senha TEXT NOT NULL
                    );
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(Usuario u)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO usuarios (Nome, Email, Senha)
                               VALUES (@Nome, @Email, @Senha)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", u.Nome);
                    cmd.Parameters.AddWithValue("@Email", u.Email);
                    cmd.Parameters.AddWithValue("@Senha", u.Senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario BuscarPorEmail(string email)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM usuarios WHERE Email = @Email LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Email = reader["Email"].ToString(),
                                Senha = reader["Senha"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
