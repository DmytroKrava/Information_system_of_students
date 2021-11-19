using Information_system_of_students.DAL.Entities;
using Information_system_of_students.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Information_system_of_students.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepository Groups { get; }
        IStudentRepository Students { get; }
        void Save();
    }
}
