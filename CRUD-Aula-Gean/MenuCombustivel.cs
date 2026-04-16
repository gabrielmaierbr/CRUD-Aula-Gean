using System;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class MenuCombustivel : Form
    {
        public MenuCombustivel()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastroCombustivel cadastroDeCombustiveis = new FormCadastroCombustivel();
            cadastroDeCombustiveis.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            combustiveisform exibirCombustiveis = new combustiveisform();
            exibirCombustiveis.ShowDialog();
        }
    }
}
