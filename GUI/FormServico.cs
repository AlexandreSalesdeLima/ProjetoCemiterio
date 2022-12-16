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
    public partial class FormServico : Form
    {
        static Servico s;
        public FormServico()
        {
            
            InitializeComponent();
            atualizarGridView();
        }

        public void limparCampos()
        {
            
            this.textBoxValorServico.Clear();
           
            
           
        }

        public void setCampos()
        {
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            
            comboBoxTipoServico.Text = linhaAtual.Cells[1].Value.ToString();
            textBoxValorServico.Text = linhaAtual.Cells[2].Value.ToString();
            labelIdServico.Text = linhaAtual.Cells[0].Value.ToString();
            
        }

        public void cadastrarServico()
        {
            s = new Servico(this.comboBoxTipoServico.Text, Convert.ToDouble( this.textBoxValorServico.Text));

        
                try
                {
                    if (s != null)
                    {
                        ServicoBD.inserirServico(s);
                        MessageBox.Show("Serviço foi cadastrado com Sucesso");
                        atualizarGridView();
                        limparCampos();
                    }
                }
                catch
                {
                    MessageBox.Show("Os campos devem se Preechidos");

                }

           
        }

        public void atualizarGridView()
        {
            MySqlDataReader reder = ServicoBD.listarTudoServico();
            DataSet ds1 = ServicoBD.getDataSetTabelaServico();
            this.dataGridView1.DataSource = ds1.Tables[0];
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.Columns[1].Width = 200;
            
        }

        public void removerServico()
        {
            try
            {
                ServicoBD.removerServico(Convert.ToInt32(labelIdServico.Text));
                MessageBox.Show("Serviço removido com Sucesso!");
                limparCampos();
                atualizarGridView();
            }
            catch
            {
                MessageBox.Show("Certifique-se que os campos estão preenchidos.");
            }
        }

       

        private void buttonCadastrarServico_Click(object sender, EventArgs e)
        {
            try
            {
                cadastrarServico();
            }
            catch
            {
                MessageBox.Show("verifique os dados");
            }
        }

        private void buttonAlterarServico_Click(object sender, EventArgs e)
        {
            Servico serv = new Servico(this.comboBoxTipoServico.Text, Convert.ToDouble(this.textBoxValorServico.Text));

            try
            {
                if (serv != null)
                {
                    ServicoBD.atualizarServico(serv, Convert.ToInt32(labelIdServico.Text));
                    MessageBox.Show("Servico Alterado com Sucesso!");
                    atualizarGridView();
                }
            }
            catch
            {
                MessageBox.Show("Todos os Campos Devem ser Preechidos");
            }
        
        }

        private void buttonExcluirServico_Click(object sender, EventArgs e)
        {
            removerServico();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setCampos();
        }
    }
}
