using System;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class frentistasform : Form
    {
        Funcionarios repo = new Funcionarios();

        public frentistasform()
        {
            InitializeComponent();
            AtualizarGrade();
        }

        private void AtualizarGrade()
        {
            dgvFrentistas.DataSource = repo.ListarFrentistas();

            dgvFrentistas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvFrentistas.Columns["ID"] != null)
            {
                dgvFrentistas.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvFrentistas.ReadOnly = true;
            dgvFrentistas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFrentistas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvFrentistas.SelectedRows[0].Cells["ID"].Value);

                var resultado = MessageBox.Show("Deseja remover este funcionário do cargo de frentista?", "Atenção", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    repo.DesassociarFrentista(id);
                    AtualizarGrade();
                    MessageBox.Show("Frentista desassociado");
                }
            }
        }
    }
}