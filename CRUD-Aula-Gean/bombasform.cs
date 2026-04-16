using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class bombasform : Form
    {
        Combustiveis repo = new Combustiveis();

        public bombasform()
        {
            InitializeComponent();
            AtualizarGrade();
        }

        private void AtualizarGrade()
        {
            dgvBombas.DataSource = repo.ListarBombas();

            dgvBombas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBombas.ReadOnly = true;
            dgvBombas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvBombas.Columns["ID"] != null)
            {
                dgvBombas.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvBombas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvBombas.SelectedRows[0].Cells["ID"].Value);

                var resultado = MessageBox.Show($"Deseja remover a Bomba {id}?\nO reservatório vinculado ficará disponível novamente",
                                               "Atenção", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        repo.ExcluirBomba(id);
                        AtualizarGrade();
                        MessageBox.Show("Bomba removida com sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não é possível remover esta bomba pois ela possui registros de abastecimento vinculados");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma bomba para excluir.");
            }
        }
    }
}