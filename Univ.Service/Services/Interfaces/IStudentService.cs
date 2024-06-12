using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univ.Service.Dtos;

namespace Univ.Service.Services.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto createDto);
        void Update(int id, StudentUpdateDto updateDto);
        StudentGetDto GetById(int id);
        List<StudentGetDto> GetAll(string? search = null);
        void Delete(int id);
    }
}
