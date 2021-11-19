using System;
using System.Collections.Generic;
using System.Text;
using Information_system_of_students.DAL.Entities;
using Information_system_of_students.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Information_system_of_students.DAL.EF;
using System.Linq;

namespace Information_system_of_students.DAL.Repositories.Impl
{
    public class StudentRepository
        : BaseRepository<Student>, IStudentRepository
    {
        internal StudentRepository(GroupContext context)
            : base(context)
        {
        }
    }
}
