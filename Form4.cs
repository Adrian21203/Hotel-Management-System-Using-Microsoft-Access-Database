using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form4 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
        private bool isEditMode = false;
        public Form4()
        {
            InitializeComponent();

            comboBoxEtaj.Items.AddRange(new object[] { 1, 2, 3, 4 });
            comboBoxEtaj.SelectedIndex = 0;

            LoadCamereData();

            ResetareCâmpuri();
        }

        private void LoadCamereData()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM camere";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}");
            }
        }
        private void ResetareCâmpuri()
        {
            txtNumarCamera.Clear();
            txtNumarLocuri.Clear();
            txtPretZi.Clear();
            txtPoza.Clear();
            pictureBox1.Image = null;

 
            txtNumarCamera.Visible = true;
            txtNumarLocuri.Visible = true;
            txtPretZi.Visible = true;
            txtPoza.Visible = true;
            pictureBox1.Visible = true;
            comboBoxEtaj.Visible = true;

            btnConfirmare.Visible = false; 
            btnRenuntare.Visible = false;   

            btnAdaugare.Visible = true;
            btnModificare.Visible = true;
            btnStergere.Visible = true;
        }


        private void InserareCamera()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumarCamera.Text) ||
                    string.IsNullOrWhiteSpace(txtNumarLocuri.Text) ||
                    comboBoxEtaj.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtPretZi.Text) ||
                    string.IsNullOrWhiteSpace(txtPoza.Text))
                {
                    MessageBox.Show("Toate câmpurile trebuie completate.");
                    return;
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO camere (NrCamera, NrLocuri, Etaj, PretZi, SpImagine) VALUES (@numarCamera, @numarLocuri, @etaj, @pretZi, @poza)";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("@numarCamera", txtNumarCamera.Text);
                    command.Parameters.AddWithValue("@numarLocuri", txtNumarLocuri.Text);
                    command.Parameters.AddWithValue("@etaj", comboBoxEtaj.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@pretZi", txtPretZi.Text);
                    command.Parameters.AddWithValue("@poza", txtPoza.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Camera a fost adăugată cu succes!");
                    LoadCamereData();
                    ResetareCâmpuri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la inserare: {ex.Message}");
            }
        }

        private void txtPoza_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPoza.Text = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            ResetareCâmpuri();
            txtNumarCamera.Visible = true;
            txtNumarLocuri.Visible = true;
            txtPretZi.Visible = true;
            txtPoza.Visible = true;
            pictureBox1.Visible = true;
            comboBoxEtaj.Visible = true;

            btnConfirmare.Visible = true;
            btnRenuntare.Visible = true;

            btnAdaugare.Visible = true;
            btnModificare.Visible = false;
            btnStergere.Visible = false;
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                int idCamera = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdCamera"].Value);
                BtnConfirmare_Modificare(idCamera);
            }
            else
            {
                InserareCamera();
            }
        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            ResetareCâmpuri();
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                isEditMode = true;
                int idCamera = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdCamera"].Value);

                txtNumarCamera.Text = dataGridView1.SelectedRows[0].Cells["NrCamera"].Value.ToString();
                txtNumarLocuri.Text = dataGridView1.SelectedRows[0].Cells["NrLocuri"].Value.ToString();
                comboBoxEtaj.SelectedItem = dataGridView1.SelectedRows[0].Cells["Etaj"].Value.ToString();
                txtPretZi.Text = dataGridView1.SelectedRows[0].Cells["PretZi"].Value.ToString();
                txtPoza.Text = dataGridView1.SelectedRows[0].Cells["SpImagine"].Value.ToString();

                if (File.Exists(txtPoza.Text))
                {
                    pictureBox1.Image = Image.FromFile(txtPoza.Text);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                txtNumarCamera.Visible = true;
                txtNumarLocuri.Visible = true;
                txtPretZi.Visible = true;
                txtPoza.Visible = true;
                pictureBox1.Visible = true;
                comboBoxEtaj.Visible = true;

                btnConfirmare.Visible = true;
                btnRenuntare.Visible = true;

                btnAdaugare.Visible = false;
                btnStergere.Visible = false;
            }
            else
            {
                MessageBox.Show("Selectează o cameră pentru a o modifica.");
            }
        }

        private void BtnConfirmare_Modificare(int idCamera)
        {
            if (string.IsNullOrWhiteSpace(txtNumarCamera.Text) || !int.TryParse(txtNumarCamera.Text, out int nrCamera) || nrCamera <= 0)
            {
                MessageBox.Show("Numărul camerei trebuie să fie un număr valid mai mare decât 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumarLocuri.Text) || !int.TryParse(txtNumarLocuri.Text, out int nrLocuri) || nrLocuri <= 0)
            {
                MessageBox.Show("Numărul locurilor trebuie să fie un număr valid mai mare decât 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPretZi.Text) || !decimal.TryParse(txtPretZi.Text, out decimal pretZi) || pretZi <= 0)
            {
                MessageBox.Show("Prețul pe zi trebuie să fie un număr valid mai mare decât 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPoza.Text) || !File.Exists(txtPoza.Text) ||
                !txtPoza.Text.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) &&
                !txtPoza.Text.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                !txtPoza.Text.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Calea imaginii trebuie să fie validă și să aibă extensia .jpg, .jpeg sau .png.");
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE camere SET NrCamera = @nrCamera, NrLocuri = @nrLocuri, Etaj = @etaj, PretZi = @pretZi, SpImagine = @spImagine WHERE IdCamera = @idCamera";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nrCamera", nrCamera);
                        command.Parameters.AddWithValue("@nrLocuri", nrLocuri);
                        command.Parameters.AddWithValue("@etaj", comboBoxEtaj.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@pretZi", pretZi);
                        command.Parameters.AddWithValue("@spImagine", txtPoza.Text);
                        command.Parameters.AddWithValue("@idCamera", idCamera);  

                        command.ExecuteNonQuery();
                    }
                }

                
                MessageBox.Show("Camera a fost modificată cu succes!");
                LoadCamereData();  
                ResetareCâmpuri(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la modificare: {ex.Message}");
            }
        }



      
        private void btnStergere_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int idCamera = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdCamera"].Value);

               
                DialogResult result = MessageBox.Show("Sigur dorești să ștergi această cameră?", "Confirmare ștergere", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                           
                            string query = "DELETE FROM camere WHERE IdCamera = @id";
                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", idCamera);
                                command.ExecuteNonQuery();
                            }
                        }

                        
                        MessageBox.Show("Camera a fost ștearsă cu succes!");
                        LoadCamereData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la ștergere: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectează o cameră pentru a o șterge.");
            }
        }

        private void rezervariToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form6 form6 = new Form6();
            form6.Show();
            this.Close(); 
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Form2 form2 = new Form2();
            form2.Show();
            this.Close(); 
        }
    }
}

