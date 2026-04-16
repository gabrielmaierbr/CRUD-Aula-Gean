using System;
using System.Data.SQLite;
using System.Windows.Forms;

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

        private void btnFrentistas_Click(object sender, EventArgs e)
        {
            MenuFrentistas frentistasForm = new MenuFrentistas();
            frentistasForm.ShowDialog();
        }

        private void btnCombustiveis_Click(object sender, EventArgs e)
        {
            MenuCombustivel combustiveisForm = new MenuCombustivel();
            combustiveisForm.ShowDialog();
        }

        private void btnReservatorios_Click(object sender, EventArgs e)
        {
            MenuReservatorios reservatoriosForm = new MenuReservatorios();
            reservatoriosForm.ShowDialog();
        }

        private void btnBombas_Click(object sender, EventArgs e)
        {
            MenuBombas bombasForm = new MenuBombas();
            bombasForm.ShowDialog();
        }

        private void btnAbastecimentos_Click(object sender, EventArgs e)
        {
            MenuAbastecimentos abastecimentosForm = new MenuAbastecimentos();
            abastecimentosForm.ShowDialog();
        }
    }
}
