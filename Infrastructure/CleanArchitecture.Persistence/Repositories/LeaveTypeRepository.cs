using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly CleanArchitectureDbContext _dbContext;

        public LeaveTypeRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
