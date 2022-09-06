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
    public partial class dataguru : UserControl
    {
        public dataguru()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO guru VALUES (@nip, @nama, @alamat, @lahir, @tgl, @kelamin, @pelajaran, @jabatan)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nip", nip.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@alamat", alamat.Text);
                cmd.Parameters.AddWithValue("@lahir", lahir.Text);
                cmd.Parameters.AddWithValue("@tgl", tgl.Value);
                cmd.Parameters.AddWithValue("@kelamin", kelamin.Text);
                cmd.Parameters.AddWithValue("@pelajaran", pelajaran.Text);
                cmd.Parameters.AddWithValue("@jabatan", jabatan.Text);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Guru Baru telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataGuru();
                HapusData();
            }
        }
        private bool IsValid()
        {
            
            if (nip.Text == String.Empty)
            {
                MessageBox.Show("nip tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (nama.Text == String.Empty)
                 {
                MessageBox.Show("nama tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                  }
            return true;
        }

        private void HapusData()
        {
            id = 0;
            nip.Clear();
            nama.Clear();
            alamat.Clear();
            lahir.Clear();
            kelamin.Text = "";
            pelajaran.Text = "";
            jabatan.Clear();
        }

        private void RekamDataGuru()
        {
            SqlCommand cmd = new SqlCommand("select * from guru", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridGuru.DataSource = dt;
        }

        private void dataguru_Load(object sender, EventArgs e)
        {
            RekamDataGuru();
            combo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE guru SET nip = @nip, nama = @nama, alamat = @alamat, lahir = @lahir, tgl  = @tgl, kelamin = @kelamin, pelajaran = @pelajaran, jabatan = @jabatan WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nip", nip.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@alamat", alamat.Text);
                cmd.Parameters.AddWithValue("@lahir", lahir.Text);
                cmd.Parameters.AddWithValue("@tgl", tgl.Value);
                cmd.Parameters.AddWithValue("@kelamin", kelamin.Text);
                cmd.Parameters.AddWithValue("@pelajaran", pelajaran.Text);
                cmd.Parameters.AddWithValue("@jabatan", jabatan.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Guru telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataGuru();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan diupdate datanya", "Pilih?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridGuru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridGuru.SelectedRows[0].Cells[0].Value);
            nip.Text = dataGridGuru.SelectedRows[0].Cells[1].Value.ToString();
            nama.Text = dataGridGuru.SelectedRows[0].Cells[2].Value.ToString();
            alamat.Text = dataGridGuru.SelectedRows[0].Cells[3].Value.ToString();
            lahir.Text = dataGridGuru.SelectedRows[0].Cells[4].Value.ToString();
            tgl.Text = dataGridGuru.SelectedRows[0].Cells[5].Value.ToString();
            kelamin.Text = dataGridGuru.SelectedRows[0].Cells[6].Value.ToString();
            pelajaran.Text = dataGridGuru.SelectedRows[0].Cells[7].Value.ToString();
            jabatan.Text = dataGridGuru.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE guru WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Guru telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataGuru();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void combo()
        {
            pelajaran.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select pelajaran from mata_pelajaran";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                pelajaran.Items.Add(dr["pelajaran"].ToString());
            }
            con.Close();
        }
    }
}
