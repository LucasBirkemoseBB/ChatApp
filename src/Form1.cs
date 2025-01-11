using ChatApp.src;
using System;
using System.Net;

namespace ChatApp;

public partial class Main : Form
{
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    public Main()
    {
        InitializeComponent();
        Dictionary<int, ChatApp.src.Message> dbmessages = Database.GetInstance().GetMessages();
        Font roboto = new Font("Roboto", 10F);
        foreach (ChatApp.src.Message msg in dbmessages.Values)
        {
            Label lmsg = new Label();

            bool recieving = !msg.sender.name.Equals(Session.currentSession.user.name);

            int index = msg.id;

            lmsg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lmsg.BackColor = Color.FromArgb(66, 44, 127);
            lmsg.Font = roboto;
            lmsg.ForeColor = Color.White;
            lmsg.Location = new Point(748, 243/* - (dbmessages.Count - 3 - index) * ((int)roboto.GetHeight() + 4)*/);
            lmsg.MaximumSize = new Size(300, ((int)roboto.GetHeight() + 2) * 5);
            lmsg.MinimumSize = new Size(300, (int)roboto.GetHeight() + 2);
            lmsg.Name = "msgnr" + index;
            lmsg.Size = new Size(300, ((int)roboto.GetHeight() + 2) * 5);
            lmsg.TabIndex = 0;
            lmsg.Text = msg.content + $"\n//Sent from: {msg.sender.name}";


            if (recieving)
            {
                lmsg.BackColor = Color.FromArgb(33, 22, 33);
                lmsg.Location = new Point(100, lmsg.Location.Y);
            }

            int cnt = 1;
            foreach (Label lbl in messages)
            {
                lbl.Location = new Point(lbl.Location.X, lbl.Location.Y - cnt * ((int)roboto.GetHeight() + 4) * 5);
                cnt++;
            }

            messages.Append(lmsg);
            panel1.Controls.Add(lmsg);
        }
    }

    private void messageBox_textWritten(object sender, EventArgs e)
    {

    }

    private void send_click(object sender, EventArgs e)
    {
        Font roboto = new Font("Roboto", 10F);
        Label new_msg = new Label();

        var users = Database.GetInstance().GetUsers();

        string[] valueNames = { "SenderID", "ChannelID", "Content", "Date" };
        string[] valueData = { $"{Session.currentSession!.user.id}", "1", $"'{messageBox1.Text}'", $"'{DateTime.Now.ToString("yyyy-MM-dd")}'" };

        Database.GetInstance().Insert("Messages", valueNames, valueData);
        Dictionary<int, ChatApp.src.Message> dbmessages = Database.GetInstance().GetMessages();

        new_msg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        new_msg.BackColor = Color.FromArgb(66, 44, 127);
        new_msg.Font = roboto;
        new_msg.ForeColor = Color.White;
        new_msg.Location = new Point(748, 243);
        new_msg.MaximumSize = new Size(300, ((int)roboto.GetHeight() + 2) * 5);
        new_msg.MinimumSize = new Size(300, (int)roboto.GetHeight() + 2);
        new_msg.Name = "msgnr" + dbmessages.ToArray().Length;
        new_msg.Size = new Size(300, ((int)roboto.GetHeight() + 2) * 5);
        new_msg.TabIndex = 0;
        new_msg.Text = messageBox1.Text + $" sent from: {Session.currentSession!.user.name}";

        foreach(Label lmsg in messages) {
            lmsg.Location = new Point(lmsg.Location.X, lmsg.Location.Y - ((int)roboto.GetHeight() + 4) * 5);
        }

        messages.Add(new_msg);
        panel1.Controls.Add(new_msg);
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter_1(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        Database.GetInstance().Close();
        Application.Exit();
    }

    private void button1_MouseDown_1(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}

