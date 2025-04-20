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
    public partial class Kostumuteslimalaniadeedenlerinlistesi : Form
    {
        public Kostumuteslimalaniadeedenlerinlistesi()
        {
            InitializeComponent();
        }

        private void Kostumuteslimalaniadeedenlerinlistesi_Load(object sender, EventArgs e)
        {

        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            kostum_ver kostumver = new kostum_ver();
            kostumver.Barkodno = txtbarkodno.Text;
            kostum_verBLL bll = new kostum_verBLL();
            kostum_iade kostumiade = new kostum_iade();
            kostum_iadeBLL bll2 = new kostum_iadeBLL();
            kostumiade.Barkodno = txtbarkodno.Text;
            if (txtbarkodno.Text == "")
            {
                MessageBox.Show("Lütfen geçmişte alındığı kostümleri görmek istediğiniz kostümün barkod numarasını giriniz.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((bll.KostumBarkodNoArama(kostumver).Count <= 0) && (bll2.KostumBarkodNoArama(kostumiade).Count <= 0))
                {
                    MessageBox.Show("Daha önce herhangi bir müşteri bu  kostümü almamıştır.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {//eğer kitap alındıysa listele
                    dataGridView1.DataSource = bll.KostumBarkodNoArama(kostumver);
                    dataGridView2.DataSource = bll2.KostumBarkodNoArama(kostumiade);
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                TimeSpan zamanfarki = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells["Teslimtarihi"].Value.ToString());
                double gun = zamanfarki.TotalDays;
                if (gun > 0.0)//Teslim tarihi geçmiş ise
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((gun <= 0) && (gun >= -2))//eger teslim tarihine iki gün var ise 
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {//teslim edilmiş kitaplar
                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            txtbarkodno.Clear();
        }

        private void txtbarkodno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece sayi girişi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbarkodno_TextChanged(object sender, EventArgs e)
        {
            if (txtbarkodno.Text.Trim() == "")//eğer txtbarkodno boş ise
            {
                errorProvider1.SetError(txtbarkodno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtbarkodno, "");
            }// ErrorProvider kapanacak
        }

        private void txtbarkodno_VisibleChanged(object sender, EventArgs e)
        {
            if (txtbarkodno.Text.Trim() == "")//eğer TextBox1 boş ise
            {
                errorProvider1.SetError(txtbarkodno, "Bu alan boş geçilmez");
            } // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
            {
                errorProvider1.SetError(txtbarkodno, "");
            }// ErrorProvider kapanacak

        }

        private void Kitabıteslimalanidaeedenlerinlistesi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(100, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
            errorProvider1.BlinkRate = 100000;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            errorProvider2.BlinkRate = 400;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
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

        private void btnlistele_Click_1(object sender, EventArgs e)
        {

        }
    }
}
