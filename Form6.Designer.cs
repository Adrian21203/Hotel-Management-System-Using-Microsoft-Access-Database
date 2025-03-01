namespace ProiectHotel
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumarCamera = new System.Windows.Forms.Label();
            this.lblNumarZile = new System.Windows.Forms.Label();
            this.lblDataCazarii = new System.Windows.Forms.Label();
            this.lblNumarTelefon = new System.Windows.Forms.Label();
            this.lblNumeClient = new System.Windows.Forms.Label();
            this.dtpDataCazarii = new System.Windows.Forms.DateTimePicker();
            this.txtNumarCamera = new System.Windows.Forms.TextBox();
            this.txtNumarZile = new System.Windows.Forms.TextBox();
            this.txtNumeClient = new System.Windows.Forms.TextBox();
            this.txtNumarTelefon = new System.Windows.Forms.TextBox();
            this.btnAdaugare = new System.Windows.Forms.Button();
            this.btnModificare = new System.Windows.Forms.Button();
            this.btnStergere = new System.Windows.Forms.Button();
            this.btnConfirmare = new System.Windows.Forms.Button();
            this.btnRenuntare = new System.Windows.Forms.Button();
            this.aplicatieHotelDataSet = new ProiectHotel.AplicatieHotelDataSet();
            this.aplicatieHotelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aplicatieHotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicatieHotelDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(961, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.camereToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1460, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // camereToolStripMenuItem
            // 
            this.camereToolStripMenuItem.Name = "camereToolStripMenuItem";
            this.camereToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.camereToolStripMenuItem.Text = "Camere";
            this.camereToolStripMenuItem.Click += new System.EventHandler(this.camereToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblNumarCamera);
            this.panel2.Controls.Add(this.lblNumarZile);
            this.panel2.Controls.Add(this.lblDataCazarii);
            this.panel2.Controls.Add(this.lblNumarTelefon);
            this.panel2.Controls.Add(this.lblNumeClient);
            this.panel2.Controls.Add(this.dtpDataCazarii);
            this.panel2.Controls.Add(this.txtNumarCamera);
            this.panel2.Controls.Add(this.txtNumarZile);
            this.panel2.Controls.Add(this.txtNumeClient);
            this.panel2.Controls.Add(this.txtNumarTelefon);
            this.panel2.Location = new System.Drawing.Point(979, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 531);
            this.panel2.TabIndex = 7;
            // 
            // lblNumarCamera
            // 
            this.lblNumarCamera.AutoSize = true;
            this.lblNumarCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumarCamera.Location = new System.Drawing.Point(21, 464);
            this.lblNumarCamera.Name = "lblNumarCamera";
            this.lblNumarCamera.Size = new System.Drawing.Size(143, 22);
            this.lblNumarCamera.TabIndex = 13;
            this.lblNumarCamera.Text = "Numar Camera";
            // 
            // lblNumarZile
            // 
            this.lblNumarZile.AutoSize = true;
            this.lblNumarZile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumarZile.Location = new System.Drawing.Point(30, 366);
            this.lblNumarZile.Name = "lblNumarZile";
            this.lblNumarZile.Size = new System.Drawing.Size(107, 22);
            this.lblNumarZile.TabIndex = 12;
            this.lblNumarZile.Text = "Numar Zile";
            // 
            // lblDataCazarii
            // 
            this.lblDataCazarii.AutoSize = true;
            this.lblDataCazarii.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDataCazarii.Location = new System.Drawing.Point(21, 259);
            this.lblDataCazarii.Name = "lblDataCazarii";
            this.lblDataCazarii.Size = new System.Drawing.Size(120, 22);
            this.lblDataCazarii.TabIndex = 11;
            this.lblDataCazarii.Text = "Data Cazarii";
            // 
            // lblNumarTelefon
            // 
            this.lblNumarTelefon.AutoSize = true;
            this.lblNumarTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumarTelefon.Location = new System.Drawing.Point(21, 152);
            this.lblNumarTelefon.Name = "lblNumarTelefon";
            this.lblNumarTelefon.Size = new System.Drawing.Size(142, 22);
            this.lblNumarTelefon.TabIndex = 10;
            this.lblNumarTelefon.Text = "Numar Telefon";
            // 
            // lblNumeClient
            // 
            this.lblNumeClient.AutoSize = true;
            this.lblNumeClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumeClient.Location = new System.Drawing.Point(20, 48);
            this.lblNumeClient.Name = "lblNumeClient";
            this.lblNumeClient.Size = new System.Drawing.Size(119, 22);
            this.lblNumeClient.TabIndex = 9;
            this.lblNumeClient.Text = "Nume Client";
            // 
            // dtpDataCazarii
            // 
            this.dtpDataCazarii.Location = new System.Drawing.Point(201, 259);
            this.dtpDataCazarii.Name = "dtpDataCazarii";
            this.dtpDataCazarii.Size = new System.Drawing.Size(238, 22);
            this.dtpDataCazarii.TabIndex = 8;
            // 
            // txtNumarCamera
            // 
            this.txtNumarCamera.Location = new System.Drawing.Point(201, 466);
            this.txtNumarCamera.Name = "txtNumarCamera";
            this.txtNumarCamera.Size = new System.Drawing.Size(248, 22);
            this.txtNumarCamera.TabIndex = 7;
            // 
            // txtNumarZile
            // 
            this.txtNumarZile.Location = new System.Drawing.Point(201, 368);
            this.txtNumarZile.Name = "txtNumarZile";
            this.txtNumarZile.Size = new System.Drawing.Size(248, 22);
            this.txtNumarZile.TabIndex = 6;
            // 
            // txtNumeClient
            // 
            this.txtNumeClient.Location = new System.Drawing.Point(201, 52);
            this.txtNumeClient.Name = "txtNumeClient";
            this.txtNumeClient.Size = new System.Drawing.Size(238, 22);
            this.txtNumeClient.TabIndex = 4;
            // 
            // txtNumarTelefon
            // 
            this.txtNumarTelefon.Location = new System.Drawing.Point(201, 154);
            this.txtNumarTelefon.Name = "txtNumarTelefon";
            this.txtNumarTelefon.Size = new System.Drawing.Size(238, 22);
            this.txtNumarTelefon.TabIndex = 5;
            // 
            // btnAdaugare
            // 
            this.btnAdaugare.Location = new System.Drawing.Point(12, 48);
            this.btnAdaugare.Name = "btnAdaugare";
            this.btnAdaugare.Size = new System.Drawing.Size(91, 23);
            this.btnAdaugare.TabIndex = 8;
            this.btnAdaugare.Text = "Adaugare";
            this.btnAdaugare.UseVisualStyleBackColor = true;
            this.btnAdaugare.Click += new System.EventHandler(this.btnAdaugare_Click);
            // 
            // btnModificare
            // 
            this.btnModificare.Location = new System.Drawing.Point(421, 48);
            this.btnModificare.Name = "btnModificare";
            this.btnModificare.Size = new System.Drawing.Size(85, 23);
            this.btnModificare.TabIndex = 9;
            this.btnModificare.Text = "Modificare";
            this.btnModificare.UseVisualStyleBackColor = true;
            this.btnModificare.Click += new System.EventHandler(this.btnModificare_Click);
            // 
            // btnStergere
            // 
            this.btnStergere.Location = new System.Drawing.Point(888, 48);
            this.btnStergere.Name = "btnStergere";
            this.btnStergere.Size = new System.Drawing.Size(75, 23);
            this.btnStergere.TabIndex = 10;
            this.btnStergere.Text = "Stergere";
            this.btnStergere.UseVisualStyleBackColor = true;
            this.btnStergere.Click += new System.EventHandler(this.btnStergere_Click);
            // 
            // btnConfirmare
            // 
            this.btnConfirmare.Location = new System.Drawing.Point(993, 47);
            this.btnConfirmare.Name = "btnConfirmare";
            this.btnConfirmare.Size = new System.Drawing.Size(82, 23);
            this.btnConfirmare.TabIndex = 11;
            this.btnConfirmare.Text = "Confirmare";
            this.btnConfirmare.UseVisualStyleBackColor = true;
            this.btnConfirmare.Click += new System.EventHandler(this.btnConfirmare_Click);
            // 
            // btnRenuntare
            // 
            this.btnRenuntare.Location = new System.Drawing.Point(1372, 48);
            this.btnRenuntare.Name = "btnRenuntare";
            this.btnRenuntare.Size = new System.Drawing.Size(75, 23);
            this.btnRenuntare.TabIndex = 12;
            this.btnRenuntare.Text = "Renuntare";
            this.btnRenuntare.UseVisualStyleBackColor = true;
            this.btnRenuntare.Click += new System.EventHandler(this.btnRenuntare_Click);
            // 
            // aplicatieHotelDataSet
            // 
            this.aplicatieHotelDataSet.DataSetName = "AplicatieHotelDataSet";
            this.aplicatieHotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aplicatieHotelDataSetBindingSource
            // 
            this.aplicatieHotelDataSetBindingSource.DataSource = this.aplicatieHotelDataSet;
            this.aplicatieHotelDataSetBindingSource.Position = 0;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 647);
            this.Controls.Add(this.btnRenuntare);
            this.Controls.Add(this.btnConfirmare);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.btnModificare);
            this.Controls.Add(this.btnAdaugare);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form6";
            this.Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aplicatieHotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicatieHotelDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camereToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpDataCazarii;
        private System.Windows.Forms.TextBox txtNumarCamera;
        private System.Windows.Forms.TextBox txtNumarZile;
        private System.Windows.Forms.TextBox txtNumeClient;
        private System.Windows.Forms.TextBox txtNumarTelefon;
        private System.Windows.Forms.Label lblNumarCamera;
        private System.Windows.Forms.Label lblNumarZile;
        private System.Windows.Forms.Label lblDataCazarii;
        private System.Windows.Forms.Label lblNumarTelefon;
        private System.Windows.Forms.Label lblNumeClient;
        private System.Windows.Forms.Button btnAdaugare;
        private System.Windows.Forms.Button btnModificare;
        private System.Windows.Forms.Button btnStergere;
        private System.Windows.Forms.Button btnConfirmare;
        private System.Windows.Forms.Button btnRenuntare;
        private System.Windows.Forms.BindingSource aplicatieHotelDataSetBindingSource;
        private AplicatieHotelDataSet aplicatieHotelDataSet;
    }
}