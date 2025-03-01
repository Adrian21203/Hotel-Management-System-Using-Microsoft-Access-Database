namespace ProiectHotel
{
    partial class Form2
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
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.rezervariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rezervariContinutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnActualizare = new System.Windows.Forms.Button();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnRenuntare = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.camereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCautare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariContinutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCheckIn.Location = new System.Drawing.Point(24, 75);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(219, 83);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "CAZARE";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCazare_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCheckOut.Location = new System.Drawing.Point(789, 75);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(227, 83);
            this.btnCheckOut.TabIndex = 1;
            this.btnCheckOut.Text = "PLECARE";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnPlecare_Click);
            // 
            // rezervariBindingSource
            // 
            this.rezervariBindingSource.DataMember = "Rezervari";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(992, 327);
            this.dataGridView1.TabIndex = 2;
            // 
            // rezervariContinutBindingSource
            // 
            this.rezervariContinutBindingSource.DataMember = "RezervariContinut";
            // 
            // btnActualizare
            // 
            this.btnActualizare.Location = new System.Drawing.Point(24, 542);
            this.btnActualizare.Name = "btnActualizare";
            this.btnActualizare.Size = new System.Drawing.Size(114, 35);
            this.btnActualizare.TabIndex = 3;
            this.btnActualizare.Text = "Actualizare";
            this.btnActualizare.UseVisualStyleBackColor = true;
            this.btnActualizare.Click += new System.EventHandler(this.btnActualizare_Click);
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(439, 542);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(106, 35);
            this.btnSalvare.TabIndex = 4;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnRenuntare
            // 
            this.btnRenuntare.Location = new System.Drawing.Point(915, 542);
            this.btnRenuntare.Name = "btnRenuntare";
            this.btnRenuntare.Size = new System.Drawing.Size(101, 35);
            this.btnRenuntare.TabIndex = 5;
            this.btnRenuntare.Text = "Renuntare";
            this.btnRenuntare.UseVisualStyleBackColor = true;
            this.btnRenuntare.Click += new System.EventHandler(this.btnRenuntare_Click);
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(335, 123);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(296, 22);
            this.txtCautare.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camereToolStripMenuItem,
            this.rezervariToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1115, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // camereToolStripMenuItem
            // 
            this.camereToolStripMenuItem.Name = "camereToolStripMenuItem";
            this.camereToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.camereToolStripMenuItem.Text = "Camere";
            this.camereToolStripMenuItem.Click += new System.EventHandler(this.camereToolStripMenuItem_Click);
            // 
            // rezervariToolStripMenuItem
            // 
            this.rezervariToolStripMenuItem.Name = "rezervariToolStripMenuItem";
            this.rezervariToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.rezervariToolStripMenuItem.Text = "Rezervari";
            this.rezervariToolStripMenuItem.Click += new System.EventHandler(this.rezervariToolStripMenuItem_Click);
            // 
            // btnCautare
            // 
            this.btnCautare.Location = new System.Drawing.Point(662, 117);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(83, 35);
            this.btnCautare.TabIndex = 9;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 602);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.btnRenuntare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnActualizare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rezervariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariContinutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.BindingSource rezervariBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnActualizare;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnRenuntare;
        private System.Windows.Forms.BindingSource rezervariContinutBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRezervareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCameraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCazariiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretZiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrZileDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.ToolStripMenuItem camereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervariToolStripMenuItem;
    }
}