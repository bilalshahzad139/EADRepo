using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public static class StudentDAL
    {
        public static Boolean ValidateUser(String login, String password)
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.DataSource = @".\SQLExpress2012";
            connBuilder.InitialCatalog = "EAD";
            connBuilder.UserID = "sa";
            connBuilder.Password = "P@ssword12345";
            String connString = connBuilder.ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String query = String.Format("Select UserID from dbo.Users where Login='{0}' AND Password ='{1}'"
                                    , login, password);
                    SqlCommand command = new SqlCommand(query, conn);
                    var obj = command.ExecuteScalar();
                    if (obj != null)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<StudentDTO> GetAllStudents()
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.DataSource = @".\SQLExpress2012";
            connBuilder.InitialCatalog = "EAD";
            connBuilder.UserID = "sa";
            connBuilder.Password = "P@ssword12345";
            String connString = connBuilder.ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    List<StudentDTO> list = new List<StudentDTO>();
                    String query = "Select * from dbo.Student";
                    SqlCommand command = new SqlCommand(query, conn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        StudentDTO dto = new StudentDTO();
                        dto.ID = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                        dto.City = reader.GetString(2);
                        dto.Age = reader.GetInt32(3);

                        list.Add(dto);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
