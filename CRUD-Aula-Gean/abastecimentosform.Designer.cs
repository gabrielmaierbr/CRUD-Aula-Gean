namespace CRUD_Aula_Gean
{
    partial class abastecimentosform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAbastecimentos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRelatorios = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbastecimentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAbastecimentos
            // 
            this.dgvAbastecimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbastecimentos.Location = new System.Drawing.Point(12, 12);
            this.dgvAbastecimentos.Name = "dgvAbastecimentos";
            this.dgvAbastecimentos.Size = new System.Drawing.Size(776, 426);
            this.dgvAbastecimentos.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selecione o Relatório";
            // 
            // cmbRelatorios
            // 
            this.cmbRelatorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRelatorios.FormattingEnabled = true;
            this.cmbRelatorios.Location = new System.Drawing.Point(12, 458);
            this.cmbRelatorios.Name = "cmbRelatorios";
            this.cmbRelatorios.Size = new System.Drawing.Size(381, 21);
            this.cmbRelatorios.TabIndex = 9;
            // 
            // abastecimentosform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.cmbRelatorios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAbastecimentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "abastecimentosform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exibição de Abastecimentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbastecimentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAbastecimentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRelatorios;
    }
}