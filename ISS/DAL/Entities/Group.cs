using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int studentsQuantity { get; set; }
    }
}
