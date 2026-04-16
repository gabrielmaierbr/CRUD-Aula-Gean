using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class FormCadastroFuncionario : Form
    {
        Funcionarios repo = new Funcionarios();
        private int? _idFuncionario;
        public FormCadastroFuncionario(int? id = null)
        {
            InitializeComponent();
            _idFuncionario = id;

            if (_idFuncionario != null)
            {
                this.Text = "Atualizar dados";
                CarregarDadosParaEdicao();
            }
            else
            {
                this.Text = "Cadastrar Funcionário";
            }
        }

        private void CarregarDadosParaEdicao()
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT * FROM funcionarios WHERE funcionario_id = @id";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", _idFuncionario);
                    conexao.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtNome.Text = dr["funcionario_nome"].ToString();
                            txtCPF.Text = dr["funcionario_cpf"].ToString();
                            txtTelefone.Text = dr["funcionario_telefone"].ToString();
                            txtDataNasc.Text = dr["funcionario_data_nascimento"].ToString();
                        }
                    }
                }
                config.EncerrarConexao(conexao);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                repo.Salvar(
                    txtNome.Text,
                    txtCPF.Text,
                    txtTelefone.Text,
                    txtDataNasc.Text,
                    _idFuncionario
                );

                if (_idFuncionario != null)
                {
                    MessageBox.Show("Alterações salvas");
                }
                else
                {
                    MessageBox.Show("Funcionário cadastrado");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
