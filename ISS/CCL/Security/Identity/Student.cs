using System;
using System.Collections.Generic;
using System.Text;

namespace ISS.Security.Identity
{
    public class Student
        : User
    {
        public Student(int userId, string name, int groupID, string surname) 
            : base(userId, name, surname, groupID, nameof(Student))
        {
        }
    }
}
