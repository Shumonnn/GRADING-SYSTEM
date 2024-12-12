using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_FINALS_DEMO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadSections();
        }

        private void LoadCourses()
        {
            string query = "SELECT CourseName FROM course";
            Database db = new Database();
            DataTable courses = db.ExecuteQuery(query);

            comboBox1.Items.Clear();
            foreach (DataRow row in courses.Rows)
            {
                comboBox1.Items.Add(row["CourseName"].ToString());
            }
        }

        private void LoadSections()
        {
            string query = "SELECT SectionName FROM blocksection";
            Database db = new Database();
            DataTable sections = db.ExecuteQuery(query);

            comboBox2.Items.Clear();
            foreach (DataRow row in sections.Rows)
            {
                comboBox2.Items.Add(row["SectionName"].ToString());
            }
        }

        private void PopulateListView(DataTable dataTable)
        {
            // Convert DataTable to a list for sorting
            var rows = dataTable.AsEnumerable().ToList();

            // Apply QuickSort to sort rows by FinalGrade
            QuickSort(rows, 0, rows.Count - 1);

            // Populate ListView with sorted rows
            listView1.Items.Clear();
            foreach (var row in rows)
            {
                ListViewItem item = new ListViewItem(row["StudentNumber"].ToString());
                item.SubItems.Add(row["StudentName"].ToString());
                item.SubItems.Add(row["MidtermGrade"].ToString());
                item.SubItems.Add(row["FinalsGrade"].ToString());
                item.SubItems.Add(row["FinalGrade"].ToString());
                listView1.Items.Add(item);
            }
        }

        private void QuickSort(List<DataRow> rows, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(rows, low, high);

                // Recursively sort elements before and after the partition
                QuickSort(rows, low, pivotIndex - 1);
                QuickSort(rows, pivotIndex + 1, high);
            }
        }

        private int Partition(List<DataRow> rows, int low, int high)
        {
            decimal pivot = Convert.ToDecimal(rows[high]["FinalGrade"]);
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (Convert.ToDecimal(rows[j]["FinalGrade"]) <= pivot)
                {
                    i++;
                    
                    var temp = rows[i];
                    rows[i] = rows[j];
                    rows[j] = temp;
                }
            }

           
            var tempPivot = rows[i + 1];
            rows[i + 1] = rows[high];
            rows[high] = tempPivot;

            return i + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        WHERE s.FinalGrade >= 75";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        WHERE s.FinalGrade < 60";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        WHERE s.FinalGrade < 40";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        WHERE s.FinalGrade = 50";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = comboBox1.SelectedItem.ToString();
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        LEFT JOIN blocksection bs ON s.StudentID = bs.StudentID
        LEFT JOIN course c ON bs.CourseID = c.CourseID
        WHERE c.CourseName = @course";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@course", selectedCourse)
            };

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query, parameters);

            PopulateListView(result);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSection = comboBox2.SelectedItem.ToString();
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        LEFT JOIN blocksection bs ON s.StudentID = bs.StudentID
        WHERE bs.SectionName = @SectionTest";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@SectionTest", selectedSection)
            };

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query, parameters);

            PopulateListView(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        LEFT JOIN blocksection bs ON s.StudentID = bs.StudentID";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentNumber, 
            s.StudentName, 
            s.MidtermGrade, 
            s.FinalsGrade, 
            s.FinalGrade 
        FROM student s
        WHERE s.FinalGrade < 75";

            Database db = new Database();
            DataTable result = db.ExecuteQuery(query);

            PopulateListView(result);
        }
    }
}
