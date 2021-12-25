using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class ScheduleForGroup
    {
        public int ScheduleId { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public int GroupID { get; set; }
    }
}
