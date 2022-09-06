using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace olah_nilai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection koneksi = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("username atau password tidak boleh kosong");

            }
            else
            {
                SqlDataAdapter dtap = new SqlDataAdapter("select username, password, hak from usr where username = '" + username.Text + "' AND password  = '" + password.Text + "'", koneksi);
                DataTable dt = new DataTable();
                dtap.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["hak"].ToString() == "admin")
                        {
                            this.Hide();
                            admin fa = new admin();
                            fa.Show();
                        }
                        else if (dr["hak"].ToString() == "guru")
                        {
                            this.Hide();
                            guru fa = new guru();
                            fa.Show();
                        }

                        else if (dr["hak"].ToString() == "siswa")
                        {
                            this.Hide();
                            murid fa = new murid();
                            fa.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("salah kata sandi atau username");
                }
                koneksi.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
