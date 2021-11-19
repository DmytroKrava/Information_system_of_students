using System;
using System.Collections.Generic;
using System.Text;

namespace Information_system_of_students.DAL.Entities
{
    public class Group
    {
        public int groupID { get; set; }
        public string Name { get; set; }
        public string educationalDegree { get; set; }
        public string speciality { get; set; }
        public IEnumerable<Student> students { get; set; }
    }
}
