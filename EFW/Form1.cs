using EFW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFW
{
    //add-migration [name of the changes]
    //update-database
    public partial class Form1 : Form
    {
        const string key = "MOU";

        AppDbContext context = new AppDbContext();
        public Form1()
        {
            InitializeComponent();

            
        }

        private void AddUser()
        {
            string enc = Encryption.Encrypt(txtPassword.Text, key);
            User user1 = new User { Name = txtName.Text, Password = enc, Email = txtEmail.Text};

            context.Users.Add(user1);
            context.SaveChanges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is missing");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password is missing");
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email is missing");
                return;
            }

            AddUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enc = Encryption.Encrypt(txtWord.Text, key);
            string dec = Encryption.Decrypt(enc, key);

            MessageBox.Show(dec);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginName.Text))
            {
                MessageBox.Show("LoginName is missing");
                return;
            }
 
            var user = context.Users.Where(u => u.Name == txtLoginName.Text).FirstOrDefault();
            var pass = Encryption.Decrypt(user.Password, key);

            if (pass == txtLoginPassword.Text)
            {
                MessageBox.Show("pass");
            }
            else
            {
                MessageBox.Show("user name or password is invalid");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(u => u.Name == txtName.Text).FirstOrDefault();
            user.Email = txtEmail.Text;
            context.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = context.Users.Where(u => u.Name == txtName.Text).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
