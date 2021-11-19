using System;
using System.Collections.Generic;
using System.Text;
using Information_system_of_students.DAL.Entities;
using Information_system_of_students.DAL.Repositories.Interfaces;
using Information_system_of_students.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Information_system_of_students.DAL.Repositories.Impl
{
    public class GroupRepository
        : BaseRepository<Group>, IGroupRepository
    {

        internal GroupRepository(GroupContext context)
            : base(context)
        {
        }
    }
}