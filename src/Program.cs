using ChatApp.src;

namespace ChatApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        if (Database.GetInstance().GetChannels().Count <= 0) {
            string[] valNames = { "Name" };
            string[] valData = { "'Only Channels'" };
            Database.GetInstance().Insert("Channels", valNames, valData);
        }
        ApplicationConfiguration.Initialize();
        Application.Run(new Login());
    }    
}