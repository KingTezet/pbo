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
    public partial class guru : Form
    {
        public guru()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True");
        public int id;
       
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fa = new Form1();
            fa.Show();
        }

        private void nama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guru_Load(object sender, EventArgs e)
        {
           try
            {
                using (nilaiEntities db = new nilaiEntities())
                {
                    nisn.DataSource = db.siswas.ToList();
                    nisn.ValueMember = "id";
                    nisn.DisplayMember = "nisn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RekamDataSiswa();
        }

        private void nisn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            siswa obj = nisn.SelectedItem as siswa;
            if (obj != null)
            {
                nama.Text = obj.nama.ToString();
                kelas.Text = obj.kelas.ToString();
            }
            Cursor.Current = Cursors.Default;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO nilai VALUES (@nisn ,@nama, @kelas, @uas, @uts, @ulangan_harian, @nilai_akhir, @angka_mutu)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nisn", nisn.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@kelas", kelas.Text);
                cmd.Parameters.AddWithValue("@uas", uas.Text);
                cmd.Parameters.AddWithValue("@uts", uts.Text);
                cmd.Parameters.AddWithValue("@ulangan_harian", harian.Text);
                cmd.Parameters.AddWithValue("@nilai_akhir", nilai_akhir.Text);
                cmd.Parameters.AddWithValue("@angka_mutu", nilai_mutu.Text);




                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("nilai telah berhasil dimasukan ke database", "tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataSiswa();
                HapusData();
            }
        }

        private void RekamDataSiswa()
        {
            SqlCommand cmd = new SqlCommand("select * from nilai", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridNilai.DataSource = dt;
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
            nisn.Text = "";
            nama.Clear();
            kelas.Clear();
            uas.Clear();
            uts.Clear();
            harian.Clear();
            nilai_akhir.Clear();
            nilai_mutu.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE siswa SET nisn = @nisn, nama = @nama, kelas = @kelas, uas = @uas, uts  = @uts, ulangan_harian = @ulangan_harian, nilai_akhir = @nilai_akhir, nilai_mutu = @angka_mutu WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nisn", nisn.Text);
                cmd.Parameters.AddWithValue("@nama", nama.Text);
                cmd.Parameters.AddWithValue("@kelas", kelas.Text);
                cmd.Parameters.AddWithValue("@uas", uas.Text);
                cmd.Parameters.AddWithValue("@uts", uts.Text);
                cmd.Parameters.AddWithValue("@ulangan_harian", harian.Text);
                cmd.Parameters.AddWithValue("@nilai_akhir", nilai_akhir.Text);
                cmd.Parameters.AddWithValue("@angka_mutu", nilai_mutu.Text);
                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Nilai telah berhasil diupdate", "terupdate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RekamDataSiswa();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Siswa yang akan diupdate datanya", "Pilih?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double uass, utss, ulangan_harian, nilai_akhirr, tot;
            string grade;

            uass = int.Parse(uas.Text);
            utss = int.Parse(uts.Text);
            ulangan_harian = int.Parse(harian.Text);
            


            tot = uass + utss + ulangan_harian;

            nilai_akhirr = tot / 3;

            nilai_akhir.Text = nilai_akhirr.ToString();

            if (nilai_akhirr >= 90)
            {
                grade = "A";
            }
            else if (nilai_akhirr >= 80)
            {
                grade = "B";
            }
            else if (nilai_akhirr >= 70)
            {
                grade = "C";
            }
            else 
            {
                grade = "D";
            }

            nilai_mutu.Text = grade; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE nilai WHERE id = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Nilai telah dihapus dari database", "terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RekamDataSiswa();
                HapusData();
            }
            else
            {
                MessageBox.Show("Silahkan pilih salah satu Guru yang akan dihapus datanya", "Hapus?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void dataGridNilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridNilai.SelectedRows[0].Cells[0].Value);
            nisn.Text = dataGridNilai.SelectedRows[0].Cells[1].Value.ToString();
            nama.Text = dataGridNilai.SelectedRows[0].Cells[2].Value.ToString();
            kelas.Text = dataGridNilai.SelectedRows[0].Cells[3].Value.ToString();
            uas.Text = dataGridNilai.SelectedRows[0].Cells[4].Value.ToString();
            uts.Text = dataGridNilai.SelectedRows[0].Cells[5].Value.ToString();
            harian.Text = dataGridNilai.SelectedRows[0].Cells[6].Value.ToString();
            nilai_akhir.Text = dataGridNilai.SelectedRows[0].Cells[7].Value.ToString();
            nilai_mutu.Text = dataGridNilai.SelectedRows[0].Cells[8].Value.ToString();
        }
    }
}
