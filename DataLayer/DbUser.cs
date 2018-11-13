using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DbUser

    {
        private string connectionString;
        public DbUser()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString; 
        }
        public void Create(Usern entity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Users(Username, Password, Companyid) VALUES (@username, @password, @companyid)";
                    cmd.Parameters.AddWithValue("@username", entity.Username);
                    cmd.Parameters.AddWithValue("@password", entity.Password);
                    cmd.Parameters.AddWithValue("@companyid", entity.Companyid);
                }
            }
        }
        public void Delete(string companyid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Users WHERE Companyid = @companyid";
                    cmd.CommandText = "DELETE FROM Persons WHERE Companyid = @companyid";
                    cmd.Parameters.AddWithValue("@companyid", companyid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Usern Get(string companyid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Companyid=@companyid";
                    cmd.Parameters.AddWithValue("Companyid", companyid);
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Usern p = new Usern();
                        p.Username = reader.GetString(reader.GetOrdinal("Username"));
                        p.Password = reader.GetString(reader.GetOrdinal("Password"));
                        p.Companyid = reader.GetString(reader.GetOrdinal("Companyid"));

                        return p;
                    }
                }
            }
            return null;
        }
        public void Update(Usern entity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Users SET Username = @username, Password=@password WHERE Companyid=@companyid";
                    cmd.Parameters.AddWithValue("@username", entity.Username);
                    cmd.Parameters.AddWithValue("@password", entity.Password);
                    cmd.Parameters.AddWithValue("@companyid", entity.Companyid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Boolean Check(string username,string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Connection = conn;
                    conn.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    

                    bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
                    return loginSuccessful;
                }
              
            }
        }
    }
}
