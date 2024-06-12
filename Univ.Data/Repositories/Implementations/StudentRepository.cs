using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univ.Core.Entities;
using Univ.Data.Repositories.Interfaces;

namespace Univ.Data.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
