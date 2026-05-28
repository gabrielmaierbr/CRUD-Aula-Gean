using System;
using System.Data;
using System.Data.SQLite;

namespace CRUD_Aula_Gean
{
    internal class AbastecimentosRelatorios
    {
        private ConfigBanco config = new ConfigBanco();

        private string GetBaseSelect()
        {
            return @"SELECT 
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
        }

        public DataTable FiltrarPorValorMaiorQue(double valorMinimo)
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " WHERE a.abastecimento_valor > @valor";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@valor", valorMinimo);
                    new SQLiteDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public DataTable FiltrarPorFrentista(int idFrentista)
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " WHERE f.frentista_id = @idFrentista";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idFrentista", idFrentista);
                    new SQLiteDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public DataTable FiltrarPorHoje()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " WHERE a.abastecimento_data = date('now')";
                new SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            return dt;
        }

        public DataTable FiltrarPorTipoCombustivel(string tipo)
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " WHERE b.bomba_tipo_combustivel LIKE @tipo";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", "%" + tipo + "%");
                    new SQLiteDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public DataTable FiltrarPorIntervaloDeValores(double minimo, double maximo)
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " WHERE a.abastecimento_valor BETWEEN @min AND @max";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@min", minimo);
                    cmd.Parameters.AddWithValue("@max", maximo);
                    new SQLiteDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public DataTable TotalFaturadoPorFrentista()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT 
                                    func.funcionario_nome AS [Frentista],
                                    COUNT(a.abastecimento_id) AS [Total Vendas],
                                    'R$ ' || PRINTF('%.2f', SUM(a.abastecimento_valor)) AS [Faturamento Total]
                               FROM abastecimentos a
                               INNER JOIN frentistas f ON a.abastecimento_fk_frentista = f.frentista_id
                               INNER JOIN funcionarios func ON f.frentista_fk_funcionario = func.funcionario_id
                               GROUP BY func.funcionario_nome
                               ORDER BY SUM(a.abastecimento_valor) DESC";
                new SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            return dt;
        }

        public DataTable TotalVendasPorReservatorio()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT 
                                    r.reservatorio_id AS [Nº Reservatório],
                                    b.bomba_tipo_combustivel AS [Combustível],
                                    COUNT(a.abastecimento_id) AS [Quantidade Abastecimentos],
                                    'R$ ' || PRINTF('%.2f', SUM(a.abastecimento_valor)) AS [Total Retirado]
                               FROM abastecimentos a
                               INNER JOIN bombas b ON a.abastecimento_fk_bomba = b.bomba_id
                               INNER JOIN reservatorio r ON b.bomba_fk_reservatorio = r.reservatorio_id
                               GROUP BY r.reservatorio_id";
                new SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            return dt;
        }

        public DataTable ListarTop5MaisCaros()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = GetBaseSelect() + " ORDER BY a.abastecimento_valor DESC LIMIT 5";
                new SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            return dt;
        }
        public DataTable ObterMetricasGerais()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT 
                                    COUNT(*) AS [Total de Vendas],
                                    'R$ ' || PRINTF('%.2f', AVG(abastecimento_valor)) AS [Média por Venda],
                                    'R$ ' || PRINTF('%.2f', MAX(abastecimento_valor)) AS [Maior Venda],
                                    'R$ ' || PRINTF('%.2f', MIN(abastecimento_valor)) AS [Menor Venda]
                               FROM abastecimentos";
                new SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            return dt;
        }
    }
}