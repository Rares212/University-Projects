using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imobiliare
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string queryUserPass = "SELECT user_id, name, surname, role FROM [User] WHERE username = @username AND password = @password";
            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryUserPass;
            command.Parameters.Add("username", SqlDbType.VarChar).Value = textUsername.Text;
            command.Parameters.Add("password", SqlDbType.VarChar).Value = textPassword.Text;
            SqlDataReader reader = command.ExecuteReader();

            string name = "";
            string surname = "";
            string role = "u";
            int userID = 1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userID = reader.GetInt32(reader.GetOrdinal("user_id"));
                    role = reader.GetString(reader.GetOrdinal("role"));
                    name = reader.GetString(reader.GetOrdinal("name"));
                    surname = reader.GetString(reader.GetOrdinal("surname"));
                }
                labelDebug.Text = "Welcome, " + name + " " + surname;
                if (role == "a")
                {
                    Admin adminForm = new Admin();
                    if (adminForm == null)
                        adminForm.Parent = this;
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    User userForm = new User();
                    if (userForm == null)
                        userForm.Parent = this;
                    userForm.Show();
                    this.Hide();
                }
                UserInfo.Username = textUsername.Text;
                UserInfo.user_id = userID;
            }
            else
            {
                labelDebug.Text = "Username or password incorrect";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            try {
                dbConnection.Open();
                MessageBox.Show("Database connection successful");
                dbConnection.Close();
            } catch {
                MessageBox.Show("Database connection failed");
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register regForm = new Register();
            if (regForm == null)
                regForm.Parent = this;
            regForm.Show();
            this.Hide();
        }
    }
}
