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
    public partial class MenuBombas : Form
    {
        public MenuBombas()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FormRegisBombas formRegisBombas = new FormRegisBombas();
            formRegisBombas.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            bombasform exibirBombas = new bombasform();
            exibirBombas.ShowDialog();
        }
    }
}
