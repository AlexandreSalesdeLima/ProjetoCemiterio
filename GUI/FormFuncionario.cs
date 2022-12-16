using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoCemiterio.classesBasicas;
using System.Data.SqlClient;
using ProjetoCemiterio.persistencia;
using MySql.Data.MySqlClient;




namespace ProjetoCemiterio.GUI
{
    public partial class FormFuncionario : Form
    {
        static Funcionario f;

        public FormFuncionario()
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
            /*else if (textBoxLogin.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Login não pode está vazio");
                textBoxLogin.Focus();
            }*/
            else if (textBoxNome.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Nome não pode está vazio");
                textBoxNome.Focus();
            }
            /*else if (textBoxSenha.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Senha não pode está vazio");
                textBoxSenha.Focus();
            }*/
            else if (textBoxEndereco.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Endereço não pode está vazio");
                textBoxEndereco.Focus();
            }
            else if (maskedTextBoxTelefone.Text.Trim().Equals("")||maskedTextBoxTelefone.Text.Trim().Length <14)
            {
                MessageBox.Show("O campo Telefone não pode está vazio");
                maskedTextBoxTelefone.Focus();
            }
            else
            {
                cadastrarFuncionario();
            }
        }
        public void limparCampos()
        {
            this.maskedTextBoxCpf.Clear();
            this.textBoxEndereco.Clear();
            this.textBoxNome.Clear();
            this.labelId.Text="";
            this.maskedTextBoxTelefone.Clear();
            this.maskedTextBoxCpf.ReadOnly = false;
        }

        public void setCampos()
        {
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            textBoxNome.Text = linhaAtual.Cells[2].Value.ToString();
            maskedTextBoxCpf.Text = linhaAtual.Cells[1].Value.ToString();
            textBoxEndereco.Text = linhaAtual.Cells[3].Value.ToString();
            maskedTextBoxTelefone.Text = linhaAtual.Cells[4].Value.ToString();
           labelId.Text = linhaAtual.Cells[0].Value.ToString();
        }

        public void cadastrarFuncionario()
        {
            f = new Funcionario(this.maskedTextBoxTelefone.Text, this.textBoxEndereco.Text, this.textBoxNome.Text, this.maskedTextBoxCpf.Text,"","");

            if (FuncionarioBD.validaCpf(f) == true)
            {
                MessageBox.Show("Esse Cpf já se encontra Cadastrado");
                maskedTextBoxCpf.Focus();
                maskedTextBoxCpf.ReadOnly = false;
            }
            else
            {
                try
                {
                    if (f != null)
                    {
                        FuncionarioBD.inserirFuncionario(f);
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
        public void atualizarGridView ()
        {
            MySqlDataReader reder = FuncionarioBD.listarTudoFuncionario();
            DataSet ds1 = FuncionarioBD.getDataSetTabelaFuncionario();
            this.dataGridView1.DataSource = ds1.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[2].Width = 215;
        }
        public void EditaFuncionario()
        {
            
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            string cpf = linhaAtual.Cells[0].Value.ToString();
            MessageBox.Show("Funcionario Alterada com Sucesso!");
            limparCampos();
        }
        public void removerFuncionario()
        {
            try
            {
                FuncionarioBD.removerFuncionario(Convert.ToInt32(labelId.Text));
                MessageBox.Show("Funcionario removido com Sucesso!");
                limparCampos();
                atualizarGridView();
            }catch{
                MessageBox.Show("Certifique-se que os campos estão preenchidos.");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            validarCampos();
        }
        private void buttonAtual_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario(this.maskedTextBoxTelefone.Text, this.textBoxEndereco.Text, this.textBoxNome.Text, this.maskedTextBoxCpf.Text,"","");

            try
            {
                if (func != null)
                {
                    FuncionarioBD.atualizaFuncionario(func,Convert.ToInt32(labelId.Text));
                    MessageBox.Show("Funcionario Alterado com Sucesso!");
                    atualizarGridView();
                }
            }
            catch
            {
                MessageBox.Show("Todos os Campos Devem ser Preechidos");
            }
        }

        private void buttonRemov_Click(object sender, EventArgs e)
        {
            removerFuncionario();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCampos();
        }

        
    }
}

