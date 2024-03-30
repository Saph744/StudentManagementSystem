using Microsoft.AspNetCore.Mvc;
using schoolmanagement.Service.Student;
using schoolmanagement.Service.ViewModel;

namespace schoolmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IStudentService studentService, IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost(nameof(InsertStudent))]
        public async Task<IActionResult> InsertStudent(StudentViewModel studentViewModel)
        {
            string result = await _studentService.InsertStudentAsync(studentViewModel);
            if (result != null)
            {

                return Ok(result);
            }
            return BadRequest(new { result = "Unable to insert data" });
        }
        [HttpGet(nameof(GetAllStudent))]
        public async Task<IActionResult> GetAllStudent()
        {
            var result = await _studentService.GellAllStudentAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetStudent))]
        public async Task<IActionResult> GetStudent(int StudentID)
        {
            var result = await _studentService.GetStudentAsync(StudentID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateStudent))]
        public async Task<IActionResult> UpdateStudent(StudentViewModel studentViewModel)
        {
            var student = await _studentService.UpdateStudentAsync(studentViewModel);
            return Ok(student);
        }


        [HttpDelete(nameof(DeleteStudent))]
        public async Task<IActionResult> DeleteStudent(int StudentID)
        {
            var studentDelete = await _studentService.DeleteStudentAsync(StudentID);
            return Ok(studentDelete);
        }
    }
}
