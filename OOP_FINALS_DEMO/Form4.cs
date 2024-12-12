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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void buttonNext_Click1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int selectedIndex1 = comboBox1.SelectedIndex;
                int selectedIndex2 = comboBox2.SelectedIndex;

                Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();

                if (form2 != null)
                {
                    Form5 nextForm = new Form5(selectedIndex1, selectedIndex2, comboBox1.Items, comboBox2.Items);

                    nextForm.TopLevel = false; 
                    nextForm.Dock = DockStyle.Fill;

                    form2.panel2.Controls.Add(nextForm);  
                    nextForm.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please make sure both fields have selected items.");
            }
        }


            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
