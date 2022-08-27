﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contratcs.Persistence;
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

        public UnitOfWork(CleanArchitectureDbContext context)
        {
            _context = context;
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
            await _context.SaveChangesAsync();
        }
    }
}
