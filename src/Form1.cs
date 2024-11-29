using System.Net;

namespace ChatApp;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private void messageBox_textWritten(object sender, EventArgs e)
    {

    }

    private void send_click(object sender, EventArgs e)
    {
        if (!HttpListener.IsSupported) {
            MessageBox.Show("Http servers are not supported on your machine sadly", "Alert", MessageBoxButtons.OK);
            throw new Exception("HttpListener not supported!");
        }


    }
}
