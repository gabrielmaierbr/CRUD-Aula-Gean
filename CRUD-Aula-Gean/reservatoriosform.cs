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
    public partial class reservatoriosform : Form
    {
        Combustiveis repo = new Combustiveis();

        public reservatoriosform()
        {
            InitializeComponent();
            AtualizarGrade();
        }

        private void AtualizarGrade()
        {
            dgvReservatorios.DataSource = repo.ListarReservatorios();

            dgvReservatorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservatorios.ReadOnly = true;
            dgvReservatorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvReservatorios.Columns["ID"] != null)
            {
                dgvReservatorios.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvReservatorios.Columns["ID"].HeaderText = "Nº Reservatório";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvReservatorios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvReservatorios.SelectedRows[0].Cells["ID"].Value);

                var resultado = MessageBox.Show($"Deseja excluir o reservatório nº {id}?", "Atenção", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        repo.ExcluirReservatorio(id);
                        AtualizarGrade();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não é possível excluir: o reservatório pode estar vinculado a uma bomba");
                    }
                }
            }
        }
    }
}
