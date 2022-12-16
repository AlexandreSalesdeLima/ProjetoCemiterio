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
    class ClienteBD
    {
        static string cnString = " Persist Security Info=False;server=localhost;database=cemiterio;uid=root;";

        public static Boolean validaCpf(Cliente cli)
        {
            Boolean cpfExiste = false;
            string retornoCpf = "";
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"select Cpf from Cliente where Cpf ='" + cli.Cpf + "';";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();

            while (reader.Read())
            {
                retornoCpf = Convert.ToString(reader["cpf"]);

            }
            if (retornoCpf == "" || !retornoCpf.Equals(cli.Cpf))
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

        public static void inserirCliente(Cliente cli)
        {

            string strCpf = cli.Cpf;
            string strNome = cli.Nome;
            string strEndereco = cli.Endereco;
            string strTelefone = cli.Telefone;

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"insert into Cliente(Cpf,Nome,Endereco,Telefone) values(@cpf,@nome,@endereco,@telefone)";

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

        public static void atualizaCliente(Cliente cli, int id)
        {
            string strCpf = cli.Cpf;
            string strNome = cli.Nome;
            string strEndereco = cli.Endereco;
            string strTelefone = cli.Telefone;

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            // criamos o objeto Command e definimos suas propriedades, ele será utilizado 
            // para invocar a StoredProcedure que gravará a imagem no SQL Server 

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"update Cliente set cpf=@cpf,nome=@nome,endereco=@endereco,telefone=@telefone where Id_Cli = @Id_Cli";

            MySqlParameter prmId = new MySqlParameter("@Id_Cli", MySqlDbType.Int32);
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

        //verificar esse metodo chamado DataSet ?
        public static DataSet getDataSetTabelaCliente()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Cliente";
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

        //metodo remover Cliente
        public static void removerCliente(int id)
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"delete from Cliente where Id_Cli = @Id_Cli";

            // adicionamos o parâmetro @CPF à coleção de parâmetros do objeto Command
            MySqlParameter prmId = new MySqlParameter("@Id_Cli", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);
            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static MySqlDataReader listarTudoCliente()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Cliente";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();
            Connection.Close();
            return reader;
        }
    }
}
