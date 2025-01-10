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
    }

    private void messageBox_textWritten(object sender, EventArgs e)
    {

    }

    private void send_click(object sender, EventArgs e)
    {
        // Get text from the input TextBox
        string inputText = messageBox1.Text;

        // Display the text in the Label or Output TextBox
        txtOutput.Text = inputText; // If using Label

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter_1(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
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

