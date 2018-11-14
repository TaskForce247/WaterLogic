using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using DataLayer;

namespace PartyWinClient
{
    public partial class Form1 : Form
    {
        private DbParty dbParty;
        private DbPerson dbPerson;
        private DbUser dbUser;

        private string username;
        private string password;
        public Form1()
        {
            InitializeComponent();
            dbUser = new DbUser();
            dbParty = new DbParty();
            dbPerson = new DbPerson();
            
        }

        private void InitializePartyListBoxData()
        {
            
        }
        private void InitializePeopleListBoxData()
        {
        }

        private void btnCreateParty_Click(object sender, EventArgs e)
        {
            dbParty.Create(new Party() { AvailableSpots = Convert.ToInt32(txtPartySpots.Text), Title = txtPartyTitle.Text });
            InitializePartyListBoxData();
        }

        private void listBoxKeyDown(object sender, KeyEventArgs e)
        {
            var sendingLb = (ListBox)sender;
            var currentItem = (Party)sendingLb.SelectedItem as Party;
            if (e.KeyCode == Keys.Delete)
            {
                dbParty.Delete(currentItem.Id);
                sendingLb.Items.Remove(currentItem);
            }
        }

        private void lbClickEvent(object sender, MouseEventArgs e)
        {
          
        }

        private void btnCreatePerson_Click(object sender, EventArgs e)
        {
            username = txtFirstName.Text; password = txtLastName.Text;
            if (checkUser(username, password))
            {
               Form2 employees = new Form2();
                employees.Show();
            }
        }

        private void btnJoinParty_Click(object sender, EventArgs e)
        {
           
           
        }

        private void btnJoinSafe_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPartySpots_TextChanged(object sender, EventArgs e)
        {

        }
        private Boolean checkUser(string username, string password)
        {

            Boolean b;

            b = dbUser.Check(username, password);
            return b;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
