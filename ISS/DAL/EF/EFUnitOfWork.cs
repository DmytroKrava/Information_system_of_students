using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalog.DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private ScheduleContext db;
        private StudentRepository studentRepository;
        private ScheduleForGroupRepository scheduleForGroupRepository;

        public EFUnitOfWork(ScheduleContext context)
        {
            db = context;
        }
        public IStudentRepository Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }
        }

        public IScheduleForGroupRepository Schedules
        {
            get
            {
                if (scheduleForGroupRepository == null)
                    scheduleForGroupRepository = new ScheduleForGroupRepository(db);
                return scheduleForGroupRepository;
            }
        }

        public void Save()
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
