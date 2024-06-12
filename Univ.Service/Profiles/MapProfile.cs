using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univ.Core.Entities;
using Univ.Service.Dtos;

namespace Univ.Service.Profiles
{
    public class MapProfile:Profile
    {
        private readonly IHttpContextAccessor _context;

        public MapProfile(IHttpContextAccessor httpContextAccessor)
        {

            _context = httpContextAccessor;

            var uriBuilder = new UriBuilder(_context.HttpContext.Request.Scheme, _context.HttpContext.Request.Host.Host, _context.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;

            CreateMap<Group, GroupGetDto>();
            CreateMap<GroupCreateDto, Group>();

            CreateMap<Student, StudentGetDto>()
                .ForMember(dest => dest.Age, s => s.MapFrom(s => DateTime.Now.Year - s.BirthDate.Year))
                .ForMember(dest => dest.ImageUrl, s => s.MapFrom(s => baseUrl + "uploads/students/" + s.FileName));
        }
    }
}
