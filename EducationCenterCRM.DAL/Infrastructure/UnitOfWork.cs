using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationCenterCRM.DAL.Infrastructure
{
    public class UnitOfWork :  IDisposable
    {
        private readonly DbContext context;
        public StudentsRepository studentsRepository{ get; private set; }
        public TeachersRepository teachersRepository { get; private set; }
        public GroupsRepository groupsRepository { get; private set; }



        public UnitOfWork(DbContext context)
        {
            this.context = context;
            studentsRepository = new StudentsRepository(context);
            teachersRepository = new TeachersRepository(context);
            groupsRepository = new GroupsRepository(context);

        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
