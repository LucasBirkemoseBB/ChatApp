using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.src
{
    public class Session
    {
        public static Session? currentSession;

        public User user;
        public Session(User user) { this.user = user; }

        public static Session Login(string username) {
            Dictionary<int, User> users = Database.GetInstance().GetUsers();

            foreach (User us in users.Values) {
                if (us.name.ToLower().Equals(username.ToLower())) {
                    return new Session(us);
                }
            }

            string[] valueNames = { "Name", "DOC", "PFP" };
            string[] valueData = { $"'{username}'", $"'{DateTime.Now.ToString("yyyy-MM-dd")}'", "'SomeImage.png'" };
            Database.GetInstance().Insert("Users", valueNames, valueData);

            users = Database.GetInstance().GetUsers();

            foreach (User us in users.Values)
            {
                if (us.name.ToLower().Equals(username.ToLower()))
                {
                    return new Session(us);
                }
            }
            throw new Exception("Noget gik mystisk vist galt når den nye bruger blev lavet!");
        }
    }
}
