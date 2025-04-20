namespace kostum_kiralama1.PL
{
    partial class kostumsilme
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbarkodno = new System.Windows.Forms.TextBox();
            this.btnsilme = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(187, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Barkod Numarası";
            // 
            // txtbarkodno
            // 
            this.txtbarkodno.BackColor = System.Drawing.Color.Sienna;
            this.txtbarkodno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbarkodno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbarkodno.ForeColor = System.Drawing.Color.White;
            this.txtbarkodno.Location = new System.Drawing.Point(370, 193);
            this.txtbarkodno.Multiline = true;
            this.txtbarkodno.Name = "txtbarkodno";
            this.txtbarkodno.Size = new System.Drawing.Size(207, 25);
            this.txtbarkodno.TabIndex = 4;
            // 
            // btnsilme
            // 
            this.btnsilme.BackColor = System.Drawing.Color.Transparent;
            this.btnsilme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsilme.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsilme.ForeColor = System.Drawing.Color.Sienna;
            this.btnsilme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsilme.Location = new System.Drawing.Point(317, 250);
            this.btnsilme.Name = "btnsilme";
            this.btnsilme.Size = new System.Drawing.Size(125, 49);
            this.btnsilme.TabIndex = 3;
            this.btnsilme.Text = "SİL";
            this.btnsilme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsilme.UseVisualStyleBackColor = false;
            this.btnsilme.Click += new System.EventHandler(this.btnsilme_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 61);
            this.panel1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Location = new System.Drawing.Point(686, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(741, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 68);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kostum_kiralama1.PL.Properties.Resources._47d0337c_f2de_4de0_a420_b2b7c266ec63;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // kostumsilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbarkodno);
            this.Controls.Add(this.btnsilme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kostumsilme";
            this.Text = "kostumsilme";
            this.Load += new System.EventHandler(this.kostumsilme_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbarkodno;
        private System.Windows.Forms.Button btnsilme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}