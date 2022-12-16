namespace ProjetoCemiterio.GUI
{
    partial class FormServico
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxValorServico = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCadastrarServico = new System.Windows.Forms.Button();
            this.buttonAlterarServico = new System.Windows.Forms.Button();
            this.buttonExcluirServico = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIdServico = new System.Windows.Forms.Label();
            this.comboBoxTipoServico = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor:";
            // 
            // textBoxValorServico
            // 
            this.textBoxValorServico.Location = new System.Drawing.Point(49, 43);
            this.textBoxValorServico.Name = "textBoxValorServico";
            this.textBoxValorServico.Size = new System.Drawing.Size(100, 20);
            this.textBoxValorServico.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(338, 200);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonCadastrarServico
            // 
            this.buttonCadastrarServico.Location = new System.Drawing.Point(15, 92);
            this.buttonCadastrarServico.Name = "buttonCadastrarServico";
            this.buttonCadastrarServico.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarServico.TabIndex = 8;
            this.buttonCadastrarServico.Text = "Cadastrar";
            this.buttonCadastrarServico.UseVisualStyleBackColor = true;
            this.buttonCadastrarServico.Click += new System.EventHandler(this.buttonCadastrarServico_Click);
            // 
            // buttonAlterarServico
            // 
            this.buttonAlterarServico.Location = new System.Drawing.Point(106, 92);
            this.buttonAlterarServico.Name = "buttonAlterarServico";
            this.buttonAlterarServico.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterarServico.TabIndex = 9;
            this.buttonAlterarServico.Text = "Alterar";
            this.buttonAlterarServico.UseVisualStyleBackColor = true;
            this.buttonAlterarServico.Click += new System.EventHandler(this.buttonAlterarServico_Click);
            // 
            // buttonExcluirServico
            // 
            this.buttonExcluirServico.Location = new System.Drawing.Point(196, 92);
            this.buttonExcluirServico.Name = "buttonExcluirServico";
            this.buttonExcluirServico.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluirServico.TabIndex = 10;
            this.buttonExcluirServico.Text = "Excluir";
            this.buttonExcluirServico.UseVisualStyleBackColor = true;
            this.buttonExcluirServico.Click += new System.EventHandler(this.buttonExcluirServico_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Id:";
            // 
            // labelIdServico
            // 
            this.labelIdServico.AutoSize = true;
            this.labelIdServico.Location = new System.Drawing.Point(293, 14);
            this.labelIdServico.Name = "labelIdServico";
            this.labelIdServico.Size = new System.Drawing.Size(0, 13);
            this.labelIdServico.TabIndex = 12;
            // 
            // comboBoxTipoServico
            // 
            this.comboBoxTipoServico.FormattingEnabled = true;
            this.comboBoxTipoServico.Items.AddRange(new object[] {
            "Limpar Catatumba",
            "Cavar Cova",
            "Reconstrução da Catatumba",
            "Limpeza de Ossos",
            "Cremação"});
            this.comboBoxTipoServico.Location = new System.Drawing.Point(49, 6);
            this.comboBoxTipoServico.Name = "comboBoxTipoServico";
            this.comboBoxTipoServico.Size = new System.Drawing.Size(144, 21);
            this.comboBoxTipoServico.TabIndex = 13;
            // 
            // FormServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 333);
            this.Controls.Add(this.comboBoxTipoServico);
            this.Controls.Add(this.labelIdServico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonExcluirServico);
            this.Controls.Add(this.buttonAlterarServico);
            this.Controls.Add(this.buttonCadastrarServico);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxValorServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormServico";
            this.Text = "FormServico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxValorServico;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCadastrarServico;
        private System.Windows.Forms.Button buttonAlterarServico;
        private System.Windows.Forms.Button buttonExcluirServico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIdServico;
        private System.Windows.Forms.ComboBox comboBoxTipoServico;
    }
}