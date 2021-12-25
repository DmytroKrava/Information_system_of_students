using Catalog.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.BLL.DTO;
using Catalog.DAL.Repositories.Interfaces;
using AutoMapper;
using Catalog.DAL.UnitOfWork;
using ISS.Security;
using ISS.Security.Identity;

namespace Catalog.BLL.Services.Impl
{
    public class ScheduleForGroupService
        : IScheduleForGroupService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public ScheduleForGroupService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<ScheduleForGroupDTO> GetSchedule(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Student))
            {
                throw new MethodAccessException();
            }

            var groupId = user.GroupID;
            var scheduleforgroupEntities =
                _database
                    .Schedules
                    .Find(z => z.GroupID == groupId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<ScheduleForGroup, ScheduleForGroupDTO>()
                    ).CreateMapper();
            var schedulesDto =
                mapper
                    .Map<IEnumerable<ScheduleForGroup>, List<ScheduleForGroupDTO>>(
                        scheduleforgroupEntities);
            return schedulesDto;
        }

        public void AddScheduleForGroup(ScheduleForGroupDTO schedule)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Student))
            {
                throw new MethodAccessException();
            }
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            validate(schedule);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleForGroupDTO, ScheduleForGroup>()).CreateMapper();
            var scheduleEntity = mapper.Map<ScheduleForGroupDTO, ScheduleForGroup>(schedule);
            _database.Schedules.Create(scheduleEntity);
        }

        private void validate(ScheduleForGroupDTO schedule)
        {
            if (string.IsNullOrEmpty(schedule.Group))
            {
                throw new ArgumentException("Group повинне містити значення!");
            }
        }
    }
}
