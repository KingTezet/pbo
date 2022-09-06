using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace olah_nilai
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataguru.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datasiswa.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kelas.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pelajaran.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            user.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fa = new Form1();
            fa.Show();
        }
    }
}
