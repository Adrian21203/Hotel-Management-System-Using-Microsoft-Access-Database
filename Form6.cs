using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form6 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
        private bool isAdding = false;
        private int currentRezervareId = -1; 

        public Form6()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            R.IdRezervare,
                            C.IdClient,
                            Ca.IdCamera,
                            C.NumeClient AS [Nume],
                            C.NrTelefon AS [Telefon],
                            R.DataRezervarii AS [Data Rezervarii],
                            RC.DataCazarii AS [Data Cazarii],
                            RC.PretZi AS [Pret/zi],
                            RC.NrZile AS [Numar Zile],
                            Ca.NrCamera AS [Numar Camera]
                        FROM 
                            ((Clienti AS C
                        INNER JOIN 
                            Rezervari AS R ON C.IdClient = R.IdClient)
                        INNER JOIN 
                            RezervariContinut AS RC ON R.IdRezervare = RC.IdRezervare)
                        INNER JOIN 
                            Camere AS Ca ON RC.IdCamera = Ca.IdCamera";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                       
                        dataGridView1.Columns["IdClient"].Visible = false;
                        dataGridView1.Columns["IdRezervare"].Visible = false;
                        dataGridView1.Columns["IdCamera"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea datelor: " + ex.Message);
            }
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            isAdding = true;
            btnModificare.Visible = false;
            btnStergere.Visible = false;
            ResetFields();
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                btnAdaugare.Visible = false;
                btnStergere.Visible = false;

                
                currentRezervareId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdRezervare"].Value);

                
                txtNumeClient.Text = dataGridView1.SelectedRows[0].Cells["Nume"].Value.ToString();
                txtNumarTelefon.Text = dataGridView1.SelectedRows[0].Cells["Telefon"].Value.ToString();
                txtNumarZile.Text = dataGridView1.SelectedRows[0].Cells["Numar Zile"].Value.ToString();
                txtNumarCamera.Text = dataGridView1.SelectedRows[0].Cells["Numar Camera"].Value.ToString();
                dtpDataCazarii.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["Data Cazarii"].Value);
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați o rezervare pentru modificare.");
            }
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtNumeClient.Text) ||
                string.IsNullOrWhiteSpace(txtNumarTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtNumarZile.Text) ||
                string.IsNullOrWhiteSpace(txtNumarCamera.Text))
            {
                MessageBox.Show("Toate câmpurile sunt obligatorii. Completați numele clientului, numărul de telefon, numărul de zile și numărul camerei.");
                return;
            }

            
            string nrTelefon = txtNumarTelefon.Text.Trim();
            if (!IsPhoneNumberValid(nrTelefon))
            {
                MessageBox.Show("Numărul de telefon este invalid. Trebuie să conțină doar cifre și să aibă 10 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            DateTime dataCurenta = DateTime.Now.Date;

            
            DateTime dataCazarii = dtpDataCazarii.Value.Date;

           
            if (dataCazarii < dataCurenta)
            {
                MessageBox.Show("Data cazării trebuie să fie mai mare sau egală cu data curentă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (int.TryParse(txtNumarZile.Text.Trim(), out int numarZile))
            {
                if (numarZile <= 0)
                {
                    MessageBox.Show("Numărul de zile trebuie să fie mai mare decât 0.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Numărul de zile trebuie să fie un număr valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (int.TryParse(txtNumarCamera.Text.Trim(), out int numarCamera))
            {
                if (numarCamera <= 0)
                {
                    MessageBox.Show("Numărul camerei trebuie să fie mai mare decât 0.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Numărul camerei trebuie să fie un număr valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            int idCamera = GetCameraId(numarCamera);
            if (idCamera == -1)
            {
                MessageBox.Show($"Camera cu numărul {numarCamera} nu există în baza de date.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)  // Adaugare
            {
                var confirmResult = MessageBox.Show("Sunteți sigur că doriți să adăugați această rezervare?",
                                                     "Confirmare adăugare",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        
                        if (!IsCameraAvailable(idCamera, dataCazarii, -1))
                        {
                            MessageBox.Show($"Camera cu numărul {numarCamera} este deja rezervată pentru data selectată.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        
                        string numeClient = txtNumeClient.Text.Trim();
                        string numarTelefon = txtNumarTelefon.Text.Trim();
                        DateTime dataRezervarii = DateTime.Now.Date;

                        
                        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                            
                            string queryInsertClient = "INSERT INTO Clienti (NumeClient, NrTelefon) VALUES (@NumeClient, @NrTelefon)";
                            using (OleDbCommand cmdInsertClient = new OleDbCommand(queryInsertClient, conn))
                            {
                                cmdInsertClient.Parameters.AddWithValue("@NumeClient", numeClient);
                                cmdInsertClient.Parameters.AddWithValue("@NrTelefon", numarTelefon);
                                cmdInsertClient.ExecuteNonQuery();
                            }

                            
                            int clientId = (int)new OleDbCommand("SELECT @@IDENTITY", conn).ExecuteScalar();

                            
                            string queryInsertRezervare = "INSERT INTO Rezervari (IdClient, DataRezervarii) VALUES (@IdClient, @DataRezervarii)";
                            using (OleDbCommand cmdInsertRezervare = new OleDbCommand(queryInsertRezervare, conn))
                            {
                                cmdInsertRezervare.Parameters.AddWithValue("@IdClient", clientId);
                                cmdInsertRezervare.Parameters.AddWithValue("@DataRezervarii", dataRezervarii);
                                cmdInsertRezervare.ExecuteNonQuery();
                            }

                            
                            int rezervareId = (int)new OleDbCommand("SELECT @@IDENTITY", conn).ExecuteScalar();

                            
                            string queryGetPretZi = "SELECT PretZi FROM Camere WHERE IdCamera = @IdCamera";
                            using (OleDbCommand cmdGetPretZi = new OleDbCommand(queryGetPretZi, conn))
                            {
                                cmdGetPretZi.Parameters.AddWithValue("@IdCamera", idCamera);
                                var result = cmdGetPretZi.ExecuteScalar();
                                decimal pretZi = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                                
                                string queryInsertContinut = "INSERT INTO RezervariContinut (IdRezervare, IdCamera, NrZile, DataCazarii, PretZi) VALUES (@IdRezervare, @IdCamera, @NrZile, @DataCazarii, @PretZi)";
                                using (OleDbCommand cmdInsertContinut = new OleDbCommand(queryInsertContinut, conn))
                                {
                                    cmdInsertContinut.Parameters.AddWithValue("@IdRezervare", rezervareId);
                                    cmdInsertContinut.Parameters.AddWithValue("@IdCamera", idCamera);
                                    cmdInsertContinut.Parameters.AddWithValue("@NrZile", numarZile);
                                    cmdInsertContinut.Parameters.AddWithValue("@DataCazarii", dataCazarii);
                                    cmdInsertContinut.Parameters.AddWithValue("@PretZi", pretZi);  
                                    cmdInsertContinut.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Rezervarea a fost adăugată cu succes!");

                            
                            LoadData();

                           
                            ResetFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la adăugarea rezervării: " + ex.Message);
                    }

                    
                    btnModificare.Visible = true;   
                    btnStergere.Visible = true;
                }
            }
            else  // Modificare
            {
                var confirmResult = MessageBox.Show("Sunteți sigur că doriți să modificați această rezervare?",
                                                     "Confirmare modificare",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        
                        if (!IsCameraAvailable(idCamera, dataCazarii, currentRezervareId))
                        {
                            MessageBox.Show($"Camera cu numărul {numarCamera} este deja rezervată pentru data selectată.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        
                        string numeClient = txtNumeClient.Text.Trim();
                        string numarTelefon = txtNumarTelefon.Text.Trim();
                        DateTime dataRezervarii = DateTime.Now.Date;

                       
                        int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdClient"].Value);

                        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                            
                            string queryUpdateClient = "UPDATE Clienti SET NumeClient = @NumeClient, NrTelefon = @NrTelefon WHERE IdClient = @IdClient";
                            using (OleDbCommand cmdUpdateClient = new OleDbCommand(queryUpdateClient, conn))
                            {
                                cmdUpdateClient.Parameters.AddWithValue("@NumeClient", numeClient);
                                cmdUpdateClient.Parameters.AddWithValue("@NrTelefon", numarTelefon);
                                cmdUpdateClient.Parameters.AddWithValue("@IdClient", clientId);

                                cmdUpdateClient.ExecuteNonQuery();
                            }

                            
                            string queryUpdateRezervare = "UPDATE Rezervari SET DataRezervarii = @DataRezervarii WHERE IdRezervare = @IdRezervare";
                            using (OleDbCommand cmdUpdateRezervare = new OleDbCommand(queryUpdateRezervare, conn))
                            {
                                cmdUpdateRezervare.Parameters.AddWithValue("@DataRezervarii", dataRezervarii);
                                cmdUpdateRezervare.Parameters.AddWithValue("@IdRezervare", currentRezervareId);

                                cmdUpdateRezervare.ExecuteNonQuery();
                            }

                            
                            string queryGetPretZi = "SELECT PretZi FROM Camere WHERE IdCamera = @IdCamera";
                            using (OleDbCommand cmdGetPretZi = new OleDbCommand(queryGetPretZi, conn))
                            {
                                cmdGetPretZi.Parameters.AddWithValue("@IdCamera", idCamera);
                                var result = cmdGetPretZi.ExecuteScalar();
                                decimal pretZi = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                                
                                string queryUpdateContinut = @"
                                UPDATE RezervariContinut 
                                SET DataCazarii = @DataCazarii, NrZile = @NrZile, IdCamera = @IdCamera, PretZi = @PretZi
                                WHERE IdRezervare = @IdRezervare";
                                using (OleDbCommand cmdUpdateContinut = new OleDbCommand(queryUpdateContinut, conn))
                                {
                                    cmdUpdateContinut.Parameters.AddWithValue("@DataCazarii", dataCazarii);
                                    cmdUpdateContinut.Parameters.AddWithValue("@NrZile", numarZile);
                                    cmdUpdateContinut.Parameters.AddWithValue("@IdCamera", idCamera);
                                    cmdUpdateContinut.Parameters.AddWithValue("@PretZi", pretZi); 
                                    cmdUpdateContinut.Parameters.AddWithValue("@IdRezervare", currentRezervareId);

                                    cmdUpdateContinut.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Rezervarea a fost modificată cu succes!");

                            
                            LoadData();

                            
                            ResetFields();
                            btnAdaugare.Visible = true;
                            btnStergere.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la modificarea rezervării: " + ex.Message);
                    }
                }
            }
        }

        private void ResetFields()
        {
            txtNumeClient.Clear();
            txtNumarTelefon.Clear();
            txtNumarZile.Clear();
            txtNumarCamera.Clear();
            dtpDataCazarii.Value = DateTime.Now;
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _);
        }

        private int GetCameraId(int numarCamera)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdCamera FROM Camere WHERE NrCamera = @NrCamera";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NrCamera", numarCamera);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la obținerea ID-ului camerei: " + ex.Message);
                return -1;
            }
        }

        private bool IsCameraAvailable(int idCamera, DateTime dataCazarii, int currentRezervareId)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM RezervariContinut 
                        WHERE IdCamera = @IdCamera AND DataCazarii = @DataCazarii AND IdRezervare <> @IdRezervare";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdCamera", idCamera);
                        cmd.Parameters.AddWithValue("@DataCazarii", dataCazarii);
                        cmd.Parameters.AddWithValue("@IdRezervare", currentRezervareId);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la verificarea disponibilității camerei: " + ex.Message);
                return false;
            }
        }


        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            ResetStare();
        }

        private void ResetStare()
        {
            ResetFields();
            btnAdaugare.Visible = true;
            btnModificare.Visible = true;
            btnStergere.Visible = true;
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Sunteți sigur că doriți să ștergeți această rezervare?",
                                                     "Confirmare ștergere",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        int rezervareId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdRezervare"].Value);
                        int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdClient"].Value);

                        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();


                            string deleteContinutQuery = "DELETE FROM RezervariContinut WHERE IdRezervare = @IdRezervare";
                            using (OleDbCommand cmdDeleteContinut = new OleDbCommand(deleteContinutQuery, conn))
                            {
                                cmdDeleteContinut.Parameters.AddWithValue("@IdRezervare", rezervareId);
                                cmdDeleteContinut.ExecuteNonQuery();
                            }


                            string deleteRezervareQuery = "DELETE FROM Rezervari WHERE IdRezervare = @IdRezervare";
                            using (OleDbCommand cmdDeleteRezervare = new OleDbCommand(deleteRezervareQuery, conn))
                            {
                                cmdDeleteRezervare.Parameters.AddWithValue("@IdRezervare", rezervareId);
                                cmdDeleteRezervare.ExecuteNonQuery();
                            }


                            string deleteClientQuery = "DELETE FROM Clienti WHERE IdClient = @IdClient";
                            using (OleDbCommand cmdDeleteClient = new OleDbCommand(deleteClientQuery, conn))
                            {
                                cmdDeleteClient.Parameters.AddWithValue("@IdClient", clientId);
                                cmdDeleteClient.ExecuteNonQuery();
                            }

                            MessageBox.Show("Rezervarea a fost ștearsă cu succes!");


                            LoadData();
                            ResetStare();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la ștergerea rezervării: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați o rezervare pentru ștergere.");
            }
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

    }
}

