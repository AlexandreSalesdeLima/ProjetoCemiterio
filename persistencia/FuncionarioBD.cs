using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using ProjetoCemiterio.classesBasicas;
using System.Windows.Forms;


namespace ProjetoCemiterio.persistencia
{
    class FuncionarioBD
    {
        public static Funcionario user;
        static string cnString = " Persist Security Info=False;server=localhost;database=cemiterio;uid=root;";

        public static Funcionario validaUsuario(Funcionario u)
        {

            try
            {
                MySqlConnection Connection = new MySqlConnection(cnString);

                Connection.Open();
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = @"select * from funcionario where login = @login and senha = @senha;";

                MySqlParameter prmLogin = new MySqlParameter("@login", MySqlDbType.VarChar);
                prmLogin.Value = u.Login;
                Command.Parameters.Add(prmLogin);

                MySqlParameter prmSenha = new MySqlParameter("@senha", MySqlDbType.VarChar);
                prmSenha.Value = u.Senha;
                Command.Parameters.Add(prmSenha);

                MySqlDataReader reader;

                reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    user = new Funcionario("","","","", reader["login"].ToString(), reader["senha"].ToString());
                }

                Connection.Close();
            }
            catch
            {
                DialogResult dialogo = MessageBox.Show("Impossível estabelecer conexão.\nVerifique as configurações de acesso com o banco de dados!", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.ExitThread();
            }
            return user;
        }



        public static Boolean validaCpf(Funcionario func)
        {
            Boolean cpfExiste = false;
            string retornoCpf = "";
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"select Cpf from funcionario where Cpf ='" + func.Cpf + "';";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();

            while (reader.Read())
            {
                retornoCpf = Convert.ToString(reader["cpf"]);

            }
            if (retornoCpf == "" || !retornoCpf.Equals(func.Cpf))
            {
                cpfExiste = false;
            }
            else
            {
                cpfExiste = true;
            }
            Connection.Close();
            return cpfExiste;
        }
        public static void inserirFuncionario(Funcionario func)
        {

            string strCpf = func.Cpf;
            string strNome = func.Nome;
            string strEndereco = func.Endereco;
            string strTelefone = func.Telefone;

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"insert into Funcionario(Cpf,Nome,Endereco,Telefone) values(@cpf,@nome,@endereco,@telefone)";

            MySqlParameter prmCpf = new MySqlParameter("@cpf", MySqlDbType.VarChar);
            prmCpf.Value = strCpf;
            Command.Parameters.Add(prmCpf);

            MySqlParameter prmNome = new MySqlParameter("@nome", MySqlDbType.VarChar);
            prmNome.Value = strNome;
            Command.Parameters.Add(prmNome);

            MySqlParameter prmEndereco = new MySqlParameter("@endereco", MySqlDbType.VarChar);
            prmEndereco.Value = strEndereco;
            Command.Parameters.Add(prmEndereco);

            MySqlParameter prmTelefone = new MySqlParameter("@telefone", MySqlDbType.VarChar);
            prmTelefone.Value = strTelefone;
            Command.Parameters.Add(prmTelefone);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public static void atualizaFuncionario(Funcionario func,int id)
        {
            string strCpf = func.Cpf;
            string strNome = func.Nome;
            string strEndereco = func.Endereco;
            string strTelefone = func.Telefone;

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            // criamos o objeto Command e definimos suas propriedades, ele será utilizado 
            // para invocar a StoredProcedure que gravará a imagem no SQL Server 

            // 3 linha não seria  = System.Data.CommandType.Text;?
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"update Funcionario set cpf=@cpf,nome=@nome,endereco=@endereco,telefone=@telefone where Id_Func = @Id_Func";

            MySqlParameter prmId = new MySqlParameter("@Id_Func", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);

            MySqlParameter prmCpf = new MySqlParameter("@cpf", MySqlDbType.VarChar);
            prmCpf.Value = strCpf;
            Command.Parameters.Add(prmCpf);

            MySqlParameter prmNome = new MySqlParameter("@nome", MySqlDbType.VarChar);
            prmNome.Value = strNome;
            Command.Parameters.Add(prmNome);

            MySqlParameter prmEndereco = new MySqlParameter("@endereco", MySqlDbType.VarChar);
            prmEndereco.Value = strEndereco;
            Command.Parameters.Add(prmEndereco);

            MySqlParameter prmTelefone = new MySqlParameter("@telefone", MySqlDbType.VarChar);
            prmTelefone.Value = strTelefone;
            Command.Parameters.Add(prmTelefone);

            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        
        public static DataSet getDataSetTabelaFuncionario()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Funcionario";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();

            DataSet dataSet = new DataSet();
            do
            {
                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Cria um nome de coluna unico
                        string columnName = (string)dataRow["ColumnName"];
                        // Adiciona a definicao de coluna ao dataTable
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    // Preenche o dataTable criado anteriormente

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // Nenhum registro foi retornado

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());

            Connection.Close();
            return dataSet;
        }
        //metodo remover Funcionario
        public static void removerFuncionario(int id)
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"delete from Funcionario where Id_Func = @Id_Func";

            // adicionamos o parâmetro @CPF à coleção de parâmetros do objeto Command
            MySqlParameter prmId = new MySqlParameter("@Id_Func", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);
            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public static MySqlDataReader listarTudoFuncionario()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Funcionario";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();
            Connection.Close();
            return reader;
        }
    }
 }

    

