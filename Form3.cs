using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string searchTerm = "")
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";

            string query = @"
                SELECT 
                    C.NumeClient AS [Nume], 
                    C.NrTelefon AS [Telefon],
                    RC.DataCazarii AS [Data Cazarii], 
                    RC.PretZi AS [Pret/zi],
                    RC.NrZile AS [Numar Zile], 
                    Ca.NrCamera AS [Numar Camera],
                    RC.IdRezervare
                FROM 
                    ((Clienti AS C
                INNER JOIN 
                    Rezervari AS R ON C.IdClient = R.IdClient)
                INNER JOIN 
                    RezervariContinut AS RC ON R.IdRezervare = RC.IdRezervare)
                INNER JOIN 
                    Camere AS Ca ON RC.IdCamera = Ca.IdCamera";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE C.NumeClient LIKE @searchTerm";
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn);

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtCautare.Text;
            LoadData(searchTerm);
        }

        
        private void btnFinalizeazaCazare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

         
                string numeClient = selectedRow.Cells["Nume"].Value.ToString();
                string numarTelefon = selectedRow.Cells["Telefon"].Value.ToString();
                string dataCazare = selectedRow.Cells["Data Cazarii"].Value.ToString();
                string numarZile = selectedRow.Cells["Numar Zile"].Value.ToString();
                string numarCamera = selectedRow.Cells["Numar Camera"].Value.ToString();
                int idRezervare = Convert.ToInt32(selectedRow.Cells["IdRezervare"].Value); 
                int idCamera = Convert.ToInt32(selectedRow.Cells["Numar Camera"].Value); 
                decimal pretZi = Convert.ToDecimal(selectedRow.Cells["Pret/zi"].Value); 

                
                DateTime dataCazareParsed;
                if (DateTime.TryParse(dataCazare, out dataCazareParsed))
                {
                    int zile = int.TryParse(numarZile, out zile) ? zile : 0;
                    DateTime dataPlecareCalculated = dataCazareParsed.AddDays(zile);
                    string dataPlecare = dataPlecareCalculated.ToString("yyyy-MM-dd"); 

                    
                    Form7 form7 = new Form7(numeClient, numarTelefon, dataCazare, numarZile, dataPlecare, numarCamera, idRezervare, idCamera, pretZi);
                    form7.Show();
                }
                else
                {
                    MessageBox.Show("Data cazarii este invalida.");
                }
            }
            else
            {
                
                Form7 form7 = new Form7();
                form7.Show();
            }

            this.Close();
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
