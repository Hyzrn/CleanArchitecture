using CleanArchitecture.Core.Domain;
using CleanArchitecture.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public class CleanArchitectureDbContext : AuditableDbContext
    {
        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureDbContext).Assembly);
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

    }
}
