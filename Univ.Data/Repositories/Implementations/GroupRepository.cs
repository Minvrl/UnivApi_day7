using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univ.Core.Entities;
using Univ.Data.Repositories.Interfaces;

namespace Univ.Data.Repositories.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {

        }
    }
}
