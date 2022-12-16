using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoCemiterio.classesBasicas;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;



namespace ProjetoCemiterio.persistencia
{
    class FalecidoBD
    {
        static string cnString = "Persist Security Info=False;server=localhost;database=cemiterio;uid=root;";

        public static Boolean validaCpf(Falecido fal)
        {
            Boolean cpfExiste = false;
            string retornoCpf = "";
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"select Cpf from Falecido where Cpf = '" + fal.Cpf + "';";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();

            while(reader.Read())
            {
                retornoCpf = Convert.ToString(reader["cpf"]);
            } if (retornoCpf == "" || !retornoCpf.Equals(fal.Cpf))
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
        //obs:><><><>< o banco antigo n tem localizacao no parametro><><>
        public static void inserirFalecido(Falecido fal)
        {
            string strCpf = fal.Cpf;
            string strNome = fal.Nome;
            int strIdade = fal.Idade;
            DateTime strData = fal.Data;
           

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"insert into Falecido(Cpf,Nome,Idade,Data) values(@cpf,@nome,@idade,@data)";

            MySqlParameter prmCpf = new MySqlParameter("@cpf", MySqlDbType.VarChar);
            prmCpf.Value = strCpf;
            Command.Parameters.Add(prmCpf);

            MySqlParameter prmNome = new MySqlParameter("@nome",MySqlDbType.VarChar);
            prmNome.Value = strNome;
            Command.Parameters.Add(prmNome);

            MySqlParameter prmIdade = new MySqlParameter("@idade",MySqlDbType.Int32);
            prmIdade.Value = strIdade;
            Command.Parameters.Add(prmIdade);

            //MySqlDbType.Datetime ou MySqlDbType.DateTime? xD
            MySqlParameter prmData = new MySqlParameter("@data",MySqlDbType.DateTime);
            prmData.Value = strData;
            Command.Parameters.Add(prmData);



            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public static void atualizarFalecido(Falecido fal,int id)
        {
            string strCpf = fal.Cpf;
            string strNome = fal.Nome;
            int strIdade = fal.Idade;
            DateTime strData = fal.Data;
            

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
         
             
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType =CommandType.Text;
            Command.CommandText = @"update Falecido set cpf=@cpf,nome=@nome,idade=@idade,data=@data where Id_Fale = @Id_Fale";

            MySqlParameter prmId = new MySqlParameter("@Id_Fale", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);

            MySqlParameter prmCpf = new MySqlParameter("@cpf", MySqlDbType.VarChar);
            prmCpf.Value = strCpf;
            Command.Parameters.Add(prmCpf);

            MySqlParameter prmNome = new MySqlParameter("@nome", MySqlDbType.VarChar);
            prmNome.Value = strNome;
            Command.Parameters.Add(prmNome);

            MySqlParameter prmIdade = new MySqlParameter("@idade", MySqlDbType.Int32);
            prmIdade.Value = strIdade;
            Command.Parameters.Add(prmIdade);

            MySqlParameter prmData = new MySqlParameter("@data", MySqlDbType.DateTime);
            prmData.Value = strData;
            Command.Parameters.Add(prmData);



            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public static DataSet getDataSetTabelaFalecido()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Falecido";
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

        public static void removerFalecido(int id)
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"delete from Falecido where Id_Fale = @Id_Fale";

            // adicionamos o parâmetro @CPF à coleção de parâmetros do objeto Command
            MySqlParameter prmId = new MySqlParameter("@Id_Fale", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);
            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static MySqlDataReader listarTudoFalecido()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Falecido";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();
            Connection.Close();
            return reader;
        }


    }
}
