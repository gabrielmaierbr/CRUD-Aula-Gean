namespace CRUD_Aula_Gean
{
    partial class main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFuncionarios = new System.Windows.Forms.Button();
            this.btnFrentistas = new System.Windows.Forms.Button();
            this.btnCombustiveis = new System.Windows.Forms.Button();
            this.btnReservatorios = new System.Windows.Forms.Button();
            this.btnBombas = new System.Windows.Forms.Button();
            this.btnAbastecimentos = new System.Windows.Forms.Button();
            this.btnGrupo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFuncionarios
            // 
            this.btnFuncionarios.Location = new System.Drawing.Point(59, 37);
            this.btnFuncionarios.Name = "btnFuncionarios";
            this.btnFuncionarios.Size = new System.Drawing.Size(139, 56);
            this.btnFuncionarios.TabIndex = 0;
            this.btnFuncionarios.Text = "Funcionários";
            this.btnFuncionarios.UseVisualStyleBackColor = true;
            this.btnFuncionarios.Click += new System.EventHandler(this.btnFuncionarios_Click);
            // 
            // btnFrentistas
            // 
            this.btnFrentistas.Location = new System.Drawing.Point(204, 37);
            this.btnFrentistas.Name = "btnFrentistas";
            this.btnFrentistas.Size = new System.Drawing.Size(139, 56);
            this.btnFrentistas.TabIndex = 1;
            this.btnFrentistas.Text = "Frentistas";
            this.btnFrentistas.UseVisualStyleBackColor = true;
            this.btnFrentistas.Click += new System.EventHandler(this.btnFrentistas_Click);
            // 
            // btnCombustiveis
            // 
            this.btnCombustiveis.Location = new System.Drawing.Point(59, 99);
            this.btnCombustiveis.Name = "btnCombustiveis";
            this.btnCombustiveis.Size = new System.Drawing.Size(139, 56);
            this.btnCombustiveis.TabIndex = 2;
            this.btnCombustiveis.Text = "Combustíveis";
            this.btnCombustiveis.UseVisualStyleBackColor = true;
            this.btnCombustiveis.Click += new System.EventHandler(this.btnCombustiveis_Click);
            // 
            // btnReservatorios
            // 
            this.btnReservatorios.Location = new System.Drawing.Point(204, 99);
            this.btnReservatorios.Name = "btnReservatorios";
            this.btnReservatorios.Size = new System.Drawing.Size(139, 56);
            this.btnReservatorios.TabIndex = 3;
            this.btnReservatorios.Text = "Reservatórios";
            this.btnReservatorios.UseVisualStyleBackColor = true;
            this.btnReservatorios.Click += new System.EventHandler(this.btnReservatorios_Click);
            // 
            // btnBombas
            // 
            this.btnBombas.Location = new System.Drawing.Point(59, 161);
            this.btnBombas.Name = "btnBombas";
            this.btnBombas.Size = new System.Drawing.Size(139, 56);
            this.btnBombas.TabIndex = 4;
            this.btnBombas.Text = "Bombas";
            this.btnBombas.UseVisualStyleBackColor = true;
            this.btnBombas.Click += new System.EventHandler(this.btnBombas_Click);
            // 
            // btnAbastecimentos
            // 
            this.btnAbastecimentos.Location = new System.Drawing.Point(204, 161);
            this.btnAbastecimentos.Name = "btnAbastecimentos";
            this.btnAbastecimentos.Size = new System.Drawing.Size(139, 56);
            this.btnAbastecimentos.TabIndex = 5;
            this.btnAbastecimentos.Text = "Abastecimentos";
            this.btnAbastecimentos.UseVisualStyleBackColor = true;
            this.btnAbastecimentos.Click += new System.EventHandler(this.btnAbastecimentos_Click);
            // 
            // btnGrupo
            // 
            this.btnGrupo.Location = new System.Drawing.Point(157, 241);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(89, 37);
            this.btnGrupo.TabIndex = 6;
            this.btnGrupo.Text = "Grupo";
            this.btnGrupo.UseVisualStyleBackColor = true;
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 290);
            this.Controls.Add(this.btnGrupo);
            this.Controls.Add(this.btnAbastecimentos);
            this.Controls.Add(this.btnBombas);
            this.Controls.Add(this.btnReservatorios);
            this.Controls.Add(this.btnCombustiveis);
            this.Controls.Add(this.btnFrentistas);
            this.Controls.Add(this.btnFuncionarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDE Gean - CRUD - Posto de Gasolina";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFuncionarios;
        private System.Windows.Forms.Button btnFrentistas;
        private System.Windows.Forms.Button btnCombustiveis;
        private System.Windows.Forms.Button btnReservatorios;
        private System.Windows.Forms.Button btnBombas;
        private System.Windows.Forms.Button btnAbastecimentos;
        private System.Windows.Forms.Button btnGrupo;
    }
}

