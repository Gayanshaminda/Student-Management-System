using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size
                (1300, 740);

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {

        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel6.Controls.Clear(); // Clear existing controls
            panel6.Controls.Add(childForm);

            // Adjust the size of panel6 to fit the child form
            panel6.Size = childForm.Size;

            panel6.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            openChildForm(new Register());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel6.Controls.Add(panel4);
            
        }
    }
}
