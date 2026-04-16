using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class FormCadastroCombustivel : Form
    {
        private int? _idCombustivel;
        Combustiveis repo = new Combustiveis();

        public FormCadastroCombustivel(int? id = null)
        {
            InitializeComponent();
            _idCombustivel = id;

            if (_idCombustivel != null)
            {
                this.Text = "Atualizar combustivel";
                CarregarDadosParaEdicao();
            }
        }

        private void CarregarDadosParaEdicao()
        {
            ConfigBanco config = new ConfigBanco();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT * FROM combustivel WHERE combustivel_id = @id";
                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", _idCombustivel);
                    conexao.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtTipoCombustivel.Text = dr["tipo_combustivel"].ToString();
                        }
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                repo.SalvarCombustivel(txtTipoCombustivel.Text, _idCombustivel);

                if (_idCombustivel != null)
                    MessageBox.Show("Dados atualizados");
                else
                    MessageBox.Show("Combustível cadastrado");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}