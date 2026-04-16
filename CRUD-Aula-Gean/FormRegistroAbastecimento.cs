using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class FormRegistroAbastecimento : Form
    {
        Abastecimentos repo = new Abastecimentos();
        ConfigBanco config = new ConfigBanco();

        public FormRegistroAbastecimento()
        {
            InitializeComponent();
            CarregarFrentistas();
            CarregarBombas();
        }

        private void CarregarFrentistas()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = @"SELECT f.frentista_id, func.funcionario_nome 
                           FROM frentistas f
                           INNER JOIN funcionarios func ON f.frentista_fk_funcionario = func.funcionario_id";
                new System.Data.SQLite.SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            cmbFrentistas.DataSource = dt;
            cmbFrentistas.DisplayMember = "funcionario_nome";
            cmbFrentistas.ValueMember = "frentista_id";
        }

        private void CarregarBombas()
        {
            DataTable dt = new DataTable();
            using (var conexao = config.ConectarBanco(null))
            {
                string sql = "SELECT bomba_id, bomba_tipo_combustivel FROM bombas";
                new System.Data.SQLite.SQLiteDataAdapter(sql, conexao).Fill(dt);
            }
            dt.Columns.Add("DisplayBomba", typeof(string), "'Bomba ' + bomba_id + ' (' + bomba_tipo_combustivel + ')'");

            cmbBombas.DataSource = dt;
            cmbBombas.DisplayMember = "DisplayBomba";
            cmbBombas.ValueMember = "bomba_id";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtValor.Text) || cmbFrentistas.SelectedValue == null || cmbBombas.SelectedValue == null)
                {
                    MessageBox.Show("Preencha todos os campos");
                    return;
                }

                double valor = Convert.ToDouble(txtValor.Text);
                string data = dtpData.Value.ToString("yyyy-MM-dd");
                int idFrentista = Convert.ToInt32(cmbFrentistas.SelectedValue);
                int idBomba = Convert.ToInt32(cmbBombas.SelectedValue);

                repo.SalvarAbastecimento(valor, data, idFrentista, idBomba);

                MessageBox.Show("Venda registrada com sucesso");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar: " + ex.Message);
            }
        }

        private void FormRegistroAbastecimento_Load(object sender, EventArgs e)
        {
            cmbFrentistas.SelectedIndex = -1;
            cmbBombas.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
