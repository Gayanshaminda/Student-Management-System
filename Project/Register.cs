using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Register : Form
    {
        studentclass student = new studentclass();

        public Register()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size
            (1150, 750);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Upload
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(ofd.FileName);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Add
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox4.Text;
            string address = textBox3.Text;
            string gender = radioButton1.Checked ? "Male" : "Female";


            // We need to check student age between 10 and 100
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be between 10 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {

                    // To get photo from picture box
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if (student.insertStudent(fname, lname, bdate, gender, phone, address, img))
                    {
                        showTable();
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Verify
        bool verify()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                pictureBox_student.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox3.Clear();
            radioButton1.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_student.Image = null;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Your code for label1_Click event
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Your code for guna2DataGridView1_CellContentClick event
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Your code for label2_Click event
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Your code for label5_Click event
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Your code for label6_Click event
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Your code for radioButton1_CheckedChanged event
        }

        private void Register_Load(object sender, EventArgs e)
        {
            showTable();
            // Assuming you want to center-align content in the first column (index 0)
            DataGridView_student.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Assuming you want to center-align content in the first column (index 0)
            DataGridView_student.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentlist();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Your code for textBox1_TextChanged event
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Your code for textBox3_TextChanged event
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_student_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
