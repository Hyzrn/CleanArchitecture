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
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly CleanArchitectureDbContext _dbContext;

        public LeaveRequestRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                 .Include(x => x.LeaveType)
                 .ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                 .Include(x => x.LeaveType)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return leaveRequest;
        }
    }
}
