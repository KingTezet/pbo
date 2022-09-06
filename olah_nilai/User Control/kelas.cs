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

namespace olah_nilai.User_Control
{
    public partial class kelas : UserControl
    {
        public kelas()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO kelas VALUES (@kelas)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@kelas", kls.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Kelas Baru telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataKelas();
                HapusData();
            }
        }

        private bool IsValid()
        {

            if (kls.Text == String.Empty)
            {
                MessageBox.Show("kelas tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void HapusData()
        {
            kls.Clear();
        }

        private void RekamDataKelas()
        {
            SqlCommand cmd = new SqlCommand("select * from kelas", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridKelas.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE kelas SET  kelas = @kelas  WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@kelas", kls.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Siswa telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataKelas();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Siswa yang akan diupdate datanya", "Pilih?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE kelas WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Kelas telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataKelas();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void kelas_Load(object sender, EventArgs e)
        {
            RekamDataKelas();
        }

        private void dataGridKelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridKelas.SelectedRows[0].Cells[0].Value);
            kls.Text = dataGridKelas.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
