using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Questionnaire.Models;
using System.Data;


namespace Questionnaire.Controllers
{
    public class RegisterDBClass
    {
        SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Sakthimudra; Integrated Security = True");

        public string AddRegisterRecord(StudentRegisterClass RegisterValues) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Student_Register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", RegisterValues.Name);
                cmd.Parameters.AddWithValue("@UserName", RegisterValues.UserName);
                cmd.Parameters.AddWithValue("@Email", RegisterValues.Email);
                cmd.Parameters.AddWithValue("@MobileNumber", RegisterValues.MobileNumber);
                cmd.Parameters.AddWithValue("@UserPassword", RegisterValues.UserPassword);
                cmd.Parameters.AddWithValue("@DOB", RegisterValues.DOB);
                cmd.Parameters.AddWithValue("@Gender", RegisterValues.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "you are successfully registered, Login using your credentials";
            }
            catch (Exception Ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (Ex.Message.ToString());
            }
        
        }
    }
}
