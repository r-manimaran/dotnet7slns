using AtlasMongoWithHealthChecks.Models;
using AtlasMongoWithHealthChecks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtlasMongoWithHealthChecks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await _studentService.GetStudent(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            await _studentService.CreateStudent(student);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(string id, Student student)
        {
            var existingStudent = await _studentService.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            await _studentService.UpdateStudent(id, student);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var existingStudent = await _studentService.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
