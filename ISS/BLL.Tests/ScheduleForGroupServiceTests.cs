using Catalog.BLL.Services.Impl;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using ISS.Security;
using ISS.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class ScheduleForGroupServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ScheduleForGroupService(nullUnitOfWork));
        }

        [Fact]
        public void GetSchedule_UserIsCurator_ThrowMethodAccessException()
        {
            User user = new Curator(1, "Andre", 1, "Boyarskiy");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IScheduleForGroupService scheduleForGroupService = new ScheduleForGroupService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => scheduleForGroupService.GetSchedule(0));
        }

        [Fact]
        public void GetSchedule_ScheduleForGroupFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Student(1, "Michail", 1, "Zubenko");
            SecurityContext.SetUser(user);
            var scheduleForGroupService = GetScheduleForGroupService();

            // Act
            var actualScheduleForGroupDto = scheduleForGroupService.GetSchedule(0).First();

            // Assert
            Assert.True(
                actualScheduleForGroupDto.ScheduleId == 1
                && actualScheduleForGroupDto.Group == "TestG"
                && actualScheduleForGroupDto.Description == "testD"
                );
        }

        IScheduleForGroupService GetScheduleForGroupService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedSchedule = new ScheduleForGroup() { ScheduleId = 1, Group = "TestG", Description = "testD", GroupID = 2};
            var mockDbSet = new Mock<IScheduleForGroupRepository>();
            
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<ScheduleForGroup, bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<ScheduleForGroup>() { expectedSchedule }
                    );

            mockContext
                .Setup(context =>
                    context.Schedules)
                .Returns(mockDbSet.Object);

            IScheduleForGroupService scheduleForGroupService = new ScheduleForGroupService(mockContext.Object);

            return scheduleForGroupService;
        }
    }
}
