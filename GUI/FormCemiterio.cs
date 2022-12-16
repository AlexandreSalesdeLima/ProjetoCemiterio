using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace ProjetoCemiterio.GUI
{
    public partial class FormCemiterio : Form
    {
        public bool FunAb;

        public FormCemiterio()
        {
            InitializeComponent();
            FunAb = false;
        }

        private void pessoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFuncionario fun = new FormFuncionario();
            fun.MdiParent = this;
            fun.Show();
            FunAb = true;
        }


        private void cadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente cli = new FormCliente();
            cli.ShowDialog();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFuneral fune = new FormFuneral();
            fune.ShowDialog();
        }

        private void falecidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFalecido fale = new FormFalecido();
            fale.ShowDialog();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServico serv = new FormServico();
            serv.ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      }

    }

