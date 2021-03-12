using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imobiliare
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            displayTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void displayTable()
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            //string queryProperties = "SELECT * FROM [User]";
            string queryProperties = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
                                     "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
                                     "JOIN Property P ON P.property_id = LP.property_id";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryProperties, dbConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plotType = comboPlotType.GetItemText(comboPlotType.SelectedItem);
            string address = textAdress.Text;
            string postal = textPostal.Text;
            float area = float.Parse(textArea.Text);
            string name = textName.Text;
            float price = float.Parse(textPrice.Text);

            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            // Insert Listing
            string queryInsert = "INSERT INTO [Listing] (user_id, listing_name, listing_price, listing_date, available) " +
                                  "VALUES(@user_id, @listing_name, @listing_price, GETDATE(), 1); SELECT Scope_Identity()";
            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryInsert;
            command.Parameters.AddWithValue("@user_id", UserInfo.user_id);
            command.Parameters.AddWithValue("@listing_name", name);
            command.Parameters.AddWithValue("@listing_price", price);
            int listingID = Convert.ToInt32(command.ExecuteScalar());

            // Insert Estate/Plot
            int plotID = 0;
            int estateID = 0;
            if (plotType == "Plot")
            {
                string queryInsert2 = "INSERT INTO [Plot] (type) VALUES ('i'); SELECT Scope_Identity()";
                SqlCommand command2 = new SqlCommand(queryInsert2, dbConnection);
                plotID = Convert.ToInt32(command2.ExecuteScalar());
            }
            else
            {
                string queryInsert2 = "INSERT INTO [RealEstate] (n_floors) VALUES (1); SELECT Scope_Identity()";
                SqlCommand command2 = new SqlCommand(queryInsert2, dbConnection);
                estateID = Convert.ToInt32(command2.ExecuteScalar());
            }

            // Insert property
            string queryInsert3 = "INSERT INTO [Property] (estate_id, plot_id, address, postal_code, area) " +
                                  "VALUES(@estate_id, @plot_id, @address, @postal_code, @area); SELECT Scope_Identity()";
            SqlCommand command3 = new SqlCommand(queryInsert3, dbConnection);
            if (plotType == "Plot")
            {
                command3.Parameters.AddWithValue("@estate_id", SqlInt32.Null);
                command3.Parameters.AddWithValue("@plot_id", plotID);
            }
            else
            {
                command3.Parameters.AddWithValue("@estate_id", estateID);
                command3.Parameters.AddWithValue("@plot_id", SqlInt32.Null);
            }
            command3.Parameters.AddWithValue("@address", address);
            command3.Parameters.AddWithValue("@postal_code", postal);
            command3.Parameters.AddWithValue("@area", area);
            int propertyID = Convert.ToInt32(command3.ExecuteScalar());

            // Insert many/many table
            string queryInsert4 = "INSERT INTO [ListingProperty] (listing_id, property_id) " +
                                  "VALUES(@listing_id, @property_id)";
            SqlCommand command4 = new SqlCommand(queryInsert4, dbConnection);
            command4.Parameters.AddWithValue("@listing_id", listingID);
            command4.Parameters.AddWithValue("@property_id", propertyID);
            command4.ExecuteNonQuery();

            // Display
            displayTable();
        }
        private void displaySearchResults(string query)
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, dbConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            dbConnection.Close();
        }

        private void displayUserResults(string query)
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, dbConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
            dbConnection.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Valoare si arie sub medie - COMPLEXA 1/4
            string query = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
                           "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
                           "JOIN Property P ON P.property_id = LP.property_id " +
                           "WHERE L.listing_price < (SELECT AVG(L2.listing_price) FROM Listing L2) " +
                           "AND P.area < (SELECT AVG(P2.area) FROM Property P2)";
            displaySearchResults(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Listare mai noua de o luna - Simpla 1/6
            string query = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
                           "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
                           "JOIN Property P ON P.property_id = LP.property_id " +
                           "WHERE L.listing_date > DATEADD(month, -1, GETDATE())";
            displaySearchResults(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Listare cu aria sub 5 - simpla 2/6
            string query = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
               "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
               "JOIN Property P ON P.property_id = LP.property_id " +
               "WHERE P.area < 5";
            displaySearchResults(query);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Pret sub medie - DOAR LOCUINTE - Complexa 2/4
            string query = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
               "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
               "JOIN Property P ON P.property_id = LP.property_id " +
               "WHERE L.listing_price < (SELECT AVG(L2.listing_price) FROM Listing L2) " +
               "AND P.plot_id = NULL";
            displaySearchResults(query);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Apartamente Cluj sub 100000$ - Simpla 3/6 (desi eu as zice ca e o cautare complexa)
            string query = "SELECT L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
               "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
               "JOIN Property P ON P.property_id = LP.property_id " +
               "WHERE P.address LIKE '%Cluj%' AND L.listing_price < 100000";
            displaySearchResults(query);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Cautare in functie de pret/arie - Simpla 4/6
            string query = "SELECT (L.listing_price / P.area) AS 'Pret/Arie', L.listing_name, L.listing_price, L.listing_date, P.address, P.postal_code, P.area " +
               "FROM Listing L JOIN ListingProperty LP ON L.listing_id = LP.listing_id " +
               "JOIN Property P ON P.property_id = LP.property_id " +
               "ORDER BY L.listing_price / P.area ASC";
            displaySearchResults(query);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Utilizatorul cu cea mai scumpa locuinta - Complexa 3/4
            string query = "SELECT U.username, L.listing_price " +
            "FROM [User] U JOIN Listing L ON U.user_id = L.user_id " +
            "WHERE L.listing_price >= ALL (SELECT L2.listing_price FROM Listing L2) ";
            displayUserResults(query);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Utilizatorul cu cele mai multe listari - Complexa 4/4
            string query = "SELECT U.username, COUNT(L.listing_id) AS 'Numar Listari' " +
                           "FROM[User] U JOIN Listing L ON U.user_id = L.user_id " +
                           "GROUP BY U.username " +
                           "HAVING COUNT(L.listing_id) >= ALL(SELECT COUNT(L2.listing_id) FROM Listing L2 JOIN[User] U2 ON U2.user_id = L2.user_id) ";
            displayUserResults(query);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Utilizatorii cu cel putin o listare - Simpla 5/6
            string query = "SELECT U.username, COUNT(L.listing_id) AS 'Numar Listari' " +
               "FROM[User] U JOIN Listing L ON U.user_id = L.user_id " +
               "GROUP BY U.username " +
               "HAVING COUNT(L.listing_id) >= 1 ";
            displayUserResults(query);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Utilizatorii cu cel putin o listare in Bucuresti - Simpla 6/6
            string query = "SELECT U.username FROM[User] U " +
                "JOIN Listing L ON U.user_id = L.user_id " +
                "JOIN ListingProperty LP ON LP.listing_id = L.listing_id " +
                "JOIN Property P ON P.property_id = LP.property_id " +
                "WHERE P.address LIKE '%Bucuresti%'";
            displayUserResults(query);
        }

        private void displayUserInfo()
        {
            string query = "SELECT U.username, U.name, U.surname, U.email, U.phone_number FROM [User] U WHERE U.user_id = @userid";
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@userid", UserInfo.user_id);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView4.DataSource = dataTable;
            dbConnection.Close();
        }
        private void User_Load(object sender, EventArgs e)
        {
            displayUserInfo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string email = textRegEmail.Text;
            string phone = textRegPhone.Text;
            string name = textRegName.Text;
            string surname = textRegSurname.Text;

            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string queryInsertUser = "UPDATE [User]" +
                                     "SET(email = @email, phone_number = @phone, name = @name, surname = @surname) " +
                                     "WHERE [User].user_id = @id";
            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryInsertUser;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@id", UserInfo.user_id);
            command.ExecuteNonQuery();
            MessageBox.Show("Account updated succesfuly", "Succes", MessageBoxButtons.OK);
            displayUserInfo();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A3VFPEF\\SQLEXPRESS;Initial Catalog=Imobiliare;Integrated Security=True";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string queryInsertUser = "DELETE FROM [User] " +
                                     "WHERE [User].user_id = @id";
            SqlCommand command = new SqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = queryInsertUser;
            command.Parameters.AddWithValue("@id", UserInfo.user_id);
            command.ExecuteNonQuery();
            MessageBox.Show("Account deleted", "Delete", MessageBoxButtons.OK);
            Login userForm = new Login();
            if (userForm == null)
                userForm.Parent = this;
            userForm.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Login regForm = new Login();
            if (regForm == null)
                regForm.Parent = this;
            regForm.Show();
            this.Hide();
        }
    }
}
