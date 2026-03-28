using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ConectarBanco()
        {
            if (conexaoBanco == null)
            {
                SQLiteConnection conexao = new SQLiteConnection($"Data Source={dbPath}");
            }
        }

        public void EncerrarConexao()
        {
            if (conexaoBanco != null)
            {
                conexaoBanco.Close();
                conexaoBanco.Dispose();
            }
        }

        public string CriarTabelaFuncionarios()
        {
            string sql = "CREATE TABLE IF NOT EXISTS funcionarios (" +
                "funcionario_id INTEGER PRIMARY KEY AUTO INCREMENT, " +
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
                "frentista_id INTEGER PRIMARY KEY AUTO INCREMENT, " +
                "FOREIGN KEY (frentista_fk_funcionario) REFERENCES funcionarios(funcionario_id)" +
                ");"
                ;
            return sql;
        }

        public void CriarTabelaReservatorios()
        {

        }

        public string CriarTabelaBombas()
        {
            string sql = "CREATE TABLE IF NOT EXISTS bombas (" +
                "bomba_id INTEGER PRIMARY KEY AUTO INCREMENT, " +
                "bomba_tipo_combustivel VARCHAR(30)," +
                "FOREIGN KEY (bomba_fk_reservatorio) REFERENCES reservatorios(reservatorio_id)" +
                ");"
                ;
            return sql;
        }

        public string CriarTabelaAbastecimentos()
        {
            string sql = "CREATE TABLE IF NOT EXISTS abastecimentos (" +
                "abastecimento_id INTEGER PRIMARY KEY AUTO INCREMENT, " +
                "abastecimento_valor FLOAT NOT NULL, " +
                "abastecimento_data DATE NOT NULL, " +
                "FOREIGN KEY (abastecimento_fk_frentista) REFERENCES frentistas(frentista_id), " +
                "FOREIGN KEY (abastecimento_fk_bomba) REFERENCES bombas(bomba_id)" +
                ");"
                ;
            return sql;
        }

        public void AplicarComandoCriarTabela(string sql, SQLiteConnection conexao)
        {
            ConectarBanco();
            using (var comando = new SQLiteCommand(sql, conexao))
            {
                comando.ExecuteNonQuery();
            }
            EncerrarConexao();
        }
    }
}
