using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OOP_FINALS_DEMO
{
    public partial class Form5 : Form
    {
        private readonly Database db = new();

        public Form5(int selectedIndex1, int selectedIndex2, ComboBox.ObjectCollection items1, ComboBox.ObjectCollection items2)
        {
            InitializeComponent();
            InitializeComboBoxes(items1, items2, selectedIndex1, selectedIndex2);
        }

        public Form5(ListView.ListViewItemCollection itemsFromForm3)
        {
            InitializeComponent();
            PopulateListView(itemsFromForm3);
        }

        private void InitializeComboBoxes(ComboBox.ObjectCollection items1, ComboBox.ObjectCollection items2, int index1, int index2)
        {
            comboBox1.Items.AddRange(items1.Cast<object>().ToArray());
            comboBox2.Items.AddRange(items2.Cast<object>().ToArray());

            comboBox1.SelectedIndex = index1;
            comboBox2.SelectedIndex = index2;

            LoadData(comboBox1.SelectedItem?.ToString(), comboBox2.SelectedItem?.ToString());
        }

        private void PopulateListView(ListView.ListViewItemCollection items)
        {
            listView1.Items.Clear();
            foreach (ListViewItem item in items)
            {
                listView1.Items.Add((ListViewItem)item.Clone());
            }

            // Call BubbleSort to sort by FinalGrade
            BubbleSort(listView1.Items);
        }

        private void LoadData(string selectedCourse = null, string selectedSection = null)
        {
            string query = @"SELECT StudentNumber, StudentName, MidtermGrade, FinalsGrade, FinalGrade, Course, SectionTest 
                             FROM student
                             WHERE (@Course IS NULL OR Course = @Course)
                               AND (@SectionTest IS NULL OR SectionTest = @SectionTest)
                             UNION ALL
                             SELECT StudentNumber, StudentName, MidtermGrade, FinalsGrade, FinalGrade, Course, SectionTest 
                             FROM studentoopgr
                             WHERE (@Course IS NULL OR Course = @Course)
                               AND (@SectionTest IS NULL OR SectionTest = @SectionTest)";

            try
            {
                using (var connection = db.GetConnection())
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Course", string.IsNullOrEmpty(selectedCourse) ? (object)DBNull.Value : selectedCourse);
                    command.Parameters.AddWithValue("@SectionTest", string.IsNullOrEmpty(selectedSection) ? (object)DBNull.Value : selectedSection);

                    DataTable dataTable = new DataTable();
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        PopulateListView(dataTable);
                        CalculateAndSaveFinalGrades(dataTable);
                    }
                    else
                    {
                        listView1.Items.Clear();
                        MessageBox.Show("No data found for the selected filters.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void PopulateListView(DataTable dataTable)
        {
            listView1.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new ListViewItem(row["StudentNumber"].ToString());
                item.SubItems.Add(row["StudentName"].ToString());
                item.SubItems.Add(row["MidtermGrade"].ToString());
                item.SubItems.Add(row["FinalsGrade"].ToString());
                item.SubItems.Add(row["FinalGrade"].ToString());
                item.SubItems.Add(row["Course"].ToString());
                item.SubItems.Add(row["SectionTest"].ToString());
                listView1.Items.Add(item);
            }

            // Call BubbleSort to sort by FinalGrade
            BubbleSort(listView1.Items);
        }

        private void CalculateAndSaveFinalGrades(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string studentNumber = row["StudentNumber"].ToString();

                if (row.IsNull("FinalGrade") || string.IsNullOrWhiteSpace(row["FinalGrade"].ToString()) ||
                    double.TryParse(row["FinalGrade"].ToString(), out double finalGrade) && finalGrade == 0)
                {
                    double midtermGrade = row.IsNull("MidtermGrade") ? 0 : Convert.ToDouble(row["MidtermGrade"]);
                    double finalsGrade = row.IsNull("FinalsGrade") ? 0 : Convert.ToDouble(row["FinalsGrade"]);

                    finalGrade = (0.4 * midtermGrade) + (0.6 * finalsGrade);
                    SaveFinalGradeToDatabase(studentNumber, finalGrade);
                }
            }
        }

        private void SaveFinalGradeToDatabase(string studentNumber, double finalGrade)
        {
            string query = @"UPDATE student
                             SET FinalGrade = @FinalGrade
                             WHERE StudentNumber = @StudentNumber AND (FinalGrade IS NULL OR FinalGrade = 0);
                             UPDATE studentoopgr
                             SET FinalGrade = @FinalGrade
                             WHERE StudentNumber = @StudentNumber AND (FinalGrade IS NULL OR FinalGrade = 0);";

            try
            {
                using (var connection = db.GetConnection())
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    command.Parameters.AddWithValue("@FinalGrade", finalGrade);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataFromComboBoxes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataFromComboBoxes();
        }

        private void LoadDataFromComboBoxes()
        {
            string selectedCourse = comboBox1.SelectedItem?.ToString() == "All Courses" ? null : comboBox1.SelectedItem?.ToString();
            string selectedSection = comboBox2.SelectedItem?.ToString() == "All Sections" ? null : comboBox2.SelectedItem?.ToString();
            LoadData(selectedCourse, selectedSection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string firstColumn = selectedItem.SubItems[0].Text;
                string secondColumn = selectedItem.SubItems[1].Text;

                Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();

                if (form2 != null)
                {

                    Form6 form6 = new Form6(firstColumn, secondColumn);

                    form6.TopLevel = false;
                    form6.Dock = DockStyle.Fill;

                    form2.panel2.Controls.Add(form6);
                    form6.Show();

                    this.Hide();

                    form6.FormClosed += (s, args) => this.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select a student from the list.");
            }
        }

        // BubbleSort to sort ListView items by FinalGrade
        private void BubbleSort(ListView.ListViewItemCollection items)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < items.Count - 1; i++)
                {
                    // Compare the FinalGrade 
                    double currentGrade = Convert.ToDouble(items[i].SubItems[4].Text);
                    double nextGrade = Convert.ToDouble(items[i + 1].SubItems[4].Text);

                    if (currentGrade > nextGrade)  // Swap if current grade is greater than next grade
                    {
                        var temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
