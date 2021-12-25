using System;
using System.Collections.Generic;
using System.Text;

namespace ISS.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, string surname, int groupid, string userType)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            GroupID = groupid;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public string Surname { get; }
        public int GroupID { get; }
        protected string UserType { get; }
    }
}
