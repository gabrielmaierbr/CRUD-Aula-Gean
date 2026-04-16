using System;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class MenuFrentistas : Form
    {
        public MenuFrentistas()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastroFrentista tornarFrentista = new FormCadastroFrentista();
            tornarFrentista.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            frentistasform exibirFrentistas = new frentistasform();
            exibirFrentistas.ShowDialog();
        }
    }
}
