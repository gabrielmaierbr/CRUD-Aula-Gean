using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace CRUD_Aula_Gean
{
    public partial class main : Form
    {

        ConfigBanco configurar = new ConfigBanco();
        SQLiteConnection conexao = new SQLiteConnection();
        

        public main()
        {
            InitializeComponent();
            conexao = configurar.ConectarBanco(conexao);
            configurar.VerificarExistenciaBanco();
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaFuncionarios(), conexao);
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaFrentistas(), conexao);
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaCombustivel(), conexao);
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaReservatorios(), conexao);
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaBombas(), conexao);
            configurar.AplicarComandoCriarTabela(configurar.CriarTabelaAbastecimentos(), conexao);
        }

        private void main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            MenuFuncionarios funcionariosForm = new MenuFuncionarios();
            funcionariosForm.ShowDialog();
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Matheus Marques\n" + 
                "Kaique Mendes\n" +
                "Gabriel Maier\n" +
                "Mattia Poletto", "Grupo do Trabalho", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuFrentistas frentistasForm = new MenuFrentistas();
            frentistasForm.ShowDialog();
        }
    }
}
