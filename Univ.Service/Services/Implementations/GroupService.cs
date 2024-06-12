using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Univ.Core.Entities;
using Univ.Data;
using Univ.Data.Repositories.Interfaces;
using Univ.Service.Dtos;
using Univ.Service.Exceptions;
using Univ.Service.Services.Interfaces;

namespace Univ.Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public int Create(GroupCreateDto createDto)
        {
            if (_groupRepository.Exists(x => x.No == createDto.No && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "No", "No already taken");

            Group entity = new Group
            {
                No = createDto.No,
                Limit = createDto.Limit,
            };
            _groupRepository.Add(entity);
            _groupRepository.Save();

            return entity.Id;
        }

        public void Delete(int id)
        {
            Group entity = _groupRepository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Group not found");

            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;
            _groupRepository.Save();
        }

        public List<GroupGetDto> GetAll(string? search = null)
        {
            Expression<Func<Group, bool>> predicate = x =>
                (search == null || x.No.Contains(search)) && !x.IsDeleted;

            return _groupRepository.GetAll(predicate, "Students")
                                    .Select(x => new GroupGetDto
                                    {
                                        Id = x.Id,
                                        No = x.No,
                                        Limit = x.Limit
                                    }).ToList();
        }

        public GroupGetDto GetById(int id)
        {
            Group entity = _groupRepository.Get(x => x.Id == id && !x.IsDeleted, includes: "Students");

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Group not found");

            return _mapper.Map<GroupGetDto>(entity);
        }


        public void Update(int id, GroupUpdateDto updateDto)
        {
            Group entity = _groupRepository.Get(x => x.Id == id && !x.IsDeleted, "Students");

            if (entity.No != updateDto.No && _groupRepository.Exists(x => x.No == updateDto.No && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "No", "No already taken");


            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Group not found");

            entity.No = updateDto.No;
            entity.Limit = updateDto.Limit;
            entity.ModifiedAt = DateTime.Now;

            _groupRepository.Save();

        }
    }
}
