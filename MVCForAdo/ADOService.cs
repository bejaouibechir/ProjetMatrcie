using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MVCForAdo
{
    public class ADOService : IADOService
    {
        public List<string> executeQueryConnectedMode()
        {
            var _list = new List<string>();

            using var sqlConnection = new SqlConnection(@"Data Source=PC2020\BI2020;Initial Catalog=Test;Integrated Security=True");

            var command = new SqlCommand("SELECT * FROM Dummy", sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int length = reader.FieldCount;
                
                while (reader.Read())
                {
                    _list.Add(reader[0] + " " + reader[1]);
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return _list;
        }

        public DataSet executeQueryDisconnectedMode()
        {
            using var sqlConnection = new SqlConnection(@"Data Source=PC2020\BI2020;Initial Catalog=Test;Integrated Security=True");

            var command = new SqlCommand("SELECT * FROM Dummy",sqlConnection);

            DataSet data= new DataSet("Dummy");
            try
            {
                sqlConnection.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return data;

        }

        public List<string> getqueryFromStoredProcedure(int id_inf, int id_sup)
        {
            var list = new List<string>();
            
            using var sqlConnection = new SqlConnection(@"Data Source=PC2020\BI2020;Initial Catalog=Test;Integrated Security=True");

            var command = new SqlCommand("dbo.sp_dummy", sqlConnection);

            command.CommandType = CommandType.StoredProcedure;

            SqlParameter idinfparam = new SqlParameter("@id_inf", id_inf);
            SqlParameter idsupparam = new SqlParameter("@id_sup", id_sup);

            command.Parameters.Add(idinfparam);
            command.Parameters.Add(idsupparam);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int length = reader.FieldCount;
                while (reader.Read())
                {
                    string result = "";
                    for (int i = 0; i < length - 1; i++)
                    {
                        result += " " + reader[i].ToString();
                    }
                    list.Add(result);
                }
            }
            catch (SqlException ex)
            {
                Debug.Write(ex.Message);
            }


            return list;
        }
    }
}
