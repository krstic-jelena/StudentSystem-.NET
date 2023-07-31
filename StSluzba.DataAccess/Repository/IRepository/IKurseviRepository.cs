using StSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StSluzba.DataAccess.Repository.IRepository
{
    public interface IKurseviRepository : IRepository<Kursevi>
    {
        void Update(Kursevi obj);
      
    }
}
