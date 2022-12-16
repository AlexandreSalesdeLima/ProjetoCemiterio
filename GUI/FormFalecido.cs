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
    public partial class FormFalecido : Form
    {
        static Falecido fale;

  
        
        


        public FormFalecido()
        {
            InitializeComponent();
            atualizarGridView();
        }

        public void validarCampos()
        {

            if (maskedTextBoxCpf.Text.Trim().Equals("") || maskedTextBoxCpf.Text.Length < 14)
            {
                MessageBox.Show("O campo Cpf não pode está vazio");
                maskedTextBoxCpf.Focus();
            }

            else if (textBoxNome.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Nome não pode está vazio");
                textBoxNome.Focus();
            }
            else
            {
                cadastrarFalecido();
            }
        }

        public void limparCampos()
        {
            this.maskedTextBoxCpf.Clear();
            this.textBoxNome.Clear();
            this.maskedTextBoxIdade.Clear();
            this.maskedTextBoxDataObito.Clear();
            this.labelID.Text = "";
        }
       
        public void setCampos()
        {
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            
            maskedTextBoxCpf.Text = linhaAtual.Cells[1].Value.ToString();
            textBoxNome.Text = linhaAtual.Cells[2].Value.ToString();
            maskedTextBoxIdade.Text = linhaAtual.Cells[3].Value.ToString();
            maskedTextBoxDataObito.Text = linhaAtual.Cells[4].Value.ToString();
            labelID.Text = linhaAtual.Cells[0].Value.ToString();
        }
        //incompleto
        public void atualizarGridView()
        {
            MySqlDataReader reder = FalecidoBD.listarTudoFalecido();
            DataSet ds1 = FalecidoBD.getDataSetTabelaFalecido();
            this.dataGridView1.DataSource = ds1.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
            //this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[2].Width = 215;
        }

        public void removerFalecido()
        {
            try
            {
                FalecidoBD.removerFalecido(Convert.ToInt32(labelID.Text));
                MessageBox.Show("Falecido removido com Sucesso!");
                limparCampos();
                atualizarGridView();
            }catch{
                MessageBox.Show("Certifique-se que os campos estão preenchidos.");
            }
        }
        public void cadastrarFalecido()
        {
            

            fale = new Falecido(this.maskedTextBoxCpf.Text, this.textBoxNome.Text, Convert.ToInt32(maskedTextBoxIdade.Text),Convert.ToDateTime(maskedTextBoxDataObito.Text));

            if (FalecidoBD.validaCpf(fale) == true)
            {
                MessageBox.Show("Esse Cpf já se encontra Cadastrado");
                maskedTextBoxCpf.Focus();
                maskedTextBoxCpf.ReadOnly = false;
            }
            else
            {
                try
                {
                    if (fale != null)
                    {
                        FalecidoBD.inserirFalecido(fale);
                        MessageBox.Show("O cadastro foi realizado com Sucesso");
                        atualizarGridView();
                        limparCampos();
                    }
                }
                catch
                {
                    MessageBox.Show("Os campos devem se Preechidos");

                }

            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cadastrarFalecido();
            }
            catch
            {
                MessageBox.Show("verifique os dados");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCampos();
        }

        private void buttonAtual_Click(object sender, EventArgs e)
        {
             try
            {
                Falecido fale = new Falecido(this.maskedTextBoxCpf.Text, this.textBoxNome.Text, Convert.ToInt32(maskedTextBoxIdade.Text),DateTime.Parse(maskedTextBoxDataObito.Text));

           
                if (fale != null)
                {
                    FalecidoBD.atualizarFalecido(fale,Convert.ToInt32(labelID.Text));
                    MessageBox.Show("Falecido Alterado com Sucesso!");
                    atualizarGridView();
                }
            }
            catch
            {
                MessageBox.Show("Todos os Campos Devem ser Preechidos");
            }
        }

        private void buttonRemov_Click_1(object sender, EventArgs e)
        {
            removerFalecido();
        }
    }
}
