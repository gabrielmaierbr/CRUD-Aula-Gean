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
    public partial class FormRegisBombas : Form
    {
        Combustiveis repo = new Combustiveis();
        ConfigBanco config = new ConfigBanco();

        public FormRegisBombas()
        {
            InitializeComponent();
            CarregarReservatoriosDisponiveis();
        }

        private void CarregarReservatoriosDisponiveis()
        {
            DataTable dt = repo.ListarReservatoriosLivres();

            dt.Columns.Add("Display", typeof(string), "'Reservatório ' + reservatorio_id + ' (' + tipo_combustivel + ')'");

            cmbReservatorios.DataSource = dt;
            cmbReservatorios.DisplayMember = "Display";
            cmbReservatorios.ValueMember = "reservatorio_id";
            cmbReservatorios.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReservatorios.SelectedValue != null)
                {
                    DataRowView row = (DataRowView)cmbReservatorios.SelectedItem;
                    string tipoCombustivel = row["tipo_combustivel"].ToString();
                    int idReservatorio = Convert.ToInt32(cmbReservatorios.SelectedValue);

                    repo.SalvarBomba(idReservatorio, tipoCombustivel);

                    MessageBox.Show("Bomba registrada e vinculada ao reservatório");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não há reservatórios disponíveis");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar bomba: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
