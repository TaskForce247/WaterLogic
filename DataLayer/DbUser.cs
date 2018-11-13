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
    public class DbUser : IDbCrud<Usern>

    {
        private string connectionString;
        private SqlConnection conn;
        public DbUser()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            Console.WriteLine("something");

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
                conn.Close();
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
                conn.Close();
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
                    conn.Close();
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
                conn.Close();
            }

        }
        public Boolean Check(string username, string password)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);


                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);


                    bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                    return loginSuccessful;
                }


            }


        }
        public IEnumerable<Usern> Get()
        {
            List<Usern> people = new List<Usern>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Usern p = new Usern();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.Username = reader.GetString(reader.GetOrdinal("Username"));
                        p.Password = reader.GetString(reader.GetOrdinal("Password"));
                        people.Add(p);
                    }
                }
            }
            return people;
        }
        public Usern Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Usern p = new Usern();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.Username = reader.GetString(reader.GetOrdinal("Username"));
                        p.Password = reader.GetString(reader.GetOrdinal("Password"));

                        return p;
                    }
                }
            }
            return null;
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Users WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
