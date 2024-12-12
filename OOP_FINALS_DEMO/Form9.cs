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
    public partial class GrpActForm : Form
    {
        public double CalculatedAverage { get; private set; }
        public GrpActForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalScore = 0;
            double totalItems = 0;

            totalScore += GetScore(textBox1.Text, textBox6.Text);
            totalScore += GetScore(textBox2.Text, textBox7.Text); 
            totalScore += GetScore(textBox3.Text, textBox8.Text); 
            totalScore += GetScore(textBox4.Text, textBox9.Text); 
            totalScore += GetScore(textBox5.Text, textBox10.Text); 

            totalItems += GetTotal(textBox6.Text);
            totalItems += GetTotal(textBox7.Text);
            totalItems += GetTotal(textBox8.Text);
            totalItems += GetTotal(textBox9.Text);
            totalItems += GetTotal(textBox10.Text);

            if (totalItems > 0)
            {
                CalculatedAverage = (totalScore / totalItems) * 100;  
            }
            else
            {
                CalculatedAverage = 0;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private double GetScore(string studentScore, string totalItems)
        {

            double score = 0;
            double total = 0;
            double.TryParse(studentScore, out score);
            double.TryParse(totalItems, out total);
            return total > 0 ? score : 0;
        }

        private double GetTotal(string totalItems)
        {

            double total = 0;
            double.TryParse(totalItems, out total);
            return total;
        }
    }   
}
