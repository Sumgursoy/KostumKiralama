using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kostum_kiralama1.Entity;
using kostum_kiralama1.BLL;
using System.Diagnostics;


namespace kostum_kiralama1.PL
{
    public partial class musterilistele : Form
    {
        public musterilistele()
        {
            InitializeComponent();
        }

        private void musterilistele_Load(object sender, EventArgs e)
        {

        }
       

        private void ogrencilistele_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 100);//Form ekranın açılınca yernini belirleme Point(x,y)
        }

        private void btnlistele_Click_1(object sender, EventArgs e)
        {
            musteriBLL bll = new musteriBLL();
            dataGridView1.DataSource = bll.GetAllItems();


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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
