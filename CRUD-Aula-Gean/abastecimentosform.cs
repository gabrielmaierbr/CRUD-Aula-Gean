using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Aula_Gean
{
    public partial class abastecimentosform : Form
    {
        AbastecimentosRelatorios repoRelatorios = new AbastecimentosRelatorios();
        Abastecimentos repo = new Abastecimentos();

        public abastecimentosform()
        {
            InitializeComponent();
            ConfigurarGrade();
            CriarListaDeRelatorios();
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

        private void CriarListaDeRelatorios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NomeRelatorio", typeof(string));

            dt.Rows.Add(0, "Todos os Abastecimentos (Padrão)");
            dt.Rows.Add(1, "Abastecimentos acima de R$ 280,00");
            dt.Rows.Add(2, "Abastecimentos de Hoje");
            dt.Rows.Add(3, "Filtrar por Combustível: Gasolina");
            dt.Rows.Add(4, "Filtrar por Combustível: Diesel");
            dt.Rows.Add(5, "Filtrar por Combustível: Álcool");
            dt.Rows.Add(6, "Valores entre R$ 50,00 e R$ 150,00");
            dt.Rows.Add(7, "Faturamento Total por Frentista");
            dt.Rows.Add(8, "Total Retirado por Reservatório");
            dt.Rows.Add(9, "Top 5 Abastecimentos mais Caros");
            dt.Rows.Add(10, "Métricas e Estatísticas Gerais");

            cmbRelatorios.DataSource = dt;
            cmbRelatorios.DisplayMember = "NomeRelatorio";
            cmbRelatorios.ValueMember = "Id";

            cmbRelatorios.SelectedIndexChanged += cmbRelatorios_SelectedIndexChanged;

            AtualizarGradePorRelatorio(0);
        }

        private void cmbRelatorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRelatorios.SelectedValue != null)
            {
                int idRelatorio = Convert.ToInt32(cmbRelatorios.SelectedValue);
                AtualizarGradePorRelatorio(idRelatorio);
            }
        }

        private void AtualizarGradePorRelatorio(int idRelatorio)
        {
            try
            {
                switch (idRelatorio)
                {
                    case 0:
                        dgvAbastecimentos.DataSource = repo.ListarAbastecimentosCompletos();
                        break;
                    case 1:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorValorMaiorQue(280.00);
                        break;
                    case 2:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorHoje();
                        break;
                    case 3:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorTipoCombustivel("Gasolina");
                        break;
                    case 4:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorTipoCombustivel("Diesel");
                        break;
                    case 5:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorTipoCombustivel("Alcool");
                        break;
                    case 6:
                        dgvAbastecimentos.DataSource = repoRelatorios.FiltrarPorIntervaloDeValores(50.00, 150.00);
                        break;
                    case 7:
                        dgvAbastecimentos.DataSource = repoRelatorios.TotalFaturadoPorFrentista();
                        break;
                    case 8:
                        dgvAbastecimentos.DataSource = repoRelatorios.TotalVendasPorReservatorio();
                        break;
                    case 9:
                        dgvAbastecimentos.DataSource = repoRelatorios.ListarTop5MaisCaros();
                        break;
                    case 10:
                        dgvAbastecimentos.DataSource = repoRelatorios.ObterMetricasGerais();
                        break;
                }

                if (dgvAbastecimentos.Columns["Valor"] != null)
                    dgvAbastecimentos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar relatório: " + ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}