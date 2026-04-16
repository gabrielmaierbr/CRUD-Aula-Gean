using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class FormInspecReservatorios : Form
    {
        Combustiveis repo = new Combustiveis();
        ConfigBanco config = new ConfigBanco();

        public FormInspecReservatorios()
        {
            InitializeComponent();
            CarregarCombustiveis();
        }

        private void CarregarCombustiveis()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT combustivel_id, tipo_combustivel FROM combustivel";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conexao);
                da.Fill(dt);
            }

            cmbCombustivel.DataSource = dt;
            cmbCombustivel.DisplayMember = "tipo_combustivel";
            cmbCombustivel.ValueMember = "combustivel_id";
            cmbCombustivel.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCombustivel.SelectedValue != null)
                {
                    int idComb = Convert.ToInt32(cmbCombustivel.SelectedValue);
                    repo.SalvarReservatorio(idComb);

                    MessageBox.Show("Reservatório associado");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecione um combustível");
                }
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

        private void FormInspecReservatorios_Load(object sender, EventArgs e)
        {
            cmbCombustivel.SelectedIndex = -1;
        }
    }
}