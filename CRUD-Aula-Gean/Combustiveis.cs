using System.Data;
using System.Data.SQLite;

namespace CRUD_Aula_Gean
{
    internal class Combustiveis
    {
        public void SalvarCombustivel(string tipo, int? id = null)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                conexao.Open();
                string sql;

                if (id == null)
                    sql = "INSERT INTO combustivel (tipo_combustivel) VALUES (@tipo)";
                else
                    sql = "UPDATE combustivel SET tipo_combustivel = @tipo WHERE combustivel_id = @id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    if (id != null) cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarCombustiveis()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT combustivel_id AS ID, tipo_combustivel AS Tipo FROM combustivel";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }

        public void ExcluirCombustivel(int id)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "DELETE FROM combustivel WHERE combustivel_id = @id";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarReservatorios()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT r.reservatorio_id AS ID, c.tipo_combustivel AS Combustivel 
                       FROM reservatorio r
                       INNER JOIN combustivel c ON r.reservatorio_fk_combustivel = c.combustivel_id";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }

        public void ExcluirReservatorio(int id)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "DELETE FROM reservatorio WHERE reservatorio_id = @id";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SalvarReservatorio(int idCombustivel)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "INSERT INTO reservatorio (reservatorio_fk_combustivel) VALUES (@idComb)";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idComb", idCombustivel);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ListarReservatoriosLivres()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT r.reservatorio_id, c.tipo_combustivel 
                       FROM reservatorio r
                       INNER JOIN combustivel c ON r.reservatorio_fk_combustivel = c.combustivel_id
                       WHERE r.reservatorio_id NOT IN (SELECT bomba_fk_reservatorio FROM bombas)";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }

        public void SalvarBomba(int idReservatorio, string tipoCombustivel)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "INSERT INTO bombas (bomba_tipo_combustivel, bomba_fk_reservatorio) VALUES (@tipo, @fk)";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoCombustivel);
                    cmd.Parameters.AddWithValue("@fk", idReservatorio);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarBombas()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT b.bomba_id AS ID, 
                              b.bomba_tipo_combustivel AS Combustivel, 
                              b.bomba_fk_reservatorio AS [Nº Reservatório]
                       FROM bombas b";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }

        public void ExcluirBomba(int id)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "DELETE FROM bombas WHERE bomba_id = @id";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
