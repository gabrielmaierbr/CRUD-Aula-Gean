using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class abastecimentosform : Form
    {
        Abastecimentos repo = new Abastecimentos();

        public abastecimentosform()
        {
            InitializeComponent();
            ConfigurarGrade();
            AtualizarGrade();
        }

        private void ConfigurarGrade()
        {
            dgvAbastecimentos.ReadOnly = true;
            dgvAbastecimentos.AllowUserToAddRows = false;
            dgvAbastecimentos.AllowUserToDeleteRows = false;
            dgvAbastecimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbastecimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAbastecimentos.RowHeadersVisible = false;
        }

        private void AtualizarGrade()
        {
            dgvAbastecimentos.DataSource = repo.ListarAbastecimentosCompletos();

            if (dgvAbastecimentos.Columns["ID"] != null)
                dgvAbastecimentos.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvAbastecimentos.Columns["Valor"] != null)
                dgvAbastecimentos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}