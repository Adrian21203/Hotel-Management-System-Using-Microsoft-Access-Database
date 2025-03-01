namespace ProiectHotel
{
    partial class Form5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.btnCautare = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(911, 397);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.camereToolStripMenuItem,
            this.rezervariToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 28);
            this.menuStrip1.TabIndex = 1;
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
            // rezervariToolStripMenuItem
            // 
            this.rezervariToolStripMenuItem.Name = "rezervariToolStripMenuItem";
            this.rezervariToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.rezervariToolStripMenuItem.Text = "Rezervari";
            this.rezervariToolStripMenuItem.Click += new System.EventHandler(this.rezervariToolStripMenuItem_Click);
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(12, 69);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(313, 22);
            this.txtCautare.TabIndex = 2;
            // 
            // btnCautare
            // 
            this.btnCautare.Location = new System.Drawing.Point(346, 64);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(88, 32);
            this.btnCautare.TabIndex = 3;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCheckOut.Location = new System.Drawing.Point(558, 31);
            this.btnCheckOut.Name = "btnPlecare";
            this.btnCheckOut.Size = new System.Drawing.Size(276, 60);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "FINALIZEAZA PLECAREA";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnPlecare_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 516);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervariToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.Button btnCheckOut;
    }
}