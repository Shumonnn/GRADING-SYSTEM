
namespace OOP_FINALS_DEMO
{
    partial class Form4
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Items.AddRange(new object[] { "Object Oriented Programming ", "Data Structures " });
            comboBox1.Location = new Point(115, 171);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(583, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Select Course";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "II-ACSAD", "II-BCSAD" });
            comboBox2.Location = new Point(115, 231);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(583, 23);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Select Block Section";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(311, 279);
            button1.Name = "button1";
            button1.Size = new Size(150, 23);
            button1.TabIndex = 4;
            button1.Text = "CONTINUE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonNext_Click1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(244, 20);
            label4.Name = "label4";
            label4.Size = new Size(300, 40);
            label4.TabIndex = 9;
            label4.Text = "University Of Makati";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(259, 60);
            label5.Name = "label5";
            label5.Size = new Size(269, 17);
            label5.TabIndex = 10;
            label5.Text = "CCIS Faculty Grade Encoder and Calculator";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 96, 112);
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Label label4;
        private Label label5;
    }
}