using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.EF
{
    public class ScheduleContext
        : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ScheduleForGroup> Schedules { get; set; }

        public ScheduleContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}
