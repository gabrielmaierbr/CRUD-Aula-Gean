using System;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class combustiveisform : Form
    {
        Combustiveis repo = new Combustiveis();

        public combustiveisform()
        {
            InitializeComponent();
            AtualizarGrade();
        }

        private void AtualizarGrade()
        {
            dgvCombustiveis.DataSource = repo.ListarCombustiveis();
            dgvCombustiveis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCombustiveis.Columns["ID"] != null)
            {
                dgvCombustiveis.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvCombustiveis.ReadOnly = true;
            dgvCombustiveis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCombustiveis.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCombustiveis.SelectedRows[0].Cells["ID"].Value);
                // Abre o cadastro passando o ID para edição
                FormCadastroCombustivel frm = new FormCadastroCombustivel(id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AtualizarGrade();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCombustiveis.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCombustiveis.SelectedRows[0].Cells["ID"].Value);
                var resultado = MessageBox.Show("Excluir este combustível?", "Aviso", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    repo.ExcluirCombustivel(id);
                    AtualizarGrade();
                }
            }
        }
    }
}
