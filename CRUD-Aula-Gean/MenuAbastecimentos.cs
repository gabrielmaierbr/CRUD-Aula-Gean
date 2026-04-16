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
    public partial class MenuAbastecimentos : Form
    {
        public MenuAbastecimentos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FormRegistroAbastecimento registroForm = new FormRegistroAbastecimento();
            registroForm.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            abastecimentosform exibirAbastecimentos = new abastecimentosform();
            exibirAbastecimentos.ShowDialog();
        }
    }
}
