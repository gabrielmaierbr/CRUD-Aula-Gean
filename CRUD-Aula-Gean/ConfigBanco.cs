using System;
using System.Data.SQLite;
using System.IO;

namespace CRUD_Aula_Gean
{
    internal class ConfigBanco
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TDE_Gean.db");
        SQLiteConnection conexaoBanco;

        public void VerificarExistenciaBanco()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
        }

        public SQLiteConnection ConectarBanco(SQLiteConnection conexaodb)
        {

                SQLiteConnection conexao = new SQLiteConnection($"Data Source={dbPath}");
                return conexao;
        }

        public void EncerrarConexao(SQLiteConnection conexaoBanco)
        {
            conexaoBanco.Close();
        }

        public string CriarTabelaFuncionarios()
        {
            string sql = "CREATE TABLE IF NOT EXISTS funcionarios (" +
                "funcionario_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "funcionario_nome VARCHAR(80), " +
                "funcionario_cpf VARCHAR(11) UNIQUE, " +
                "funcionario_telefone VARCHAR(14), " +
                "funcionario_data_nascimento VARCHAR(10)" +
                ");"
                ;
            return sql;
        }

        public string CriarTabelaFrentistas()
        {
            string sql = "CREATE TABLE IF NOT EXISTS frentistas (" +
                "frentista_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "frentista_fk_funcionario INTEGER," +
                "FOREIGN KEY (frentista_fk_funcionario) REFERENCES funcionarios(funcionario_id)" +
                ");"
                ;
            return sql;
        }

        public string CriarTabelaCombustivel()
        {
            string sql = "CREATE TABLE IF NOT EXISTS combustivel (" +
                "combustivel_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "tipo_combustivel VARCHAR(50));"             
                ;
            return sql;
        }

        public string CriarTabelaReservatorios()
        {
            string sql = "CREATE TABLE IF NOT EXISTS reservatorio (" +
                "reservatorio_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "reservatorio_fk_combustivel INTEGER," +
                "FOREIGN KEY (reservatorio_fk_combustivel) REFERENCES combustivel(combustivel_id)" +
                ");"
                ;
            return sql;
        }

        public string CriarTabelaBombas()
        {
            string sql = "CREATE TABLE IF NOT EXISTS bombas (" +
                "bomba_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "bomba_tipo_combustivel VARCHAR(30)," +
                "bomba_fk_reservatorio INTEGER," +
                "FOREIGN KEY (bomba_fk_reservatorio) REFERENCES reservatorios(reservatorio_id)" +
                ");"
                ;
            return sql;
        }

        public string CriarTabelaAbastecimentos()
        {
            string sql = "CREATE TABLE IF NOT EXISTS abastecimentos (" +
                "abastecimento_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "abastecimento_valor FLOAT NOT NULL, " +
                "abastecimento_data DATE NOT NULL," +
                "abastecimento_fk_frentista INTEGER," +
                "abastecimento_fk_bomba INTEGER, " +
                "FOREIGN KEY (abastecimento_fk_frentista) REFERENCES frentistas(frentista_id), " +
                "FOREIGN KEY (abastecimento_fk_bomba) REFERENCES bombas(bomba_id)" +
                ");"
                ;
            return sql;
        }

        public void AplicarComandoCriarTabela(string sql, SQLiteConnection conexao)
        {
            ConectarBanco(conexao);
            using (var comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            EncerrarConexao(conexao);
        }
    }
}
