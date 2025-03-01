using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProiectHotel
{
    public partial class Form7 : Form
    {
        private string numeClient;
        private string numarTelefon;
        private string dataCazare;
        private string numarZile;
        private string dataPlecare;
        private string numarCamera;

       
        public Form7(string numeClient, string numarTelefon, string dataCazare, string numarZile, string dataPlecare, string numarCamera, int idRezervare, int idCamera, decimal pretZi)
        {
            InitializeComponent();

 
            this.numeClient = numeClient;
            this.numarTelefon = numarTelefon;
            this.dataCazare = dataCazare;
            this.numarZile = numarZile;
            this.dataPlecare = dataPlecare;
            this.numarCamera = numarCamera;

  
            if (DateTime.TryParse(dataCazare, out DateTime dataCazareParsed))
            {
                dateTimePicker1.Value = dataCazareParsed;
            }
            else
            {
                MessageBox.Show("Data Cazarii invalida.");
            }

            if (DateTime.TryParse(dataPlecare, out DateTime dataPlecareParsed))
            {
                dateTimePicker2.Value = dataPlecareParsed;
            }
            else
            {
                MessageBox.Show("Data Plecarii invalida.");
            }

           
            txtNumeClient.Text = numeClient;
            txtNumarTelefon.Text = numarTelefon;
            txtNumarZile.Text = numarZile;
            txtNumarCamera.Text = numarCamera;
            txtPretZi.Text = pretZi.ToString("C"); 
        }

  
        public Form7()
        {
            InitializeComponent();
        }

        
        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            
            int clientId = GetClientId(numeClient, numarTelefon);

            if (clientId == -1)
            {
                MessageBox.Show("Clientul nu există în baza de date!");
                return;
            }


            int nrCrt = GetNextNrCrt();

  
            int idRezervare = GetIdRezervare(clientId);

            decimal pretZi;
            if (!decimal.TryParse(txtPretZi.Text, out pretZi))
            {
                MessageBox.Show("Prețul pe zi este invalid!");
                return;
            }

        
            DateTime dataCazare = dateTimePicker1.Value;
            DateTime dataPlecare = dateTimePicker2.Value;
            int numarZile = int.Parse(txtNumarZile.Text);
            int idCamera = int.Parse(txtNumarCamera.Text);

            
            AddCazareContinut(clientId, dataCazare, dataPlecare, numarZile, idCamera, nrCrt, idRezervare, pretZi);

            
            DeleteRezervari(idRezervare);

          
            MessageBox.Show("Cazarea a fost finalizată cu succes!");

            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

       
        private void DeleteRezervari(int idRezervare)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                
                conn.Open();

                
                string queryContinut = "DELETE FROM RezervariContinut WHERE IdRezervare = @idRezervare";
                OleDbCommand cmdContinut = new OleDbCommand(queryContinut, conn);
                cmdContinut.Parameters.AddWithValue("@idRezervare", idRezervare);
                cmdContinut.ExecuteNonQuery();

                
                string queryRezervari = "DELETE FROM Rezervari WHERE IdRezervare = @idRezervare";
                OleDbCommand cmdRezervari = new OleDbCommand(queryRezervari, conn);
                cmdRezervari.Parameters.AddWithValue("@idRezervare", idRezervare);
                cmdRezervari.ExecuteNonQuery();
            }
        }

        
        private int GetClientId(string numeClient, string numarTelefon)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = "SELECT IdClient FROM Clienti WHERE NumeClient = @numeClient AND NrTelefon = @numarTelefon";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@numeClient", numeClient);
                cmd.Parameters.AddWithValue("@numarTelefon", numarTelefon);

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
        }

       
        private int GetIdRezervare(int clientId)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = "SELECT IdRezervare FROM Rezervari WHERE IdClient = @clientId";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientId", clientId);

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
        }

        
        private int GetNextNrCrt()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = "SELECT MAX(NrCrt) FROM CazariContinut";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) + 1 : 1; // Daca nu exista nicio cazare, începe de la 1
            }
        }

       
        private void AddCazareContinut(int clientId, DateTime dataCazare, DateTime dataPlecare, int numarZile, int idCamera, int nrCrt, int idRezervare, decimal pretZi)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\win\source\repos\ProiectHotel\AplicatieHotel.accdb";
            string query = @"
                INSERT INTO CazariContinut (IdClient, DataCazare, DataPlecare, NumarZile, IdCamera, NrCrt, IdRezervare, PretZi)
                VALUES (@clientId, @dataCazare, @dataPlecare, @numarZile, @idCamera, @nrCrt, @idRezervare, @pretZi)";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@dataCazare", dataCazare);
                cmd.Parameters.AddWithValue("@dataPlecare", dataPlecare);
                cmd.Parameters.AddWithValue("@numarZile", numarZile);
                cmd.Parameters.AddWithValue("@idCamera", idCamera);
                cmd.Parameters.AddWithValue("@nrCrt", nrCrt);
                cmd.Parameters.AddWithValue("@idRezervare", idRezervare);
                cmd.Parameters.AddWithValue("@pretZi", pretZi);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close(); 
        }
    }
}
