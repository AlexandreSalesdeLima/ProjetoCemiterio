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
    class ServicoBD
    {
        static string cnString = " Persist Security Info=False;server=localhost;database=cemiterio;uid=root;";

        public static void inserirServico(Servico serv)
        {


            string strTipo = serv.Tipo;
            double strValor = serv.Valor;


            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"insert into Servico(Tipo, Valor) values(@Tipo,@valor)";

            MySqlParameter prmTipo = new MySqlParameter("@tipo", MySqlDbType.VarChar);
            prmTipo.Value = strTipo;
            Command.Parameters.Add(prmTipo);

            MySqlParameter prmValor = new MySqlParameter("@valor", MySqlDbType.Double);
            prmValor.Value = strValor;
            Command.Parameters.Add(prmValor);


            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void atualizarServico(Servico serv, int id)
        {
            string strTipo = serv.Tipo;
            double strValor = serv.Valor;

            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            // criamos o objeto Command e definimos suas propriedades, ele será utilizado 
            // para invocar a StoredProcedure que gravará a imagem no SQL Server 

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"update Servico set tipo=@tipo,valor=@valor where Id_Serv = @Id_Servico";

            MySqlParameter prmId = new MySqlParameter("@Id_Servico", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);

            MySqlParameter prmTipo = new MySqlParameter("@tipo", MySqlDbType.VarChar);
            prmTipo.Value = strTipo;
            Command.Parameters.Add(prmTipo);

            MySqlParameter prmValor = new MySqlParameter("@valor", MySqlDbType.Double);
            prmValor.Value = strValor;
            Command.Parameters.Add(prmValor);


            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static DataSet getDataSetTabelaServico()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Servico";
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

        public static void removerServico(int id)
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = @"delete from Servico where Id_Serv = @Id_Servico";

            // adicionamos o parâmetro @CPF à coleção de parâmetros do objeto Command
            MySqlParameter prmId = new MySqlParameter("@Id_Servico", MySqlDbType.Int32);
            prmId.Value = id;
            Command.Parameters.Add(prmId);
            // abrimos a conexão, executamos o Command e fechamos a conexão
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static MySqlDataReader listarTudoServico()
        {
            MySqlConnection Connection = new MySql.Data.MySqlClient.MySqlConnection(cnString);
            Connection.Open();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = @"select * from Servico";
            MySqlDataReader reader;
            reader = Command.ExecuteReader();
            Connection.Close();
            return reader;
        }
    }
}