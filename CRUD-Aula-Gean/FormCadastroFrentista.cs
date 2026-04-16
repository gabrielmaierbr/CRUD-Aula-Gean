using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class FormCadastroFrentista : Form
    {
        ConfigBanco config = new ConfigBanco();

        public FormCadastroFrentista()
        {
            InitializeComponent();
            CarregarFuncionariosDisponiveis();
        }

        private void CarregarFuncionariosDisponiveis()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT funcionario_id, funcionario_nome 
                           FROM funcionarios 
                           WHERE funcionario_id NOT IN (SELECT frentista_fk_funcionario FROM frentistas)";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }

            cmbFuncionarios.DataSource = dt;
            cmbFuncionarios.DisplayMember = "funcionario_nome";
            cmbFuncionarios.ValueMember = "funcionario_id";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbFuncionarios.SelectedValue != null)
            {
                int idFuncionario = Convert.ToInt32(cmbFuncionarios.SelectedValue);
                SalvarFrentista(idFuncionario);
            }
        }

        private void SalvarFrentista(int idFunc)
        {
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "INSERT INTO frentistas (frentista_fk_funcionario) VALUES (@idFunc)";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idFunc", idFunc);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Frentista associado");
            this.Close();
        }

        private void FormCadastroFrentista_Load(object sender, EventArgs e)
        {
            cmbFuncionarios.SelectedIndex = -1;
        }
    }
}
