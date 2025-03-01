namespace ProiectHotel
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdaugare = new System.Windows.Forms.Button();
            this.btnModificare = new System.Windows.Forms.Button();
            this.btnStergere = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNumarCamera = new System.Windows.Forms.TextBox();
            this.txtNumarLocuri = new System.Windows.Forms.TextBox();
            this.txtPretZi = new System.Windows.Forms.TextBox();
            this.lblNumarCamera = new System.Windows.Forms.Label();
            this.lblNumarLocuri = new System.Windows.Forms.Label();
            this.lblEtaj = new System.Windows.Forms.Label();
            this.lblPretZi = new System.Windows.Forms.Label();
            this.btnConfirmare = new System.Windows.Forms.Button();
            this.btnRenuntare = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPoza = new System.Windows.Forms.Label();
            this.txtPoza = new System.Windows.Forms.TextBox();
            this.comboBoxEtaj = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(868, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdaugare
            // 
            this.btnAdaugare.Location = new System.Drawing.Point(128, 45);
            this.btnAdaugare.Name = "btnAdaugare";
            this.btnAdaugare.Size = new System.Drawing.Size(88, 34);
            this.btnAdaugare.TabIndex = 1;
            this.btnAdaugare.Text = "Adaugare";
            this.btnAdaugare.UseVisualStyleBackColor = true;
            this.btnAdaugare.Click += new System.EventHandler(this.btnAdaugare_Click);
            // 
            // btnModificare
            // 
            this.btnModificare.Location = new System.Drawing.Point(307, 51);
            this.btnModificare.Name = "btnModificare";
            this.btnModificare.Size = new System.Drawing.Size(109, 28);
            this.btnModificare.TabIndex = 2;
            this.btnModificare.Text = "Modificare";
            this.btnModificare.UseVisualStyleBackColor = true;
            this.btnModificare.Click += new System.EventHandler(this.btnModificare_Click);
            // 
            // btnStergere
            // 
            this.btnStergere.Location = new System.Drawing.Point(510, 47);
            this.btnStergere.Name = "btnStergere";
            this.btnStergere.Size = new System.Drawing.Size(93, 30);
            this.btnStergere.TabIndex = 3;
            this.btnStergere.Text = "Stergere";
            this.btnStergere.UseVisualStyleBackColor = true;
            this.btnStergere.Click += new System.EventHandler(this.btnStergere_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(321, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // txtNumarCamera
            // 
            this.txtNumarCamera.Location = new System.Drawing.Point(160, 38);
            this.txtNumarCamera.Name = "txtNumarCamera";
            this.txtNumarCamera.Size = new System.Drawing.Size(155, 22);
            this.txtNumarCamera.TabIndex = 4;
            // 
            // txtNumarLocuri
            // 
            this.txtNumarLocuri.Location = new System.Drawing.Point(160, 91);
            this.txtNumarLocuri.Name = "txtNumarLocuri";
            this.txtNumarLocuri.Size = new System.Drawing.Size(155, 22);
            this.txtNumarLocuri.TabIndex = 5;
            // 
            // txtPretZi
            // 
            this.txtPretZi.Location = new System.Drawing.Point(160, 223);
            this.txtPretZi.Name = "txtPretZi";
            this.txtPretZi.Size = new System.Drawing.Size(155, 22);
            this.txtPretZi.TabIndex = 7;
            // 
            // lblNumarCamera
            // 
            this.lblNumarCamera.AutoSize = true;
            this.lblNumarCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumarCamera.Location = new System.Drawing.Point(3, 38);
            this.lblNumarCamera.Name = "lblNumarCamera";
            this.lblNumarCamera.Size = new System.Drawing.Size(135, 20);
            this.lblNumarCamera.TabIndex = 8;
            this.lblNumarCamera.Text = "Numar Camera";
            // 
            // lblNumarLocuri
            // 
            this.lblNumarLocuri.AutoSize = true;
            this.lblNumarLocuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumarLocuri.Location = new System.Drawing.Point(3, 93);
            this.lblNumarLocuri.Name = "lblNumarLocuri";
            this.lblNumarLocuri.Size = new System.Drawing.Size(123, 20);
            this.lblNumarLocuri.TabIndex = 9;
            this.lblNumarLocuri.Text = "Numar Locuri";
            // 
            // lblEtaj
            // 
            this.lblEtaj.AutoSize = true;
            this.lblEtaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEtaj.Location = new System.Drawing.Point(3, 160);
            this.lblEtaj.Name = "lblEtaj";
            this.lblEtaj.Size = new System.Drawing.Size(42, 20);
            this.lblEtaj.TabIndex = 10;
            this.lblEtaj.Text = "Etaj";
            // 
            // lblPretZi
            // 
            this.lblPretZi.AutoSize = true;
            this.lblPretZi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPretZi.Location = new System.Drawing.Point(3, 225);
            this.lblPretZi.Name = "lblPretZi";
            this.lblPretZi.Size = new System.Drawing.Size(65, 20);
            this.lblPretZi.TabIndex = 11;
            this.lblPretZi.Text = "Pret/zi";
            // 
            // btnConfirmare
            // 
            this.btnConfirmare.Location = new System.Drawing.Point(899, 68);
            this.btnConfirmare.Name = "btnConfirmare";
            this.btnConfirmare.Size = new System.Drawing.Size(94, 41);
            this.btnConfirmare.TabIndex = 13;
            this.btnConfirmare.Text = "Confirmare";
            this.btnConfirmare.UseVisualStyleBackColor = true;
            this.btnConfirmare.Click += new System.EventHandler(this.btnConfirmare_Click);
            // 
            // btnRenuntare
            // 
            this.btnRenuntare.Location = new System.Drawing.Point(1376, 68);
            this.btnRenuntare.Name = "btnRenuntare";
            this.btnRenuntare.Size = new System.Drawing.Size(100, 35);
            this.btnRenuntare.TabIndex = 14;
            this.btnRenuntare.Text = "Renuntare";
            this.btnRenuntare.UseVisualStyleBackColor = true;
            this.btnRenuntare.Click += new System.EventHandler(this.btnRenuntare_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPoza);
            this.panel1.Controls.Add(this.txtPoza);
            this.panel1.Controls.Add(this.comboBoxEtaj);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblNumarCamera);
            this.panel1.Controls.Add(this.txtNumarCamera);
            this.panel1.Controls.Add(this.txtPretZi);
            this.panel1.Controls.Add(this.lblPretZi);
            this.panel1.Controls.Add(this.lblNumarLocuri);
            this.panel1.Controls.Add(this.lblEtaj);
            this.panel1.Controls.Add(this.txtNumarLocuri);
            this.panel1.Location = new System.Drawing.Point(899, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 359);
            this.panel1.TabIndex = 15;
            // 
            // lblPoza
            // 
            this.lblPoza.AutoSize = true;
            this.lblPoza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPoza.Location = new System.Drawing.Point(4, 284);
            this.lblPoza.Name = "lblPoza";
            this.lblPoza.Size = new System.Drawing.Size(51, 20);
            this.lblPoza.TabIndex = 15;
            this.lblPoza.Text = "Poza";
            // 
            // txtPoza
            // 
            this.txtPoza.Location = new System.Drawing.Point(160, 284);
            this.txtPoza.Name = "txtPoza";
            this.txtPoza.Size = new System.Drawing.Size(155, 22);
            this.txtPoza.TabIndex = 14;
            this.txtPoza.Click += new System.EventHandler(this.txtPoza_Click);
            // 
            // comboBoxEtaj
            // 
            this.comboBoxEtaj.FormattingEnabled = true;
            this.comboBoxEtaj.Location = new System.Drawing.Point(160, 156);
            this.comboBoxEtaj.Name = "comboBoxEtaj";
            this.comboBoxEtaj.Size = new System.Drawing.Size(155, 24);
            this.comboBoxEtaj.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.rezervariToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1517, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // rezervariToolStripMenuItem
            // 
            this.rezervariToolStripMenuItem.Name = "rezervariToolStripMenuItem";
            this.rezervariToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.rezervariToolStripMenuItem.Text = "Rezervari";
            this.rezervariToolStripMenuItem.Click += new System.EventHandler(this.rezervariToolStripMenuItem_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRenuntare);
            this.Controls.Add(this.btnConfirmare);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.btnModificare);
            this.Controls.Add(this.btnAdaugare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCameraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrCameraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrLocuriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn etajDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretZiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spImagineDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAdaugare;
        private System.Windows.Forms.Button btnModificare;
        private System.Windows.Forms.Button btnStergere;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNumarCamera;
        private System.Windows.Forms.TextBox txtNumarLocuri;
        private System.Windows.Forms.TextBox txtPretZi;
        private System.Windows.Forms.Label lblNumarCamera;
        private System.Windows.Forms.Label lblNumarLocuri;
        private System.Windows.Forms.Label lblEtaj;
        private System.Windows.Forms.Label lblPretZi;
        private System.Windows.Forms.Button btnConfirmare;
        private System.Windows.Forms.Button btnRenuntare;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxEtaj;
        private System.Windows.Forms.Label lblPoza;
        private System.Windows.Forms.TextBox txtPoza;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervariToolStripMenuItem;
    }
}