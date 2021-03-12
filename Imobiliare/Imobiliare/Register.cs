using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imobiliare
{
    public partial class Register : Form
    {
        public bool IsValidEmail(string source)
        {
            if (source != null && source != "") {
                if (source.IndexOf('@', 1, source.Length - 1) != -1)
                    return true;
            }
            return false;
        }

        public bool IsValidPhone(string source)
        {
            return Regex.Match(source, @"^[-+]?[0-9]+$").Success;
        }

        public Register()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textRegUsername.Text;
            string pass = textRegPassword.Text;
            string email = textRegEmail.Text;
            string phone = textRegPhone.Text;
            string name = textRegName.Text;
            string surname = textRegSurname.Text;
            if (username == null || pass == null || email == null || phone == null || name == null || surname == null)
                MessageBox.Show("Please complete all the required field", "Complete fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsValidEmail(email))
                MessageBox.Show("Please use a valid email adress", "Wrong email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsValidPhone(phone))
                MessageBox.Show("Please enter a valid phone number", "Wrong email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
                SqlConnection dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
                string queryInsertUser = "INSERT INTO [User] (username, password, email, phone_number, name, surname) " +
                                         "VALUES(@username, @password, @email, @phone, @name, @surname)";
                SqlCommand command = new SqlCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = queryInsertUser;
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", pass);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.ExecuteNonQuery();
                MessageBox.Show("Account created succesfuly", "Succes", MessageBoxButtons.OK);
                Login regForm = new Login();
                if (regForm == null)
                    regForm.Parent = this;
                regForm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login regForm = new Login();
            if (regForm == null)
                regForm.Parent = this;
            regForm.Show();
            this.Hide();
        }
    }
}
