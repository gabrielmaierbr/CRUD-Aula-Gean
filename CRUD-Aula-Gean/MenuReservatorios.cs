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
    public partial class MenuReservatorios : Form
    {
        public MenuReservatorios()
        {
            InitializeComponent();
        }

        private void btnInspecionar_Click(object sender, EventArgs e)
        {
            FormInspecReservatorios formReservatorios = new FormInspecReservatorios();
            formReservatorios.ShowDialog();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            reservatoriosform exibirReservatorios = new reservatoriosform();
            exibirReservatorios.ShowDialog();
        }
    }
}
