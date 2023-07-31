using StSluzba.DataAccess.Data;
using StSluzba.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StSluzba.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public IKurseviRepository Kursevi{ get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
            Kursevi = new KurseviRepository(_db);
        }
       

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
