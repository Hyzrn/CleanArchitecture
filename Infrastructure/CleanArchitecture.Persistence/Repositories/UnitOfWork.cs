using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contratcs.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanArchitectureDbContext _context;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private ILeaveTypeRepository _leaveTypeRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(CleanArchitectureDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public ILeaveAllocationRepository LeaveAllocationRepository => 
            _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);
        public ILeaveRequestRepository LeaveRequestRepository => 
            _leaveRequestRepository ??= new LeaveRequestRepository(_context);
        public ILeaveTypeRepository LeaveTypeRepository => 
            _leaveTypeRepository ??= new LeaveTypeRepository(_context);

        public void Dispose()   
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync(username);
        }
    }
}
