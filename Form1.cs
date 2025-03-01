using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vă rugăm să completați atât username-ul cât și parola.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            
                            this.Hide();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Numele de utilizator sau parola sunt incorecte.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la conectarea la baza de date: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
