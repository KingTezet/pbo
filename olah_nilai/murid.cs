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
    public partial class murid : Form
    {
        public murid()
        {
            InitializeComponent();
        }

        private void murid_Load(object sender, EventArgs e)
        {
            dataGridNilai.DataSource = this.PopulateDataGridView();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridNilai.DataSource = this.PopulateDataGridView();    
        }

        private DataTable PopulateDataGridView()
        {
            string query = "SELECT nisn ,nama, kelas, uas, uts, ulangan_harian, nilai_akhir, angka_mutu FROM nilai";
            query += " WHERE nisn LIKE '%' + @nisn + '%'";
            query += " OR @nisn = ''";
            string constr = @"Data Source=LABRPL1\SQLEXPRESS;Initial Catalog=olah_nilai;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nisn", nama.Text.Trim());
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fa = new Form1();
            fa.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
