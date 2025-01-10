namespace ChatApp;

partial class Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        sendBtn = new Button();
        panel1 = new Panel();
        txtOutput = new Label();
        panel2 = new Panel();
        messageBox1 = new TextBox();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        button1 = new Button();
        button2 = new Button();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // sendBtn
        // 
        sendBtn.BackColor = Color.FromArgb(66, 44, 127);
        sendBtn.BackgroundImage = (Image)resources.GetObject("sendBtn.BackgroundImage");
        sendBtn.BackgroundImageLayout = ImageLayout.Stretch;
        sendBtn.FlatStyle = FlatStyle.Popup;
        sendBtn.Location = new Point(1110, 530);
        sendBtn.Margin = new Padding(20);
        sendBtn.Name = "sendBtn";
        sendBtn.Size = new Size(70, 70);
        sendBtn.TabIndex = 1;
        sendBtn.UseVisualStyleBackColor = false;
        sendBtn.Click += send_click;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(20, 20, 25);
        panel1.BackgroundImageLayout = ImageLayout.None;
        panel1.Controls.Add(txtOutput);
        panel1.Controls.Add(panel2);
        panel1.Controls.Add(sendBtn);
        panel1.Location = new Point(50, 50);
        panel1.Margin = new Padding(0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1200, 620);
        panel1.TabIndex = 2;
        // 
        // txtOutput
        // 
        txtOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        txtOutput.BackColor = Color.FromArgb(66, 44, 127);
        txtOutput.Font = new Font("Roboto", 10F);
        txtOutput.ForeColor = Color.White;
        txtOutput.Location = new Point(748, 343);
        txtOutput.MaximumSize = new Size(400, 600);
        txtOutput.MinimumSize = new Size(400, 125);
        txtOutput.Name = "txtOutput";
        txtOutput.Size = new Size(400, 125);
        txtOutput.TabIndex = 0;
        txtOutput.Text = "Text Output";
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(31, 28, 38);
        panel2.Controls.Add(messageBox1);
        panel2.Location = new Point(100, 530);
        panel2.Name = "panel2";
        panel2.Size = new Size(885, 70);
        panel2.TabIndex = 4;
        // 
        // messageBox1
        // 
        messageBox1.AcceptsReturn = true;
        messageBox1.AcceptsTab = true;
        messageBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        messageBox1.BackColor = Color.FromArgb(31, 28, 38);
        messageBox1.BorderStyle = BorderStyle.None;
        messageBox1.Cursor = Cursors.IBeam;
        messageBox1.Font = new Font("Roboto", 16F);
        messageBox1.ForeColor = Color.White;
        messageBox1.Location = new Point(5, 4);
        messageBox1.Multiline = true;
        messageBox1.Name = "messageBox1";
        messageBox1.PlaceholderText = "Message";
        messageBox1.Size = new Size(875, 66);
        messageBox1.TabIndex = 3;
        // 
        // button1
        // 
        button1.BackColor = Color.FromArgb(8, 7, 10);
        button1.BackgroundImageLayout = ImageLayout.None;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Location = new Point(0, 0);
        button1.Name = "button1";
        button1.Size = new Size(1300, 50);
        button1.TabIndex = 5;
        button1.UseVisualStyleBackColor = false;
        button1.MouseDown += button1_MouseDown_1;
        // 
        // button2
        // 
        button2.BackColor = Color.FromArgb(66, 44, 127);
        button2.FlatStyle = FlatStyle.Popup;
        button2.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.ForeColor = Color.White;
        button2.Location = new Point(1238, 12);
        button2.Name = "button2";
        button2.Size = new Size(30, 30);
        button2.TabIndex = 11;
        button2.Text = "X";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        BackColor = Color.FromArgb(8, 7, 10);
        ClientSize = new Size(1280, 720);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.None;
        Margin = new Padding(3, 4, 3, 4);
        MaximumSize = new Size(1300, 720);
        Name = "Main";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Chat Application";
        panel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button sendBtn;
    private Panel panel1;
    private TextBox messageBox1;
    private Panel panel2;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Label txtOutput;
    private Button button1;
    private Button button2;
}
