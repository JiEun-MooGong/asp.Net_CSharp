using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using RoadBook.CsharpBasic.Chapter10.Examples.Model;

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    public class MsSqlManager : IDatabaseManager
    {
        SqlConnection connection = null;

        public void message(string strMessage)
        {
            Console.WriteLine(strMessage);
        }

        public void Open(DatabaseInfo dbInfo)
        {
            try
            {
                string conStr = string.Format
                    ("Data Source={0},{1};" +
                    "Initial Catalog={2};" +
                    "User ID={3};" +
                    "Password ={4}",
                    dbInfo.Ip, dbInfo.Port,
                    dbInfo.Name,
                    dbInfo.UserId,
                    dbInfo.UserPassword);

                connection = new SqlConnection(conStr);
                connection.Open();
            }
            catch(Exception ex)
            {
                message("ERROR Open: " + ex.Message);
            }
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int idx = 0; idx < reader.FieldCount; idx++)
                    {
                        dt.Columns.Add(new DataColumn(reader.GetName(idx)));
                       
                    }//for

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();

                        for (int idx = 0; idx < dt.Columns.Count; idx++)
                        {
                            row[dt.Columns[idx]] = reader[dt.Columns[idx].ColumnName];

                        }//for
                        dt.Rows.Add(row);
                    }//while

                }//using reader
            }//usin command

            return dt;
        }

        public int Insert(string sql)
        {
            int activeNumber = 0;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public int Update(string sql)
        {
            int activeNumber = 0;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public int Delete(string sql)
        {
            int activeNumber = 0;

            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public void Close()
        {
            if(connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
