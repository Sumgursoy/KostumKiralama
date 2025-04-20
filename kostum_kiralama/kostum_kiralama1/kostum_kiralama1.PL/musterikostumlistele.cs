using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.BLL;
using kostum_kiralama1.Entity;

namespace kostum_kiralama1.PL
{
    public partial class musterikostumlistele : Form
    {
        public musterikostumlistele()
        {
            InitializeComponent();
        }

        private void musterikostumlistele_Load(object sender, EventArgs e)
        {

        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            //kostum_ver Kostum_ver = new kostum_ver();
            //Kostum_ver.Tcno = txttcno.Text;
            //kostum_verBLL bll = new kostum_verBLL();
            //kostum_iade Kostum_iade = new kostum_iade();
            //kostum_iadeBLL bll2 = new kostum_iadeBLL();
            //Kostum_iade.Tcno = txttcno.Text;
            //if (txttcno.Text == "")
            //{
            //    MessageBox.Show("Lütfen geçmişte aldığı kitapları görmek istediğiniz kişinin TC kimlik numarasını giriniz.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    if (txttcno.Text.Count() != 11)
            //    {
            //        MessageBox.Show("Lütfen geçerli Tc kimlik numarası giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if ((bll.TcArama(Kostum_ver).Count <= 0) && (bll2.TcArama(Kostum_iade).Count <= 0))
            //        {
            //            MessageBox.Show("Daha önce herhangi bir kitap almamışsınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        }
            //        else
            //        {
            //            dataGridView1.DataSource = bll.TcArama(Kostum_ver);//öğrencinin aldığı kitapları listeliyorum
            //            dataGridView2.DataSource = bll2.TcArama(Kostum_iade);//öğrencinin teslim ettiği kitapları listeliyorum
            //        }
            //    }
            //}
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells["Teslimtarihi"].Value.ToString());
            //    double gun = zamanfarki.TotalDays;
            //    if (gun > 0.0)//teslim tarihi geçiktiyse
            //    {
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //    }
            //    else if ((gun <= 0) && (gun >= -2))//eger teslim tarihine iki gün var ise 
            //    {
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            //    }
            //}
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)//teslim ettiyse
            //{
            //    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            //}
        }

        //private void btntemizle_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.DataSource = null;
        //    dataGridView2.DataSource = null;
        //    txttcno.Clear();
        //}

        private void txttcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txttcno_TextChanged(object sender, EventArgs e)
        {
            if (txttcno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txttcno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txttcno, "");
            }// ErrorProvider kapanacak
            if ((txttcno.Text.Length < 11) || (txttcno.Text.Length > 11))
            {
                errorProvider2.SetError(txttcno, "TC Kimlik numarısı 11 karakterli olmalıdır.");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
        private void txttcno_VisibleChanged(object sender, EventArgs e)
        {
            if (txttcno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txttcno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txttcno, "");
            }// ErrorProvider kapanacak
        }
        private void ogrencikitaplistele_Load(object sender, EventArgs e)
        {
            this.Location = new Point(50, 0);//Form ekranın açılınca yernini belirleme Point(x,y)
            errorProvider1.BlinkRate = 100000;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider2.BlinkRate = 400;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void btnlistele_Click_1(object sender, EventArgs e)
        {
            kostum_ver Kostum_ver = new kostum_ver();
            Kostum_ver.Tcno = txttcno.Text;
            kostum_verBLL bll = new kostum_verBLL();
            kostum_iade Kostum_iade = new kostum_iade();
            kostum_iadeBLL bll2 = new kostum_iadeBLL();
            Kostum_iade.Tcno = txttcno.Text;
            if (txttcno.Text == "")
            {
                MessageBox.Show("Lütfen geçmişte aldığı kostümleri görmek istediğiniz kişinin TC kimlik numarasını giriniz.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txttcno.Text.Count() != 11)
                {
                    MessageBox.Show("Lütfen geçerli Tc kimlik numarası giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((bll.TcArama(Kostum_ver).Count <= 0) && (bll2.TcArama(Kostum_iade).Count <= 0))
                    {
                        MessageBox.Show("Daha önce herhangi bir kostüm almamışsınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dataGridView1.DataSource = bll.TcArama(Kostum_ver);
                        dataGridView2.DataSource = bll2.TcArama(Kostum_iade);
                    }
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells["Teslimtarihi"].Value.ToString());
                double gun = zamanfarki.TotalDays;
                if (gun > 0.0)//teslim tarihi geçiktiyse
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((gun <= 0) && (gun >= -2))//eger teslim tarihine iki gün var ise 
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)//teslim ettiyse
            {
                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            txttcno.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

    

