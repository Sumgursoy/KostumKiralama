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
    public partial class kostumarama : Form
    {
        public kostumarama()
        {
            InitializeComponent();
        }

        private void kostumarama_Load(object sender, EventArgs e)
        {

        }
       
        private void kitaparama_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtborkod.Clear();
        }

        private void btnarama_Click_1(object sender, EventArgs e)
        {
            kostum Kostum = new kostum();
            Kostum.Barkodno = txtborkod.Text;
            kostumBLL bll = new kostumBLL();
            try
            {//eger burada hata alırsan cathdeki blogta yazılan mesaj bana hata vermesini göstercek
                dataGridView1.DataSource = bll.Arama(Kostum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
        }
    }
}
    

