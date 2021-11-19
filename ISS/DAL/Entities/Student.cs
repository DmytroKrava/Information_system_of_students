using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class Student
    {
        public int StudentsID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
