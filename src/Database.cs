using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ChatApp.src
{
    public struct Channel {
        public int id;
        public string name;
    }

    public struct User {
        public int id;
        public string name;
        public string DOC;
        public string PFP;
    }

    public struct Message {
        public int id;
        public User sender;
        public Channel channel;
        public string content;
        public string date;
    }

    public struct Whisper {
        public int id;
        public User sender;
        public User recipient;
        public Channel channel;
        public string content;
        public string date;
    }

    public class Database
    {
        private SQLiteConnection? sqlite_conn;
        private SQLiteCommand? sqlite_cmd;

        private Dictionary<int, Channel>? channels  = new Dictionary<int, Channel>();
        private Dictionary<int, User>? users        = new Dictionary<int, User>();
        private Dictionary<int, Message>? messages  = new Dictionary<int, Message>();
        private Dictionary<int, Whisper>? whispers  = new Dictionary<int, Whisper>();

        private static Database? INSTANCE = null;

        public static Database GetInstance() {
            if (INSTANCE == null) { 
                INSTANCE = new Database();
            }

            return INSTANCE;
        }

        public Database() {
            sqlite_conn = new SQLiteConnection("Data Source=database\\database.db; Version = 3; New = False; Compress = True; ");
        }

        public void Close() {
            sqlite_conn!.Close();
        }

        private SQLiteDataReader? runCommand(string str, bool nonQuery = false) {
            
            if(sqlite_conn!.State != ConnectionState.Open) sqlite_conn!.Open();

            sqlite_cmd = sqlite_conn!.CreateCommand();
            sqlite_cmd.CommandText = str;

            if (nonQuery)
            {
                _ = sqlite_cmd.ExecuteNonQuery();
                return null;
            }
            return sqlite_cmd.ExecuteReader();
        }

        public Dictionary<int, Channel> GetChannels()
        {
            channels!.Clear();

            string cmd = "SELECT * FROM Channels;";
            
            using (SQLiteDataReader reader = runCommand(cmd))
            {
                while (reader.Read())
                {
                    channels.Add(reader.GetInt32(0), new Channel { id = reader.GetInt32(0), name = reader.GetString(1) });
                }
            }
            
            return channels;
        }

        public Dictionary<int, User> GetUsers() {
            users!.Clear();

            string cmd = "SELECT * FROM Users;";

            using (SQLiteDataReader reader = runCommand(cmd))
            {
                while (reader.Read())
                {
                    users.Add(reader.GetInt32(0), new User { id = reader.GetInt32(0), name = reader.GetString(1), DOC = reader.GetString(2), PFP = reader.GetString(3) });
                }
            }
            
            return users;
        }


        public Dictionary<int, Message> GetMessages()
        {
            messages!.Clear();

            string cmd = "SELECT * FROM Messages;";

            using (SQLiteDataReader reader = runCommand(cmd))
            {
                Dictionary<int, User> userList = GetUsers();
                Dictionary<int, Channel> channelList = GetChannels();
                while (reader.Read())
                {
                    User sender = userList[reader.GetInt32(1)];
                    Channel channel = channelList[reader.GetInt32(2)];
                    messages.Add(reader.GetInt32(0), new Message { id = reader.GetInt32(0), sender = sender, channel = channel, content = reader.GetString(3), date = reader.GetString(4) });
                }
            }
            
            return messages;
        }

        public Dictionary<int, Whisper> GetWhispers()
        {
            whispers!.Clear();

            string cmd = "SELECT * FROM Whispers;";

            using (SQLiteDataReader reader = runCommand(cmd))
            {
                Dictionary<int, User> userList = GetUsers();
                Dictionary<int, Channel> channelList = GetChannels();
                while (reader.Read())
                {
                    User sender = userList[reader.GetInt32(1)];
                    User recipient = userList[reader.GetInt32(2)];
                    Channel channel = channelList[reader.GetInt32(3)];
                    whispers.Add(reader.GetInt32(0), new Whisper { id = reader.GetInt32(0), sender = sender, recipient = recipient, channel = channel, content = reader.GetString(4), date = reader.GetString(5) });
                }
            }
            
            return whispers;
        }

        public void Insert(string table, string[] valueNames, string[] valueData) {
            string valNames = string.Join(", ", valueNames);
            string valData = string.Join(", ", valueData.Select(v => $"{v}"));


            string cmd = $"INSERT INTO {table} ({valNames}) VALUES ({valData});";

            Console.WriteLine(cmd);

            _ = runCommand(cmd, true);        // Giver intet tilbage...
        }

    }
}
