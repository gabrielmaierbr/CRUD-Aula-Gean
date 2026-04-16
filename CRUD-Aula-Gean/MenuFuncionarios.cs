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
    public partial class MenuFuncionarios : Form
    {
        public MenuFuncionarios()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastroFuncionario cadastro = new FormCadastroFuncionario();
            cadastro.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            funcionariosform exibirFuncionarios = new funcionariosform();
            exibirFuncionarios.ShowDialog();
        }
    }
}
