using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;//
using System.IO;
using kostum_kiralama1.DAL;//
using System.Net;//
using System.Net.Mail;//




using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;




namespace kostum_kiralama1.PL
{
    public partial class kostumlistele : Form
    {

        public kostumlistele()
        {
            InitializeComponent();

        }
        static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\sumgu\OneDrive\Masaüstü\kostum_kiralama1\kostum_kiralama.accdb;";
        OleDbConnection connection = new OleDbConnection(connectionString);


        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView'e örnek veri ekleyelim

        }



        private void kostumlistele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kostum_kiralamaDataSet.kostum' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kostumTableAdapter.Fill(this.kostum_kiralamaDataSet.kostum);
            Loadmusteridata();
            //  dataGridView1.Rows.Add("example@domain.com", "recipient@domain.com", "Merhaba, işte mesaj!");
            //    dataGridView1.Rows.Add("example2@domain.com", "recipient2@domain.com", "İkinci mesaj!");
        }
        private void Loadmusteridata()
        {
            string query = "SELECT * FROM kostum";  // Veritabanındaki Musteri tablosunu çekiyoruz
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                adapter.Fill(dataTable);  // Verileri alıyoruz
                dataGridView1.DataSource = dataTable;  // DataGridView'e atıyoruz
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Veri Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();  // Bağlantıyı kapatıyoruz
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ExportDataGridViewToPdf(DataGridView dataGridView, string filePath)
        {
            if (dataGridView.ColumnCount == 0 || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView'de veri bulunmuyor. Lütfen tabloyu doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PDF belgesini oluştur
            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Başlık
            Paragraph title = new Paragraph("KOSTÜM LİSTESİ")
            {
                Alignment = Element.ALIGN_CENTER,
                Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f)
            };
            document.Add(title);

            // Boşluk
            document.Add(new Paragraph("\n")); // Bir satır boşluk ekle

            // DataGridView sütun sayısı kadar tablo oluştur
            PdfPTable table = new PdfPTable(dataGridView.ColumnCount)
            {
                WidthPercentage = 100
            };

            // Sütun başlıklarını ekle
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                table.AddCell(headerCell);
            }

            // Verileri ekle
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellText = cell.Value?.ToString() ?? string.Empty;
                        PdfPCell dataCell = new PdfPCell(new Phrase(cellText))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        table.AddCell(dataCell);
                    }
                }
            }

            document.Add(table);
            document.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "PDF Dosyasını Kaydet",
                FileName = "KostümListesi.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    ExportDataGridViewToPdf(dataGridView1, filePath);
                    MessageBox.Show("PDF başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }






   


    }


      
        
           

       
           









