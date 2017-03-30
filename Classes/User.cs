using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public User() { }

        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
