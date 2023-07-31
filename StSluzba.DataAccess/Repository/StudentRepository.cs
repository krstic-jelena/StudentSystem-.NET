using StSluzba.DataAccess.Data;
using StSluzba.DataAccess.Repository.IRepository;
using StSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StSluzba.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(Student obj)
        {
            _db.Studenti.Update(obj);
        }
    }
}
