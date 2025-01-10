namespace ChatApp.src
{
    partial class Login
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
            textBox1 = new TextBox();
            button2 = new Button();
            textBox2 = new TextBox();
            panel1 = new Panel();
            button3 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(31, 28, 38);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(25, 100);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Username";
            textBox1.Size = new Size(250, 25);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(66, 44, 127);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(100, 150);
            button2.Name = "button2";
            button2.Size = new Size(100, 40);
            button2.TabIndex = 6;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(20, 19, 25);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Roboto", 20F, FontStyle.Bold);
            textBox2.ForeColor = Color.FromArgb(66, 44, 127);
            textBox2.Location = new Point(100, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 41);
            textBox2.TabIndex = 7;
            textBox2.Text = "Chat";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 19, 25);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(52, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 250);
            panel1.TabIndex = 8;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(8, 7, 10);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(400, 50);
            button3.TabIndex = 9;
            button3.UseVisualStyleBackColor = false;
            button3.MouseDown += button3_MouseDown;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(66, 44, 127);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(358, 12);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 10;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(8, 7, 10);
            ClientSize = new Size(400, 350);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox2;
        private Panel panel1;
        private Button button3;
        private Button button1;
    }
}