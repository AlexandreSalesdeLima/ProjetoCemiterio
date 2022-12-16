using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoCemiterio.classesBasicas;
using System.Data.SqlClient;
using ProjetoCemiterio.persistencia;
using MySql.Data.MySqlClient;
using System;

namespace ProjetoCemiterio.GUI
{
    public partial class FormCliente : Form
    {
        static Cliente c;

        public FormCliente()
        {
            InitializeComponent();
            atualizarGridView();
        }

        public void validarCampos()
        {

            if (maskedTextBoxCpfCli.Text.Trim().Equals("") || maskedTextBoxCpfCli.Text.Length < 14)
            {
                MessageBox.Show("O campo Cpf não pode está vazio");
                maskedTextBoxCpfCli.Focus();
            }
            /*else if (textBoxLogin.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Login não pode está vazio");
                textBoxLogin.Focus();
            }*/
            else if (textBoxNomeCli.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Nome não pode está vazio");
                textBoxNomeCli.Focus();
            }
            /*else if (textBoxSenha.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Senha não pode está vazio");
                textBoxSenha.Focus();
            }*/
            else if (textBoxEnderecoCli.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Endereço não pode está vazio");
                textBoxEnderecoCli.Focus();
            }
            else if (maskedTextBoxTelefoneCli.Text.Trim().Equals("") || maskedTextBoxTelefoneCli.Text.Trim().Length < 14)
            {
                MessageBox.Show("O campo Telefone não pode está vazio");
                maskedTextBoxTelefoneCli.Focus();
            }
            else
            {
                cadastrarCliente();
            }
        }

        public void limparCampos()
        {
            this.maskedTextBoxCpfCli.Clear();
            this.textBoxEnderecoCli.Clear();
            this.textBoxNomeCli.Clear();
            this.labelIdCli.Text = "";
            this.maskedTextBoxTelefoneCli.Clear();
            this.maskedTextBoxCpfCli.ReadOnly = false;
        }

        public void setCampos()
        {
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            textBoxNomeCli.Text = linhaAtual.Cells[2].Value.ToString();
            maskedTextBoxCpfCli.Text = linhaAtual.Cells[1].Value.ToString();
            textBoxEnderecoCli.Text = linhaAtual.Cells[3].Value.ToString();
            maskedTextBoxTelefoneCli.Text = linhaAtual.Cells[4].Value.ToString();
            labelIdCli.Text = linhaAtual.Cells[0].Value.ToString();
        }

        public void cadastrarCliente()
        {
            c = new Cliente( this.maskedTextBoxCpfCli.Text, this.textBoxNomeCli.Text,this.textBoxEnderecoCli.Text, this.maskedTextBoxTelefoneCli.Text);

            if (ClienteBD.validaCpf(c) == true)
            {
                MessageBox.Show("Esse Cpf já se encontra Cadastrado");
                maskedTextBoxCpfCli.Focus();
                maskedTextBoxCpfCli.ReadOnly = false;
            }
            else
            {
                try
                {
                    if (c != null)
                    {
                        ClienteBD.inserirCliente(c);
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

        public void atualizarGridView()
        {
            MySqlDataReader reder = ClienteBD.listarTudoCliente();
            DataSet ds1 = ClienteBD.getDataSetTabelaCliente();
            this.dataGridView1.DataSource = ds1.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[2].Width = 215;
        }

        public void EditaCliente()
        {

            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            string cpf = linhaAtual.Cells[0].Value.ToString();
            MessageBox.Show("Cliente Alterado com Sucesso!");
            limparCampos();
        }

        public void removerCliente()
        {
            try
            {
                ClienteBD.removerCliente(Convert.ToInt32(labelIdCli.Text));
                MessageBox.Show("Cliente removido com Sucesso!");
                limparCampos();
                atualizarGridView();
            }
            catch
            {
                MessageBox.Show("Certifique-se que os campos estão preenchidos.");
            }
        }

     


        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCampos();
        }

        private void buttonRemov_Click(object sender, System.EventArgs e)
        {
            removerCliente();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            validarCampos();
        }

        private void buttonAtual_Click(object sender, System.EventArgs e)
        {
            Cliente cli = new Cliente(this.maskedTextBoxCpfCli.Text, this.textBoxNomeCli.Text, this.textBoxEnderecoCli.Text, this.maskedTextBoxTelefoneCli.Text);

            try
            {
                if (cli != null)
                {
                    ClienteBD.atualizaCliente(cli, Convert.ToInt32(labelIdCli.Text));
                    MessageBox.Show("Cliente Alterado com Sucesso!");
                    atualizarGridView();
                }
            }
            catch
            {
                MessageBox.Show("Todos os Campos Devem ser Preechidos");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            setCampos();
        }




   
    }
}
