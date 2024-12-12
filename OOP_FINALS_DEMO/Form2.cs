using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_FINALS_DEMO
{
    public partial class Form2 : Form
    {
        private Form activeForm = null; 

        public Form2()
        {
            InitializeComponent();
        }

       
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close(); 
            }

            activeForm = childForm; 
            childForm.TopLevel = false; 
            childForm.Dock = DockStyle.Fill; 

            panel2.Controls.Clear(); 
            panel2.Controls.Add(childForm); 
            panel2.Tag = childForm; 

            childForm.BringToFront(); 
            childForm.Show(); 
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            OpenChildForm(form3); 
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            OpenChildForm(form4); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            using (Form1 form1 = new Form1())
            {
                form1.ShowDialog(); 
            }
            this.Close(); 
        }
       
        public void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
