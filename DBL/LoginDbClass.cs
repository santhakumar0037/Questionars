using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionnaire.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Questionnaire.DBL
{
    public class LoginDbClass
    {
        SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Sakthimudra; Integrated Security = True");

        public string chkLoginDetails(StudentRegisterClass login)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Check_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", login.LoginUserName);
                cmd.Parameters.AddWithValue("@UserPassword", login.LoginPassword);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetString(1);
                    }
                }
                return null;
            }
            catch (Exception Ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (Ex.Message.ToString());
            }
            finally {
                con.Close();
            }
        }
    }
}
