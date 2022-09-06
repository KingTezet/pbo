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
    public partial class user : UserControl
    {
        public user()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO usr VALUES (@username, @password, @hak)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@hak", hak.Text);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Baru telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataUser();
                HapusData();
            }
        }

        private void user_Load(object sender, EventArgs e)
        {
            RekamDataUser();
        }

        private bool IsValid()
        {

            if (username.Text == String.Empty)
            {
                MessageBox.Show("username tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (password.Text == String.Empty)
            {
                MessageBox.Show("Password tidak boleh kosong", "salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                return true;
        }

        private void HapusData()
        {
            password.Clear();
            username.Clear();
            hak.Text = "";
        }

        private void RekamDataUser()
        {
            SqlCommand cmd = new SqlCommand("select * from usr", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridUser.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE usr SET  username = @username, password = @password, hak = @hak  WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@hak", hak.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("User telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataUser();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu User yang akan diupdate datanya", "Pilih?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE usr WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data user telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataUser();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu User yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void dataGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridUser.SelectedRows[0].Cells[0].Value);
            username.Text = dataGridUser.SelectedRows[0].Cells[1].Value.ToString();
            password.Text = dataGridUser.SelectedRows[0].Cells[2].Value.ToString();
            hak.Text = dataGridUser.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
