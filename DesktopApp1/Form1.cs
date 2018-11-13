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

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        private DbUser dbUser;
        private string username;
        private string password;
       
        public Form1()
        {
            InitializeComponent();
            dbUser = new DbUser();

             
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            if(checkUser(username,password))
            { MessageBox.Show("Thanks!"); }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private Boolean checkUser(string username,string password)
        {
            Boolean b;
           b= dbUser.Check(username, password);
            return b;
        }
    }
}
