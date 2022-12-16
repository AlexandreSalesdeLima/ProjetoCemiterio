using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoCemiterio.classesBasicas;
using ProjetoCemiterio.persistencia;
using MySql.Data.MySqlClient;
namespace ProjetoCemiterio.GUI
{
    public partial class FormFuneral : Form
    {
        
        public FormFuneral()
        {
            InitializeComponent();
            atualizarGridViewCliente();
            atualizarGridViewFuncionario();
            atualizarGridViewFalecido();
        }

        

        //Funcionario

        public void atualizarGridViewFuncionario()
        {
            MySqlDataReader reder = FuncionarioBD.listarTudoFuncionario();
            DataSet ds1 = FuncionarioBD.getDataSetTabelaFuncionario();
            this.dataGridView1.DataSource = ds1.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[2].Width = 215;
        }

        public void setCamposFuncionario()
        {
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            labelNomeFuncionario.Text = linhaAtual.Cells[2].Value.ToString();
           
        }

        //cliente

        public void atualizarGridViewCliente()
        {
            MySqlDataReader reder = ClienteBD.listarTudoCliente();
            DataSet ds1 = ClienteBD.getDataSetTabelaCliente();
            this.dataGridView2.DataSource = ds1.Tables[0];
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[5].Visible = false;
            this.dataGridView2.Columns[2].Width = 215;
        }

        public void setCamposCliente()
        {
            DataGridViewRow linhaAtualCli = dataGridView2.CurrentRow;
            labelNomeCliente.Text = linhaAtualCli.Cells[2].Value.ToString();
        }

        //falecido

        public void atualizarGridViewFalecido()
        {
            MySqlDataReader reder = FalecidoBD.listarTudoFalecido();
            DataSet ds1 = FalecidoBD.getDataSetTabelaFalecido();
            this.dataGridView3.DataSource = ds1.Tables[0];
            this.dataGridView3.Columns[0].Visible = false;
            //this.dataGridView3.Columns[5].Visible = false;
            this.dataGridView3.Columns[2].Width = 215;
        }

        public void setCamposFalecido()
        {
            DataGridViewRow linhaAtual = dataGridView3.CurrentRow;
            labelNomeFalecido.Text = linhaAtual.Cells[2].Value.ToString();
            labelDataObitoFalecido.Text = linhaAtual.Cells[4].Value.ToString();


        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCamposFuncionario();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCamposCliente();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCamposFalecido();
        }

    }
}
