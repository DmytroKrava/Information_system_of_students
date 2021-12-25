using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.EF;
using System.Linq;

namespace Catalog.DAL.Repositories.Impl
{
    public class GroupRepository
        : BaseRepository<Group>, IGroupRepository
    {
        internal GroupRepository(ScheduleContext context)
            : base(context)
        {
        }
    }
}
