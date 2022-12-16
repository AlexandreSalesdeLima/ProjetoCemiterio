using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoCemiterio.classesBasicas;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProjetoCemiterio.persistencia
{
    class FuneralBD
    {
        
        static string cnString = " Persist Security Info=False;server=localhost;database=cemiterio;uid=root;";

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


    }
}
