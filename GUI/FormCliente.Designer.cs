namespace ProjetoCemiterio.GUI
{
    partial class FormCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliente));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRemov = new System.Windows.Forms.Button();
            this.buttonAtual = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxCpfCli = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBoxTelefoneCli = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNomeCli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEnderecoCli = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelIdCli = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(612, 163);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // label5
            // 
            this.label5.Image = global::ProjetoCemiterio.Properties.Resources.Group_icon;
            this.label5.Location = new System.Drawing.Point(493, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 94);
            this.label5.TabIndex = 41;
            // 
            // buttonRemov
            // 
            this.buttonRemov.Image = global::ProjetoCemiterio.Properties.Resources.Remove_icon;
            this.buttonRemov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemov.Location = new System.Drawing.Point(491, 112);
            this.buttonRemov.Name = "buttonRemov";
            this.buttonRemov.Size = new System.Drawing.Size(87, 34);
            this.buttonRemov.TabIndex = 39;
            this.buttonRemov.Text = "Remover";
            this.buttonRemov.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRemov.UseVisualStyleBackColor = true;
            this.buttonRemov.Click += new System.EventHandler(this.buttonRemov_Click);
            // 
            // buttonAtual
            // 
            this.buttonAtual.Image = global::ProjetoCemiterio.Properties.Resources.Button_Refresh_icon;
            this.buttonAtual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtual.Location = new System.Drawing.Point(410, 111);
            this.buttonAtual.Name = "buttonAtual";
            this.buttonAtual.Size = new System.Drawing.Size(75, 35);
            this.buttonAtual.TabIndex = 38;
            this.buttonAtual.Text = "Alterar";
            this.buttonAtual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAtual.UseVisualStyleBackColor = true;
            this.buttonAtual.Click += new System.EventHandler(this.buttonAtual_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::ProjetoCemiterio.Properties.Resources.Add_icon;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(321, 111);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(82, 35);
            this.buttonAdd.TabIndex = 37;
            this.buttonAdd.Text = "Adicionar";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cpf:";
            // 
            // maskedTextBoxCpfCli
            // 
            this.maskedTextBoxCpfCli.Location = new System.Drawing.Point(55, 16);
            this.maskedTextBoxCpfCli.Mask = "000,000,000-00";
            this.maskedTextBoxCpfCli.Name = "maskedTextBoxCpfCli";
            this.maskedTextBoxCpfCli.Size = new System.Drawing.Size(90, 20);
            this.maskedTextBoxCpfCli.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Telefone:";
            // 
            // maskedTextBoxTelefoneCli
            // 
            this.maskedTextBoxTelefoneCli.Location = new System.Drawing.Point(70, 101);
            this.maskedTextBoxTelefoneCli.Mask = "(999) 000-0000";
            this.maskedTextBoxTelefoneCli.Name = "maskedTextBoxTelefoneCli";
            this.maskedTextBoxTelefoneCli.Size = new System.Drawing.Size(90, 20);
            this.maskedTextBoxTelefoneCli.TabIndex = 25;
            // 
            // textBoxNomeCli
            // 
            this.textBoxNomeCli.Location = new System.Drawing.Point(55, 44);
            this.textBoxNomeCli.Name = "textBoxNomeCli";
            this.textBoxNomeCli.Size = new System.Drawing.Size(158, 20);
            this.textBoxNomeCli.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Endereço:";
            // 
            // textBoxEnderecoCli
            // 
            this.textBoxEnderecoCli.Location = new System.Drawing.Point(66, 75);
            this.textBoxEnderecoCli.Name = "textBoxEnderecoCli";
            this.textBoxEnderecoCli.Size = new System.Drawing.Size(206, 20);
            this.textBoxEnderecoCli.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIdCli);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxEnderecoCli);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNomeCli);
            this.groupBox1.Controls.Add(this.maskedTextBoxTelefoneCli);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maskedTextBoxCpfCli);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 134);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Cliente";
            // 
            // labelIdCli
            // 
            this.labelIdCli.AutoSize = true;
            this.labelIdCli.Location = new System.Drawing.Point(191, 19);
            this.labelIdCli.Name = "labelIdCli";
            this.labelIdCli.Size = new System.Drawing.Size(0, 13);
            this.labelIdCli.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "ID:";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 351);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRemov);
            this.Controls.Add(this.buttonAtual);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCliente";
            this.Text = "FormCliente";
      
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRemov;
        private System.Windows.Forms.Button buttonAtual;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCpfCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefoneCli;
        private System.Windows.Forms.TextBox textBoxNomeCli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEnderecoCli;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelIdCli;
    }
}