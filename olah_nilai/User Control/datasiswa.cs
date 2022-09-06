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
    public partial class datasiswa : UserControl
    {
        public datasiswa()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;

        private void datasiswa_Load(object sender, EventArgs e)
        {
            RekamDataSiswa();
            combo();
        }

        private void RekamDataSiswa()
        {
            SqlCommand cmd = new SqlCommand("select * from siswa", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridSiswa.DataSource = dt;
        }

        private bool IsValid()
        {

            if (nisn.Text == String.Empty)
            {
                MessageBox.Show("nisn tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (nama.Text == String.Empty)
            {
                MessageBox.Show("nama tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void HapusData()
        {
            id = 0;
            nisn.Clear();
            nama.Clear();
            alamat.Clear();
            lahir.Clear();
            kelamin.Text = "";
            kelas.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO siswa VALUES (@nisn, @nama, @alamat, @kelamin, @lahir, @tgl, @kelas)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nisn", nisn.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@alamat", alamat.Text);
                cmd.Parameters.AddWithValue("@kelamin", kelamin.Text);
                cmd.Parameters.AddWithValue("@lahir", lahir.Text);
                cmd.Parameters.AddWithValue("@tgl", tgl.Value);
                cmd.Parameters.AddWithValue("@kelas", kelas.Text);
              



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Guru Baru telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataSiswa();
                HapusData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE siswa SET nisn = @nisn, nama = @nama, alamat = @alamat, kelamin = @kelamin, lahir  = @lahir, tgl = @tgl, kelas = @kelas  WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nisn", nisn.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@alamat", alamat.Text);
                cmd.Parameters.AddWithValue("@kelamin", kelamin.Text);
                cmd.Parameters.AddWithValue("@lahir", lahir.Text);
                cmd.Parameters.AddWithValue("@tgl", tgl.Value);
                cmd.Parameters.AddWithValue("@kelas", kelas.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Siswa telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataSiswa();
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
                SqlCommand cmd = new SqlCommand("DELETE siswa WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Siswa telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataSiswa();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridSiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridSiswa.SelectedRows[0].Cells[0].Value);
            nisn.Text = dataGridSiswa.SelectedRows[0].Cells[1].Value.ToString();
            nama.Text = dataGridSiswa.SelectedRows[0].Cells[2].Value.ToString();
            alamat.Text = dataGridSiswa.SelectedRows[0].Cells[3].Value.ToString();
            kelamin.Text = dataGridSiswa.SelectedRows[0].Cells[4].Value.ToString();
            lahir.Text = dataGridSiswa.SelectedRows[0].Cells[5].Value.ToString();
            tgl.Text = dataGridSiswa.SelectedRows[0].Cells[6].Value.ToString();
            kelas.Text = dataGridSiswa.SelectedRows[0].Cells[7].Value.ToString();
        
        }

        private void kelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void combo()
        {
            kelas.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select kelas from kelas";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                kelas.Items.Add(dr["kelas"].ToString());
            }
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
