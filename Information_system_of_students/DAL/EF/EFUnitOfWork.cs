using Information_system_of_students.DAL.Entities;
using Information_system_of_students.DAL.Repositories.Impl;
using Information_system_of_students.DAL.Repositories.Interfaces;
using Information_system_of_students.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace Information_system_of_students.DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private GroupContext db;
        private GroupRepository groupRepository;
        private StudentRepository studentRepository;

        public EFUnitOfWork(GroupContext context)
        {
            db = context;
        }
                
        IGroupRepository IUnitOfWork.Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }

        IStudentRepository IUnitOfWork.Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }
        }

        void IUnitOfWork.Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}