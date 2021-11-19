using System;
using System.Collections.Generic;
using System.Text;
using Information_system_of_students.DAL.Entities;

namespace Information_system_of_students.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
        : IRepository<Student>
    {
    }
}