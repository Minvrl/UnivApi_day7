using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Univ.Data;
using Univ.Service.Dtos;
using Univ.Service.Services.Implementations;
using Univ.Service.Services.Interfaces;

namespace Univ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService, AppDbContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        [HttpPost("")]
        public ActionResult Create([FromForm] StudentCreateDto createDto)
        {
            return StatusCode(201, new { Id = _studentService.Create(createDto) });
        }

        [HttpGet("")]
        public ActionResult<List<GroupGetDto>> GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] StudentUpdateDto updateDto)
        {
            _studentService.Update(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<GroupGetDto> GetById(int id)
        {
            return StatusCode(200, _studentService.GetById(id));
        }

    }
}
