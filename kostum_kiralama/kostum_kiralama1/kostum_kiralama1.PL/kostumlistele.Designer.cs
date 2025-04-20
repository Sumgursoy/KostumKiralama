namespace kostum_kiralama1.PL
{
    partial class kostumlistele
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.barkodnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kostumadiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sahibiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rafnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kostumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kostum_kiralamaDataSet = new kostum_kiralama1.PL.kostum_kiralamaDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.kostumTableAdapter = new kostum_kiralama1.PL.kostum_kiralamaDataSetTableAdapters.kostumTableAdapter();
            this.kostumTableAdapter1 = new kostum_kiralama1.DAL.kostum_kiralamaDataSetTableAdapters.kostumTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kostumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kostum_kiralamaDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barkodnoDataGridViewTextBoxColumn,
            this.kostumadiDataGridViewTextBoxColumn,
            this.sahibiDataGridViewTextBoxColumn,
            this.rafnoDataGridViewTextBoxColumn,
            this.adetDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.kostumBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(58, 67);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(688, 317);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // barkodnoDataGridViewTextBoxColumn
            // 
            this.barkodnoDataGridViewTextBoxColumn.DataPropertyName = "Barkodno";
            this.barkodnoDataGridViewTextBoxColumn.HeaderText = "Barkodno";
            this.barkodnoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.barkodnoDataGridViewTextBoxColumn.Name = "barkodnoDataGridViewTextBoxColumn";
            this.barkodnoDataGridViewTextBoxColumn.Width = 125;
            // 
            // kostumadiDataGridViewTextBoxColumn
            // 
            this.kostumadiDataGridViewTextBoxColumn.DataPropertyName = "Kostumadi";
            this.kostumadiDataGridViewTextBoxColumn.HeaderText = "Kostumadi";
            this.kostumadiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kostumadiDataGridViewTextBoxColumn.Name = "kostumadiDataGridViewTextBoxColumn";
            this.kostumadiDataGridViewTextBoxColumn.Width = 125;
            // 
            // sahibiDataGridViewTextBoxColumn
            // 
            this.sahibiDataGridViewTextBoxColumn.DataPropertyName = "Sahibi";
            this.sahibiDataGridViewTextBoxColumn.HeaderText = "Sahibi";
            this.sahibiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sahibiDataGridViewTextBoxColumn.Name = "sahibiDataGridViewTextBoxColumn";
            this.sahibiDataGridViewTextBoxColumn.Width = 125;
            // 
            // rafnoDataGridViewTextBoxColumn
            // 
            this.rafnoDataGridViewTextBoxColumn.DataPropertyName = "Rafno";
            this.rafnoDataGridViewTextBoxColumn.HeaderText = "Rafno";
            this.rafnoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rafnoDataGridViewTextBoxColumn.Name = "rafnoDataGridViewTextBoxColumn";
            this.rafnoDataGridViewTextBoxColumn.Width = 125;
            // 
            // adetDataGridViewTextBoxColumn
            // 
            this.adetDataGridViewTextBoxColumn.DataPropertyName = "Adet";
            this.adetDataGridViewTextBoxColumn.HeaderText = "Adet";
            this.adetDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adetDataGridViewTextBoxColumn.Name = "adetDataGridViewTextBoxColumn";
            this.adetDataGridViewTextBoxColumn.Width = 125;
            // 
            // kostumBindingSource
            // 
            this.kostumBindingSource.DataMember = "kostum";
            this.kostumBindingSource.DataSource = this.kostum_kiralamaDataSet;
            // 
            // kostum_kiralamaDataSet
            // 
            this.kostum_kiralamaDataSet.DataSetName = "kostum_kiralamaDataSet";
            this.kostum_kiralamaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(283, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "pdfe dönüştür";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kostumTableAdapter
            // 
            this.kostumTableAdapter.ClearBeforeFill = true;
            // 
            // kostumTableAdapter1
            // 
            this.kostumTableAdapter1.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Location = new System.Drawing.Point(686, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 62);
            this.button3.TabIndex = 8;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(741, -2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 62);
            this.button4.TabIndex = 7;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kostum_kiralama1.PL.Properties.Resources._47d0337c_f2de_4de0_a420_b2b7c266ec63;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // kostumlistele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kostumlistele";
            this.Text = "kostumlistele";
            this.Load += new System.EventHandler(this.kostumlistele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kostumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kostum_kiralamaDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DAL.kostum_kiralamaDataSetTableAdapters.kostumTableAdapter kostumTableAdapter1;
        private kostum_kiralamaDataSet kostum_kiralamaDataSet;
        private System.Windows.Forms.BindingSource kostumBindingSource;
        private kostum_kiralamaDataSetTableAdapters.kostumTableAdapter kostumTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkodnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kostumadiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sahibiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rafnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adetDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}