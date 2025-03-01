using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form2 : Form
    {
        private DataTable originalDataTable;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            ConfigureDataGridView(true);
        }

        
        private void LoadData()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = @"
            SELECT 
                C.NumeClient AS [Nume], 
                C.NrTelefon AS [Telefon],
                Cz.DataCazare AS [Data Cazare],
                Cz.PretZi AS [Pret/zi],
                Cz.NumarZile AS [Numar Zile], 
                Ca.NrCamera AS [Numar Camera],
                Cz.DataPlecare AS [Data Plecare]
            FROM 
                (Clienti C
            INNER JOIN 
                CazariContinut Cz ON C.IdClient = Cz.IdClient)
            INNER JOIN 
                Camere Ca ON Cz.IdCamera = Ca.IdCamera";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    originalDataTable = new DataTable();
                    adapter.Fill(originalDataTable);
                    dataGridView1.DataSource = originalDataTable.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
        }

       
        private void ConfigureDataGridView(bool isReadOnly)
        {
            dataGridView1.ReadOnly = isReadOnly;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            
            dataGridView1.Columns["Data Cazare"].ReadOnly = true;
            dataGridView1.Columns["Numar Zile"].ReadOnly = true;

            btnActualizare.Enabled = isReadOnly;
            btnSalvare.Visible = !isReadOnly;
            btnRenuntare.Visible = !isReadOnly;
        }

        
        private void btnActualizare_Click(object sender, EventArgs e)
        {
            ConfigureDataGridView(false);
        }

        
        private void btnSalvare_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ești sigur că dorești să salvezi modificările?",
                "Confirmare salvare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SaveDataChanges();
                    MessageBox.Show("Modificările au fost salvate cu succes.");
                    ConfigureDataGridView(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la salvarea datelor: " + ex.Message);
                }
            }
        }

        
        private void SaveDataChanges()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    
                    if (IsRowModified(row) && IsRowValid(row))
                    {
                        try
                        {
                            
                            int idClient = GetIdClientByNume(conn, row.Cells["Nume"].Value.ToString());
                            int idCamera = GetIdCameraByNrCamera(conn, row.Cells["Numar Camera"].Value.ToString());

                            
                            string nrTelefon = row.Cells["Telefon"].Value?.ToString().Trim();
                            if (!IsPhoneNumberValid(nrTelefon))
                            {
                                MessageBox.Show($"Numărul de telefon pentru clientul '{row.Cells["Nume"].Value}' este invalid. Trebuie să conțină doar cifre și să aibă 10 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            
                            if (!DateTime.TryParse(row.Cells["Data Plecare"].Value?.ToString(), out DateTime dataPlecare))
                            {
                                MessageBox.Show($"Data plecării pentru clientul '{row.Cells["Nume"].Value}' este invalidă. Trebuie să fie în formatul dd/mm/yyyy.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            DateTime dataCazare = Convert.ToDateTime(row.Cells["Data Cazare"].Value);
                            if (dataPlecare < dataCazare)
                            {
                                MessageBox.Show($"Data plecării pentru clientul '{row.Cells["Nume"].Value}' trebuie să fie mai mare sau egală cu data cazării.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            
                            int numarZile = (dataPlecare - dataCazare).Days;
                            row.Cells["Numar Zile"].Value = numarZile;

                            
                            if (!IsCameraAvailableWithoutReservation(idCamera, dataCazare))
                            {
                                MessageBox.Show($"Camera cu numărul {row.Cells["Numar Camera"].Value} este deja rezervată pentru data selectată.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            
                            decimal pretZi = GetPretZiByNumarCamera(row.Cells["Numar Camera"].Value.ToString());
                            row.Cells["Pret/zi"].Value = pretZi;

                            
                            string updateClientiQuery = @"
                        UPDATE Clienti 
                        SET NrTelefon = ?, NumeClient = ? 
                        WHERE IdClient = ?";
                            using (OleDbCommand cmd = new OleDbCommand(updateClientiQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("?", nrTelefon);
                                cmd.Parameters.AddWithValue("?", row.Cells["Nume"].Value?.ToString());
                                cmd.Parameters.AddWithValue("?", idClient); 
                                cmd.ExecuteNonQuery();
                            }

                            
                            string updateCazariContinutQuery = @"
                        UPDATE CazariContinut
                        SET DataPlecare = ?, NumarZile = ?, PretZi = ? 
                        WHERE IdClient = ? AND IdCamera = ?";
                            using (OleDbCommand cmd = new OleDbCommand(updateCazariContinutQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("?", dataPlecare);
                                cmd.Parameters.AddWithValue("?", numarZile);
                                cmd.Parameters.AddWithValue("?", pretZi); 
                                cmd.Parameters.AddWithValue("?", idClient);
                                cmd.Parameters.AddWithValue("?", idCamera);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Eroare la salvarea rândului cu NumeClient '{row.Cells["Nume"].Value}': {ex.Message}");
                        }
                    }
                }
            }
        }


        
        private bool IsRowModified(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                string columnName = cell.OwningColumn.Name;
                object newValue = cell.Value;
                object originalValue = originalDataTable.Rows[row.Index][columnName];

                if (!Equals(newValue, originalValue))
                {
                    return true;
                }
            }
            return false;
        }

        
        private bool IsRowValid(DataGridViewRow row)
        {
            return row.Cells["Data Cazare"].Value != null &&
                   row.Cells["Pret/zi"].Value != null &&
                   row.Cells["Numar Zile"].Value != null &&
                   row.Cells["Nume"].Value != null &&
                   row.Cells["Numar Camera"].Value != null &&
                   row.Cells["Data Plecare"].Value != null;
        }

        
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _);
        }

        // Verificare disponibilitate cameră
        private bool IsCameraAvailable(int idCamera, DateTime dataCazare, int idRezervare)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = @"
                SELECT COUNT(*) 
                FROM CazariContinut 
                WHERE IdCamera = ? AND DataCazare = ? AND IdRezervare <> ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idCamera);
                    cmd.Parameters.AddWithValue("?", dataCazare);
                    cmd.Parameters.AddWithValue("?", idRezervare);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0;
                }
            }
        }

        
        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Ești sigur că dorești să renunți la modificări?",
                "Confirmare renunțare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.DataSource = originalDataTable.Copy();
                ConfigureDataGridView(true);
            }
        }

        
        private void btnCazare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

       
        private void btnCautare_Click(object sender, EventArgs e)
        {
            string searchText = txtCautare.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                
                dataGridView1.DataSource = originalDataTable.Copy();
                return;
            }

            try
            {
                DataView dataView = new DataView(originalDataTable);

                
                if (int.TryParse(searchText, out int searchNumber))
                {
                    
                    dataView.RowFilter = $"Telefon = {searchNumber}";
                }
                else
                {
                   
                    dataView.RowFilter = $"Nume LIKE '%{searchText}%'";
                }

                dataGridView1.DataSource = dataView;

                if (dataView.Count == 0)
                {
                    MessageBox.Show("Nu s-au găsit rezultate pentru căutarea introdusă.", "Căutare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la căutare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlecare_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private void rezervariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form6 form6 = new Form6();
            form6.Show();
            this.Close(); 
        }

        private void camereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form4 form4 = new Form4();
            form4.Show();
            this.Close(); 
        }



        private int GetIdClientByNume(OleDbConnection conn, string numeClient)
        {
            string query = "SELECT IdClient FROM Clienti WHERE NumeClient = ?";

            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", numeClient);

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int idClient))
                {
                    return idClient;
                }
                else
                {
                    throw new Exception($"Nu a fost găsit niciun client cu numele: {numeClient}.");
                }
            }
        }

        private int GetIdCameraByNrCamera(OleDbConnection conn, string nrCamera)
        {
            string query = "SELECT IdCamera FROM Camere WHERE NrCamera = ?";

            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", nrCamera);

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int idCamera))
                {
                    return idCamera;
                }
                else
                {
                    throw new Exception($"Nu a fost găsită nicio cameră cu numărul: {nrCamera}.");
                }


            }

        }
        private bool IsCameraAvailableWithoutReservation(int idCamera, DateTime dataCazare)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = @"
        SELECT COUNT(*) 
        FROM CazariContinut 
        WHERE IdCamera = ? AND DataCazare = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idCamera);
                    cmd.Parameters.AddWithValue("?", dataCazare);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0; 
                }
            }
        }

        private decimal GetPretZiByNumarCamera(string numarCamera)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = "SELECT PretZi FROM Camere WHERE NrCamera = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", numarCamera);

                    object result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal pretZi))
                    {
                        return pretZi;
                    }
                    else
                    {
                        throw new Exception($"Nu a fost găsit prețul pentru camera cu numărul: {numarCamera}");
                    }
                }

            }
        }
    }
}
