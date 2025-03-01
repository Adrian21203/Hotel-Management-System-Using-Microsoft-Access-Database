using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form5 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";

        public Form5()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            
            dataGridView1.Columns.Clear();

           
            dataGridView1.Columns.Add("NumeClient", "Nume Client");
            dataGridView1.Columns.Add("NumarCamera", "Număr Cameră");
            dataGridView1.Columns.Add("PretZi", "Preț/Zi");
            dataGridView1.Columns.Add("DataCazarii", "Data Cazării");
            dataGridView1.Columns.Add("DataPlecare", "Data Plecare");
            dataGridView1.Columns.Add("NumarZile", "Număr Zile");
            dataGridView1.Columns.Add("Total", "Total");
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            string numeCautare = txtCautare.Text.Trim();

            if (string.IsNullOrEmpty(numeCautare))
            {
                MessageBox.Show("Vă rugăm introduceți un criteriu de căutare.", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = @"
                    SELECT 
                        C.NumeClient, 
                        Ca.NrCamera,
                        Cz.PretZi, 
                        Cz.DataCazare, 
                        Cz.DataPlecare,
                        (DATEDIFF('d', Cz.DataCazare, Cz.DataPlecare) * Cz.PretZi) AS Total
                    FROM 
                        (Clienti AS C
                    INNER JOIN 
                        CazariContinut AS Cz ON C.IdClient = Cz.IdClient)
                    INNER JOIN 
                        Camere AS Ca ON Cz.IdCamera = Ca.IdCamera
                    WHERE
                        (C.NumeClient LIKE ? OR 
                        Ca.NrCamera LIKE ? OR
                        Cz.DataCazare LIKE ? OR
                        Cz.DataPlecare LIKE ?)
                    ";

                    OleDbCommand command = new OleDbCommand(query, connection);

                   
                    string searchPattern = "%" + numeCautare + "%"; 
                    command.Parameters.AddWithValue("?", searchPattern);
                    command.Parameters.AddWithValue("?", searchPattern); 
                    command.Parameters.AddWithValue("?", searchPattern); 
                    command.Parameters.AddWithValue("?", searchPattern); 

                    OleDbDataReader reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        string numeClient = reader["NumeClient"].ToString();
                        string numarCamera = reader["NrCamera"].ToString();
                        decimal pretZi = Convert.ToDecimal(reader["PretZi"]);
                        DateTime dataCazarii = Convert.ToDateTime(reader["DataCazare"]);
                        DateTime dataPlecare = Convert.ToDateTime(reader["DataPlecare"]);
                        decimal total = Convert.ToDecimal(reader["Total"]);

                        
                        int numarZile = (dataPlecare - dataCazarii).Days;

                        
                        dataGridView1.Rows.Add(numeClient, numarCamera, pretZi, dataCazarii.ToShortDateString(), dataPlecare.ToShortDateString(), numarZile, total);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlecare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vă rugăm selectați un client pentru check-out.", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DialogResult result = MessageBox.Show("Sunteți sigur că doriți să finalizați plcarea?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            string numeClient = selectedRow.Cells["NumeClient"].Value.ToString();
            string nrCamera = selectedRow.Cells["NumarCamera"].Value.ToString();
            decimal pretZi = Convert.ToDecimal(selectedRow.Cells["PretZi"].Value);
            DateTime dataCazarii = Convert.ToDateTime(selectedRow.Cells["DataCazarii"].Value);
            DateTime dataPlecarii = Convert.ToDateTime(selectedRow.Cells["DataPlecare"].Value);
            decimal total = Convert.ToDecimal(selectedRow.Cells["Total"].Value);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    
                    string queryClient = "SELECT IdClient FROM Clienti WHERE NumeClient = ?";
                    OleDbCommand commandClient = new OleDbCommand(queryClient, connection);
                    commandClient.Parameters.AddWithValue("?", numeClient);
                    int idClient = Convert.ToInt32(commandClient.ExecuteScalar());

                    
                    string queryRezervare = "SELECT IdRezervare FROM Rezervari WHERE IdClient = ?";
                    OleDbCommand commandRezervare = new OleDbCommand(queryRezervare, connection);
                    commandRezervare.Parameters.AddWithValue("?", idClient);
                    int idRezervare = Convert.ToInt32(commandRezervare.ExecuteScalar());

                    
                    string queryCamera = "SELECT IdCamera FROM Camere WHERE NrCamera = ?";
                    OleDbCommand commandCamera = new OleDbCommand(queryCamera, connection);
                    commandCamera.Parameters.AddWithValue("?", nrCamera);
                    int idCamera = Convert.ToInt32(commandCamera.ExecuteScalar());

                    
                    string insertQuery = "INSERT INTO IstoricClienti (IdClient, IdCamera, PretZi, DataCazarii, DataPlecarii, Total) VALUES (?, ?, ?, ?, ?, ?)";
                    OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("?", idClient);
                    insertCommand.Parameters.AddWithValue("?", idCamera);
                    insertCommand.Parameters.AddWithValue("?", pretZi);
                    insertCommand.Parameters.AddWithValue("?", dataCazarii);
                    insertCommand.Parameters.AddWithValue("?", dataPlecarii);
                    insertCommand.Parameters.AddWithValue("?", total);
                    insertCommand.ExecuteNonQuery();

                   
                    string deleteCazariContinutQuery = "DELETE FROM CazariContinut WHERE IdClient = ?";
                    OleDbCommand deleteCazariContinutCommand = new OleDbCommand(deleteCazariContinutQuery, connection);
                    deleteCazariContinutCommand.Parameters.AddWithValue("?", idClient);
                    deleteCazariContinutCommand.ExecuteNonQuery();

                    
                    string deleteRezervareQuery = "DELETE FROM Rezervari WHERE IdRezervare = ?";
                    OleDbCommand deleteRezervareCommand = new OleDbCommand(deleteRezervareQuery, connection);
                    deleteRezervareCommand.Parameters.AddWithValue("?", idRezervare);
                    deleteRezervareCommand.ExecuteNonQuery();

                    
                    string deleteClientQuery = "DELETE FROM Clienti WHERE IdClient = ?";
                    OleDbCommand deleteClientCommand = new OleDbCommand(deleteClientQuery, connection);
                    deleteClientCommand.Parameters.AddWithValue("?", idClient);
                    deleteClientCommand.ExecuteNonQuery();

                    MessageBox.Show("Check-out realizat cu succes și datele salvate în IstoricClienti.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    dataGridView1.Rows.Remove(selectedRow);

                    
                    PrintBon(numeClient, nrCamera, pretZi, dataCazarii, dataPlecarii, total);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintBon(string numeClient, string nrCamera, decimal pretZi, DateTime dataCazarii, DateTime dataPlecarii, decimal total)
        {
            
            int numberOfLines = 8; 
            int lineHeight = 25; 
            int formHeight = (numberOfLines * lineHeight) + 100;

            
            Form bonForm = new Form
            {
                Text = "Bon Check-Out",
                Size = new Size(400, formHeight),
                StartPosition = FormStartPosition.CenterScreen
            };

            TextBox txtBon = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12),
                ScrollBars = ScrollBars.Vertical, 
                Text = "Hotel \r\n" +
                       "-------------------------\r\n" +
                       $"Client: {numeClient}\r\n" +
                       $"Camera: {nrCamera}\r\n" +
                       $"Preț/zi: {pretZi:C}\r\n" +
                       $"Data Cazării: {dataCazarii.ToShortDateString()}\r\n" +
                       $"Data Plecării: {dataPlecarii.ToShortDateString()}\r\n" +
                       $"Număr zile: {(dataPlecarii - dataCazarii).Days}\r\n" +
                       $"Total: {total:C}\r\n" +
                       "-------------------------\r\n" +
                       "Vă mulțumim pentru vizită!"
            };

            Button btnPrint = new Button
            {
                Text = "Printare",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnPrint.Click += (s, e) =>
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (sender, ev) =>
                {
                    ev.Graphics.DrawString(txtBon.Text, new Font("Arial", 10), Brushes.Black, new PointF(10, 10));
                };
                PrintDialog printDialog = new PrintDialog { Document = printDocument };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            };

            bonForm.Controls.Add(txtBon);
            bonForm.Controls.Add(btnPrint);

            
            bonForm.FormClosed += (s, e) =>
            {
                txtCautare.Text = ""; 
            };

            bonForm.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void camereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }

        private void rezervariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Close();
        }
    }
}

