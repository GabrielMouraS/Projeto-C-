using System;
using System.Data.SQLite;
using GerenciadorMei.Models;
using GerenciadorMei.Database;

namespace GerenciadorMei.Repositories
{
    public class UsuarioRepository 
    {
       
        public void Inserir(Usuario u)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                
                string sql = @"INSERT INTO usuarios (nome, email, senha) 
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

                string sql = @"SELECT * FROM usuarios WHERE email = @Email LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                Senha = reader["senha"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // Retorna null se não achar ninguém (usuário ou senha errados)
        }

   
        public bool ValidarLogin(string email, string senha)
        {
            var usuario = BuscarPorEmail(email);

            if (usuario != null && usuario.Senha == senha)
            {
                return true;
            }
            return false;
        }
    }
}