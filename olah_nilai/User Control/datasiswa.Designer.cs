namespace olah_nilai.User_Control
{
    partial class datasiswa
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kelamin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridSiswa = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.kelas = new System.Windows.Forms.ComboBox();
            this.lahir = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tgl = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.alamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nisn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.olah_nilaiDataSet = new olah_nilai.olah_nilaiDataSet();
            this.olahnilaiDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.olah_nilaiDataSet1 = new olah_nilai.olah_nilaiDataSet1();
            this.siswaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siswaTableAdapter = new olah_nilai.olah_nilaiDataSet1TableAdapters.siswaTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiswa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olah_nilaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olahnilaiDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olah_nilaiDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siswaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kelamin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridSiswa);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.kelas);
            this.panel1.Controls.Add(this.lahir);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tgl);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.alamat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nisn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 509);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // kelamin
            // 
            this.kelamin.FormattingEnabled = true;
            this.kelamin.Items.AddRange(new object[] {
            "Laki-Laki",
            "Perempuan"});
            this.kelamin.Location = new System.Drawing.Point(117, 187);
            this.kelamin.Name = "kelamin";
            this.kelamin.Size = new System.Drawing.Size(146, 21);
            this.kelamin.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Jenis Kelamin";
            // 
            // dataGridSiswa
            // 
            this.dataGridSiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSiswa.Location = new System.Drawing.Point(31, 322);
            this.dataGridSiswa.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridSiswa.Name = "dataGridSiswa";
            this.dataGridSiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSiswa.Size = new System.Drawing.Size(805, 150);
            this.dataGridSiswa.TabIndex = 26;
            this.dataGridSiswa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSiswa_CellClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(610, 259);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(427, 259);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "Hapus";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 259);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Simpan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kelas
            // 
            this.kelas.FormattingEnabled = true;
            this.kelas.Location = new System.Drawing.Point(662, 140);
            this.kelas.Name = "kelas";
            this.kelas.Size = new System.Drawing.Size(146, 21);
            this.kelas.TabIndex = 18;
            this.kelas.SelectedIndexChanged += new System.EventHandler(this.kelas_SelectedIndexChanged);
            // 
            // lahir
            // 
            this.lahir.Location = new System.Drawing.Point(662, 19);
            this.lahir.Name = "lahir";
            this.lahir.Size = new System.Drawing.Size(146, 20);
            this.lahir.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(575, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tempat Lahir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kelas";
            // 
            // tgl
            // 
            this.tgl.Location = new System.Drawing.Point(662, 75);
            this.tgl.Name = "tgl";
            this.tgl.Size = new System.Drawing.Size(146, 20);
            this.tgl.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tanggal Lahir";
            // 
            // alamat
            // 
            this.alamat.Location = new System.Drawing.Point(117, 136);
            this.alamat.Name = "alamat";
            this.alamat.Size = new System.Drawing.Size(146, 20);
            this.alamat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alamat";
            // 
            // nama
            // 
            this.nama.Location = new System.Drawing.Point(117, 78);
            this.nama.Name = "nama";
            this.nama.Size = new System.Drawing.Size(146, 20);
            this.nama.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Siswa";
            // 
            // nisn
            // 
            this.nisn.Location = new System.Drawing.Point(117, 15);
            this.nisn.Name = "nisn";
            this.nisn.Size = new System.Drawing.Size(146, 20);
            this.nisn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NISN";
            // 
            // olah_nilaiDataSet
            // 
            this.olah_nilaiDataSet.DataSetName = "olah_nilaiDataSet";
            this.olah_nilaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // olahnilaiDataSetBindingSource
            // 
            this.olahnilaiDataSetBindingSource.DataSource = this.olah_nilaiDataSet;
            this.olahnilaiDataSetBindingSource.Position = 0;
            // 
            // olah_nilaiDataSet1
            // 
            this.olah_nilaiDataSet1.DataSetName = "olah_nilaiDataSet1";
            this.olah_nilaiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // siswaBindingSource
            // 
            this.siswaBindingSource.DataMember = "siswa";
            this.siswaBindingSource.DataSource = this.olah_nilaiDataSet1;
            // 
            // siswaTableAdapter
            // 
            this.siswaTableAdapter.ClearBeforeFill = true;
            // 
            // datasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "datasiswa";
            this.Size = new System.Drawing.Size(857, 546);
            this.Load += new System.EventHandler(this.datasiswa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiswa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olah_nilaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olahnilaiDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olah_nilaiDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siswaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridSiswa;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox kelas;
        private System.Windows.Forms.TextBox lahir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker tgl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nisn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource olahnilaiDataSetBindingSource;
        private olah_nilaiDataSet olah_nilaiDataSet;
        private olah_nilaiDataSet1 olah_nilaiDataSet1;
        private System.Windows.Forms.BindingSource siswaBindingSource;
        private olah_nilaiDataSet1TableAdapters.siswaTableAdapter siswaTableAdapter;
        private System.Windows.Forms.ComboBox kelamin;
        private System.Windows.Forms.Label label4;
    }
}
