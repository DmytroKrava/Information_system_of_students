using System;
using Xunit;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestStreetRepository
        : BaseRepository<ScheduleForGroup>
    {
        public TestStreetRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ScheduleContext>()
                .Options;
            var mockContext = new Mock<ScheduleContext>(opt);
            var mockDbSet = new Mock<DbSet<ScheduleForGroup>>();
            mockContext
                .Setup(context =>
                    context.Set<ScheduleForGroup>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestStreetRepository(mockContext.Object);

            ScheduleForGroup expectedStreet = new Mock<ScheduleForGroup>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ScheduleContext>()
                .Options;
            var mockContext = new Mock<ScheduleContext>(opt);
            var mockDbSet = new Mock<DbSet<ScheduleForGroup>>();
            mockContext
                .Setup(context =>
                    context.Set<ScheduleForGroup>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestStreetRepository(mockContext.Object);

            ScheduleForGroup expectedStreet = new ScheduleForGroup() { ScheduleId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.ScheduleId)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.ScheduleId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.ScheduleId
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ScheduleContext>()
                .Options;
            var mockContext = new Mock<ScheduleContext>(opt);
            var mockDbSet = new Mock<DbSet<ScheduleForGroup>>();
            mockContext
                .Setup(context =>
                    context.Set<ScheduleForGroup>(
                        ))
                .Returns(mockDbSet.Object);

            ScheduleForGroup expectedStreet = new ScheduleForGroup() { ScheduleId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.ScheduleId))
                    .Returns(expectedStreet);
            var repository = new TestStreetRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.ScheduleId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.ScheduleId
                    ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }

    }
}