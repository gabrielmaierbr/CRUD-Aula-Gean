using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Aula_Gean
{
    internal class Abastecimentos
    {
        public void SalvarAbastecimento(double valor, string data, int fkFrentista, int fkBomba)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"INSERT INTO abastecimentos 
                       (abastecimento_valor, abastecimento_data, abastecimento_fk_frentista, abastecimento_fk_bomba) 
                       VALUES (@valor, @data, @frentista, @bomba)";

                using (var cmd = new System.Data.SQLite.SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@frentista", fkFrentista);
                    cmd.Parameters.AddWithValue("@bomba", fkBomba);

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarAbastecimentosCompletos()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"
            SELECT 
                a.abastecimento_id AS [ID],
                a.abastecimento_data AS [Data],
                func.funcionario_nome AS [Frentista],
                b.bomba_tipo_combustivel AS [Combustível],
                b.bomba_id AS [Nº Bomba],
                r.reservatorio_id AS [Nº Reservatório],
                'R$ ' || PRINTF('%.2f', a.abastecimento_valor) AS [Valor]
            FROM abastecimentos a
            INNER JOIN frentistas f ON a.abastecimento_fk_frentista = f.frentista_id
            INNER JOIN funcionarios func ON f.frentista_fk_funcionario = func.funcionario_id
            INNER JOIN bombas b ON a.abastecimento_fk_bomba = b.bomba_id
            INNER JOIN reservatorio r ON b.bomba_fk_reservatorio = r.reservatorio_id";

                System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
