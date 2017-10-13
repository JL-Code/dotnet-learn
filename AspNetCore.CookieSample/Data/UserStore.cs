using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.CookieSample.Data
{
    public class UserStore
    {
        private static List<User> _users = new List<User>() {

            new User{Id=0,Name = "蒋勇",Password = "0"},
            new User{  Id = 1,Name="王林玲",Password="1"}
        };


        public User FindUser(int id)
        {
            return _users.Find(_ => _.Id == id);
        }

        public User FindUser(string name, string password)
        {
            return _users.FirstOrDefault(_ => _.Name == name && _.Password == password);
        }
    }
}
