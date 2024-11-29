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
        messageBox = new RichTextBox();
        sendBtn = new Button();
        SuspendLayout();
        // 
        // messageBox
        // 
        messageBox.Location = new Point(41, 363);
        messageBox.Name = "messageBox";
        messageBox.Size = new Size(640, 60);
        messageBox.TabIndex = 0;
        messageBox.Text = "";
        messageBox.TextChanged += messageBox_textWritten;
        // 
        // button1
        // 
        sendBtn.Location = new Point(702, 363);
        sendBtn.Name = "button1";
        sendBtn.Size = new Size(75, 60);
        sendBtn.TabIndex = 1;
        sendBtn.Text = "button1";
        sendBtn.UseVisualStyleBackColor = true;
        sendBtn.Click += send_click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(sendBtn);
        Controls.Add(messageBox);
        Name = "Main";
        Text = "Chat Application";
        ResumeLayout(false);
    }

    #endregion

    private RichTextBox messageBox;
    private Button sendBtn;
}
