using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace OOP_FINALS_DEMO
{
    public partial class Form6 : Form
    {
        private string firstColumnData;
        private string secondColumnData;

        public double ProjectScore { get; private set; }
        public double RecitationScore { get; private set; }
        public double ExamPercentage { get; private set; }

        public Form6(string firstColumnData, string secondColumnData)
        {
            InitializeComponent();
            this.firstColumnData = firstColumnData;
            this.secondColumnData = secondColumnData;
        }

        private void form6_Load(object sender, EventArgs e)
        {
            label10.Text = firstColumnData; 
            label11.Text = secondColumnData; 

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Midterm");
            comboBox1.Items.Add("Finals");
            comboBox1.SelectedIndex = 0; 
        }

        private void textBox3_Click(object sender, MouseEventArgs e)
        {
            QuizForm quizForm = new QuizForm();

            if (quizForm.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = quizForm.CalculatedAverage.ToString("F2");
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm();

            if (activityForm.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = activityForm.CalculatedAverage.ToString("F2");
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            GrpActForm grpActForm = new GrpActForm();

            if (grpActForm.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = grpActForm.CalculatedAverage.ToString("F2");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double recitationScore))
            {
                RecitationScore = recitationScore;
            }
            else
            {
                RecitationScore = 0;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox4.Text, out double projectScore))
            {
                ProjectScore = projectScore;
            }
            else
            {
                ProjectScore = 0;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string input = textBox6.Text;

            if (!string.IsNullOrEmpty(input) && input.Contains("/"))
            {
                string[] parts = input.Split('/');
                if (parts.Length == 2 &&
                    double.TryParse(parts[0], out double rawScore) &&
                    double.TryParse(parts[1], out double totalItems) &&
                    totalItems > 0)
                {
                    ExamPercentage = (rawScore / totalItems) * 100;
                }
                else
                {
                    ExamPercentage = 0;
                }
            }
            else
            {
                ExamPercentage = 0;
            }
        }

        private void SaveGradeToDatabase(string term, double grade)
        {
            try
            {
                string studentID = label10.Text; 
                string connectionString = "Server=localhost;Database=gradestudentcalculator;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string columnToUpdate = term == "Midterm" ? "MidtermGrade" : "FinalsGrade";
                    string query = $"UPDATE student SET {columnToUpdate} = @Grade WHERE StudentNumber = @StudentNumber";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.Parameters.AddWithValue("@StudentNumber", studentID);

                        MessageBox.Show($"Saving grade {grade} for {columnToUpdate} to student {studentID}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving grade to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double exam = ExamPercentage;
                double project = ProjectScore;
                double activity = double.TryParse(textBox2.Text, out double a) ? a : 0;
                double quiz = double.TryParse(textBox3.Text, out double q) ? q : 0;
                double groupActivity = double.TryParse(textBox5.Text, out double g) ? g : 0;
                double recitation = RecitationScore;

                double finalGrade = (exam * 0.40) + (project * 0.20) + (activity * 0.15) +
                                    (quiz * 0.10) + (groupActivity * 0.10) + (recitation * 0.05);

                string selectedTerm = comboBox1.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(selectedTerm))
                {
                    MessageBox.Show("Please select a term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveGradeToDatabase(selectedTerm, finalGrade);

                MessageBox.Show("Grade successfully saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
