using CleanArchitecture.Application.Contratcs.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();  
            var mockLeaveTypeRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            mockUow.Setup(r => r.LeaveTypeRepository).Returns(mockLeaveTypeRepo.Object);
            return mockUow;
        }
    }
}
