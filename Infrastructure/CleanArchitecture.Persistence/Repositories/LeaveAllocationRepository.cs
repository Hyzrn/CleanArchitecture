using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly CleanArchitectureDbContext _dbContext;

        public LeaveAllocationRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _dbContext.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId
                                    && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                 .Include(x => x.LeaveType)
                 .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leaveAllocation;
        }
    }
}
