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
    public partial class pelajaran : UserControl
    {
        public pelajaran()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;

        private void pelajaran_Load(object sender, EventArgs e)
        {
            RekamDataPelajaran();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO mata_pelajaran VALUES (@pelajaran)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@pelajaran", mata_pelajaran.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Pelajaran Baru telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataPelajaran();
                HapusData();
            }
        }

        private bool IsValid()
        {

            if (mata_pelajaran.Text == String.Empty)
            {
                MessageBox.Show("Pelajaran tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void HapusData()
        {
            mata_pelajaran.Clear();
        }

        private void RekamDataPelajaran()
        {
            SqlCommand cmd = new SqlCommand("select * from mata_pelajaran", con);
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
                SqlCommand cmd = new SqlCommand("UPDATE mata_pelajaran SET  pelajaran = @pelajaran  WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@kelas", mata_pelajaran.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Pelajaran telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataPelajaran();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Pelajaran yang akan diupdate datanya", "Pilih?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE pelajaran WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Pelajaran telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataPelajaran();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
