using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class DbUser:IDbCrud<Usern>

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
    }
}
