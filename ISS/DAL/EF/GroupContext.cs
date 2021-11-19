using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;

namespace Catalog.DAL.EF
{
    public class GroupContext
        : DbContext
    {
        public DbSet<Group> Ciphres { get; set; }
        public DbSet<Student> Surnames { get; set; }
        public GroupContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
