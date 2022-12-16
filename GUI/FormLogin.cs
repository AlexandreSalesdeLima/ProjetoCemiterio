using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoCemiterio.GUI;
using ProjetoCemiterio.classesBasicas;
using ProjetoCemiterio.persistencia;

namespace ProjetoCemiterio
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        public void Fechar() {
            DialogResult dialogo = MessageBox.Show("Tem certeza que deseja encerrar a aplicação?", "Você deseja Sair?", MessageBoxButtons.OKCancel);

            if (dialogo == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                textBox1.Focus();
                return;
                
            }
        }


        public void Verificar()
        {


            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Informe um Usuário e Senha !");
                if (textBox1.Text.Equals(""))
                {
                    textBox1.Focus();
                }
                else if (textBox2.Text.Equals(""))
                {
                    textBox2.Focus();
                }
            }
            else
            {
                Funcionario func = new Funcionario("", "","","", textBox1.Text.Trim(), textBox2.Text.Trim());
                if (FuncionarioBD.validaUsuario(func) == null)
                {

                    MessageBox.Show("Usuario ou Senha Incorretos. informe um usuario valido!");
                    textBox2.Clear();
                }
                else
                {
                    Funcionario funcvalida = new Funcionario("","","","",FuncionarioBD.validaUsuario(func).Login, FuncionarioBD.validaUsuario(func).Senha);
                    if (func.Login.Equals(funcvalida.Login) && func.Senha.Equals(funcvalida.Senha))
                    {

                        FormCemiterio principal = new FormCemiterio();
                        principal.Show();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou Senha Incorretos. informe um usuario válido!");
                        textBox1.Focus();
                        textBox2.Clear();
                    }
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Verificar();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fechar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fechar();
        }
    }
}
