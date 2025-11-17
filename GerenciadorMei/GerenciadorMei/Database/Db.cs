using System.Data.SQLite;

namespace GerenciadorMei.Database
{
    class Db
    {
        private const string ConnectionString = "Data Source=gerenciador.db;Version=3;";

        public Db()
        {
            CriarTabelas();
            InserirUsuarioPadrao();
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        private void CriarTabelas()
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS usuarios (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        email TEXT NOT NULL,
                        senha TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS clientes (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        telefone TEXT,
                        endereco TEXT
                    );

                    CREATE TABLE IF NOT EXISTS servicos (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        preco REAL NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS produtos (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        preco REAL NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS ordens (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        cliente_id INTEGER NOT NULL,
                        data TEXT NOT NULL,
                        status TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS ordens_servicos (
                        ordem_id INTEGER,
                        servico_id INTEGER
                    );

                    CREATE TABLE IF NOT EXISTS ordens_produtos (
                        ordem_id INTEGER,
                        produto_id INTEGER
                    );

                    -- ORÇAMENTOS
                    CREATE TABLE IF NOT EXISTS orcamentos (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        cliente_id INTEGER NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS orcamentos_servicos (
                        orcamento_id INTEGER,
                        servico_id INTEGER
                    );

                    CREATE TABLE IF NOT EXISTS orcamentos_produtos (
                        orcamento_id INTEGER,
                        produto_id INTEGER
                    );

                    -- CONTROLE FINANCEIRO
                    CREATE TABLE IF NOT EXISTS pagamentos (
                        ordem_id INTEGER PRIMARY KEY,
                        data_pagamento TEXT NOT NULL
                    );

                    -- AGENDA
                    CREATE TABLE IF NOT EXISTS agenda (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ordem_id INTEGER,
                        data TEXT NOT NULL
                    );
";




                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InserirUsuarioPadrao()
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM usuarios;";

                using (var cmd = new SQLiteCommand(check, conn))
                {
                    long total = (long)cmd.ExecuteScalar();

                    if (total == 0)
                    {
                        string insert = @"
                            INSERT INTO usuarios (nome, email, senha)
                            VALUES ('Administrador', 'admin@local', '123');";

                        using (var cmdInsert = new SQLiteCommand(insert, conn))
                        {
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
