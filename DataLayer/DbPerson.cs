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
    public class DbPerson : IDbCrud<Person>
    {
        private string connectionString;
        public DbPerson()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public void Create(Person entity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Person(FirstName, LastName) VALUES (@firstName, @lastName)";
                    cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Person WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Person> Get()
        {
            List<Person> people = new List<Person>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Person";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person p = new Person();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        people.Add(p);
                    }
                }
            }
            return people;
        }
        public Person Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Person WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Person p = new Person();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        p.LastName = reader.GetString(reader.GetOrdinal("LastName"));

                        return p;
                    }
                }
            }
            return null;
        }
        public void Update(Person entity)
        {
            using(SqlConnection conn = new SqlConnection(connectionString)) { 
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Person SET FirstName = @firstName, LastName=@lastName WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                cmd.ExecuteNonQuery();
            }
            }
        }
        public IEnumerable<Person> GetNotInParty(int partyId)
        {
            List<Person> people = new List<Person>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT p.Id, p.FirstName, p.LastName FROM  Person p WHERE p.Id NOT IN (SELECT pp.PersonId FROM PartyPerson pp WHERE PartyId=@partyId)";
                    cmd.Parameters.AddWithValue("partyId", partyId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Person p = new Person();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        people.Add(p);
                    }
                }
            }
            return people;
        }
    }
}
