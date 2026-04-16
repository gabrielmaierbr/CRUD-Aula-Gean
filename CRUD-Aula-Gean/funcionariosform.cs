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
    public partial class funcionariosform : Form
    {
        Funcionarios repo = new Funcionarios();

        public funcionariosform()
        {
            InitializeComponent();
            AtualizarGrade();
        }

        private void AtualizarGrade()
        {
            dgvFuncionarios.DataSource = repo.ListarTodos();

            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvFuncionarios.Columns["ID"] != null)
            {
                dgvFuncionarios.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvFuncionarios.SelectedRows[0].Cells["ID"].Value);

                var resultado = MessageBox.Show("Deseja excluir este registro?", "Atenção", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    repo.Excluir(id);
                    AtualizarGrade();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvFuncionarios.SelectedRows[0].Cells["ID"].Value);

                FormCadastroFuncionario frm = new FormCadastroFuncionario(id);
                frm.ShowDialog();
                AtualizarGrade();
            }
        }
    }
}
