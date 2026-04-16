using System.Data;
using System.Data.SQLite;

namespace CRUD_Aula_Gean
{
    internal class Funcionarios
    {
        ConfigBanco config = new ConfigBanco();

        public DataTable ListarTodos()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT funcionario_id AS ID, funcionario_nome AS Nome, funcionario_cpf AS CPF FROM funcionarios";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conexao);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable ListarFrentistas()
        {
            DataTable dt = new DataTable();
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT f.frentista_id AS ID, func.funcionario_nome AS Nome, func.funcionario_cpf AS CPF 
                       FROM frentistas f
                       INNER JOIN funcionarios func ON f.frentista_fk_funcionario = func.funcionario_id";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }
            return dt;
        }

        public void DesassociarFrentista(int idFrentista)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "DELETE FROM frentistas WHERE frentista_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", idFrentista);
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "DELETE FROM funcionarios WHERE funcionario_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Salvar(string nome, string cpf, string telefone, string dataNasc, int? id = null)
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                conexao.Open();
                string sql;

                if (id == null)
                    sql = "INSERT INTO funcionarios (funcionario_nome, funcionario_cpf, funcionario_telefone, funcionario_data_nascimento) VALUES (@nome, @cpf, @tel, @data)";
                else
                    sql = "UPDATE funcionarios SET funcionario_nome=@nome, funcionario_cpf=@cpf, funcionario_telefone=@tel, funcionario_data_nascimento=@data WHERE funcionario_id=@id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@tel", telefone);
                    cmd.Parameters.AddWithValue("@data", dataNasc);
                    if (id != null) cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}