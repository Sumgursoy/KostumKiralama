namespace kostum_kiralama1.PL
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ögrenciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.araToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapAlımİadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapİadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafiklerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Gray;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ögrenciToolStripMenuItem,
            this.kitapToolStripMenuItem,
            this.kitapAlımİadeToolStripMenuItem,
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem,
            this.grafiklerToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1019, 33);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ögrenciToolStripMenuItem
            // 
            this.ögrenciToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.ögrenciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.listeleToolStripMenuItem});
            this.ögrenciToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ögrenciToolStripMenuItem.Name = "ögrenciToolStripMenuItem";
            this.ögrenciToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.ögrenciToolStripMenuItem.Text = "Müşteri";
            this.ögrenciToolStripMenuItem.Click += new System.EventHandler(this.ögrenciToolStripMenuItem_Click);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // listeleToolStripMenuItem
            // 
            this.listeleToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            this.listeleToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.listeleToolStripMenuItem.Text = "Listele";
            this.listeleToolStripMenuItem.Click += new System.EventHandler(this.listeleToolStripMenuItem_Click_1);
            // 
            // kitapToolStripMenuItem
            // 
            this.kitapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem1,
            this.silToolStripMenuItem1,
            this.listeleToolStripMenuItem1,
            this.araToolStripMenuItem});
            this.kitapToolStripMenuItem.Name = "kitapToolStripMenuItem";
            this.kitapToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.kitapToolStripMenuItem.Text = "Kostüm";
            this.kitapToolStripMenuItem.Click += new System.EventHandler(this.kitapToolStripMenuItem_Click);
            // 
            // ekleToolStripMenuItem1
            // 
            this.ekleToolStripMenuItem1.Name = "ekleToolStripMenuItem1";
            this.ekleToolStripMenuItem1.Size = new System.Drawing.Size(152, 30);
            this.ekleToolStripMenuItem1.Text = "Ekle";
            this.ekleToolStripMenuItem1.Click += new System.EventHandler(this.ekleToolStripMenuItem1_Click_1);
            // 
            // silToolStripMenuItem1
            // 
            this.silToolStripMenuItem1.Name = "silToolStripMenuItem1";
            this.silToolStripMenuItem1.Size = new System.Drawing.Size(152, 30);
            this.silToolStripMenuItem1.Text = "Sil";
            this.silToolStripMenuItem1.Click += new System.EventHandler(this.silToolStripMenuItem1_Click_1);
            // 
            // listeleToolStripMenuItem1
            // 
            this.listeleToolStripMenuItem1.Name = "listeleToolStripMenuItem1";
            this.listeleToolStripMenuItem1.Size = new System.Drawing.Size(152, 30);
            this.listeleToolStripMenuItem1.Text = "Listele";
            this.listeleToolStripMenuItem1.Click += new System.EventHandler(this.listeleToolStripMenuItem1_Click_1);
            // 
            // araToolStripMenuItem
            // 
            this.araToolStripMenuItem.Name = "araToolStripMenuItem";
            this.araToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.araToolStripMenuItem.Text = "Ara";
            this.araToolStripMenuItem.Click += new System.EventHandler(this.araToolStripMenuItem_Click_1);
            // 
            // kitapAlımİadeToolStripMenuItem
            // 
            this.kitapAlımİadeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitapVerToolStripMenuItem,
            this.kitapİadeToolStripMenuItem});
            this.kitapAlımİadeToolStripMenuItem.Name = "kitapAlımİadeToolStripMenuItem";
            this.kitapAlımİadeToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.kitapAlımİadeToolStripMenuItem.Text = "Kostüm Alım-İade";
            this.kitapAlımİadeToolStripMenuItem.Click += new System.EventHandler(this.kitapAlımİadeToolStripMenuItem_Click);
            // 
            // kitapVerToolStripMenuItem
            // 
            this.kitapVerToolStripMenuItem.Name = "kitapVerToolStripMenuItem";
            this.kitapVerToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.kitapVerToolStripMenuItem.Text = "Kostüm Ver";
            this.kitapVerToolStripMenuItem.Click += new System.EventHandler(this.kitapVerToolStripMenuItem_Click_1);
            // 
            // kitapİadeToolStripMenuItem
            // 
            this.kitapİadeToolStripMenuItem.Name = "kitapİadeToolStripMenuItem";
            this.kitapİadeToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.kitapİadeToolStripMenuItem.Text = "Kostüm İade";
            this.kitapİadeToolStripMenuItem.Click += new System.EventHandler(this.kitapİadeToolStripMenuItem_Click_1);
            // 
            // öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem
            // 
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem.Name = "öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem";
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem.Size = new System.Drawing.Size(375, 29);
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem.Text = "Müşterinin almış olduğu kostümler listesi";
            this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem.Click += new System.EventHandler(this.öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem_Click_1);
            // 
            // grafiklerToolStripMenuItem
            // 
            this.grafiklerToolStripMenuItem.Name = "grafiklerToolStripMenuItem";
            this.grafiklerToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.grafiklerToolStripMenuItem.Text = "Grafikler";
            this.grafiklerToolStripMenuItem.Click += new System.EventHandler(this.grafiklerToolStripMenuItem_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::kostum_kiralama1.PL.Properties.Resources.e203b731_df29_44e0_8160_151c3fb7da2e;
            this.pictureBox1.Location = new System.Drawing.Point(0, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1019, 430);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 463);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ögrenciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem araToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapAlımİadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapİadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğrencininAlmışOlduğuKitaplarListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafiklerToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

