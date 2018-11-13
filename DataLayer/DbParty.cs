using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DataLayer
{
    public class DbParty : IDbCrud<Party>
    {
        private readonly string _connectionString;
        public DbParty()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        }
        public void Create(Party entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Party(Title, AvailableSpots) VALUES (@title,@availableSpots)";
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@availableSpots", entity.AvailableSpots);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Party WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Party> Get()
        {
            List<Party> parties = new List<Party>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Party ";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Party p = new Party();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.Title = reader.GetString(reader.GetOrdinal("Title"));
                        p.AvailableSpots = reader.GetInt32(reader.GetOrdinal("AvailableSpots"));

                        parties.Add(p);
                    }
                }
            }
            return parties;
        }
        public Party Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Party WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Party p = new Party();
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.Title = reader.GetString(reader.GetOrdinal("Title"));
                        p.AvailableSpots = reader.GetInt32(reader.GetOrdinal("AvailableSpots"));

                        return p;
                    }
                }
            }
            return null;
        }
        public void Update(Party entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Party SET Title = @title WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BookSpot(int partyId, int personId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var foundParty = Get(partyId);

                //Find out how many spots are currently booked
                int currentBookingsOnParty;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Count(*) FROM PartyPerson pp WHERE pp.PartyId=@partyId";
                    cmd.Parameters.AddWithValue("partyId", partyId);
                    currentBookingsOnParty = (int)cmd.ExecuteScalar();
                }
                //check if the currently booked amount is less than the max amount
                if (currentBookingsOnParty < foundParty.AvailableSpots)
                {
                    //Book party
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO PartyPerson (PartyId, PersonId) VALUES (@partyId, @personId)";
                        cmd.Parameters.AddWithValue("partyId", partyId);
                        cmd.Parameters.AddWithValue("personId", personId);
                        currentBookingsOnParty = cmd.ExecuteNonQuery();
                    }
                    //We should probably also check if person is already in party
                }
                else
                {
                    throw new Exception("No spots available");
                }

            }

        }
        public void BookSpotTransaction(int partyId, int personId, TextBox statusBox)
        {
            TransactionOptions opts = new TransactionOptions();
            opts.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, opts))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        Party foundParty;
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Party WHERE Id=@id";
                            cmd.Parameters.AddWithValue("@id", partyId);
                            var reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                Party p = new Party();
                                p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                                p.Title = reader.GetString(reader.GetOrdinal("Title"));
                                p.AvailableSpots = reader.GetInt32(reader.GetOrdinal("AvailableSpots"));

                                foundParty = p;
                                reader.Close();
                                statusBox.Text += "Selected party..." + Environment.NewLine;
                            }
                            else
                            {
                                throw new Exception("Trying to join a non existing party");
                            }
                        }

                        //Find out how many spots are currently booked
                        int currentBookingsOnParty;
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT Count(*) FROM PartyPerson pp WHERE pp.PartyId=@partyId";
                            cmd.Parameters.AddWithValue("@partyId", partyId);
                            currentBookingsOnParty = (int)cmd.ExecuteScalar();
                            statusBox.Text += "Read bookings" + Environment.NewLine;
                        }
                        //check if the currently booked amount is less than the max amount
                        if (currentBookingsOnParty < foundParty.AvailableSpots)
                        {
                            //Book party
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "INSERT INTO PartyPerson (PartyId, PersonId) VALUES (@partyId, @personId)";
                                cmd.Parameters.AddWithValue("@partyId", partyId);
                                cmd.Parameters.AddWithValue("@personId", personId);
                                var affected = cmd.ExecuteNonQuery();
                                statusBox.Text += "added booking" + Environment.NewLine;
                            }
                            //We should probably also check if person is already in party
                        }
                        else
                        {
                            throw new Exception("No spots available");
                        }

                    }
                    scope.Complete();//Commit
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 1205)//1205 == a deadlock
                    {
                        statusBox.Text += "Exception: " + ex.Message + " .. retrying.." + Environment.NewLine;
                        //Careful, will retry forever....
                        BookSpotTransaction(partyId, personId, statusBox);
                    }
                   

                }
            }

        }
    }
}
