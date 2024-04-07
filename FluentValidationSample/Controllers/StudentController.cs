using FluentValidationSample.Models.DTO;
using FluentValidationSample.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AkademiIstanbulContext _context;

        public StudentController(AkademiIstanbulContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            List<GetAllStudentsResponseDto> model = _context.Students.Where(x => x.IsDeleted == false).Select(q => new GetAllStudentsResponseDto(     
                q.ID,
                q.Name,
                q.Surname,
                q.Email,
                q.University.Name
            )).ToList();

            return Ok(model);
        }


        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestDto requestModel)
        {

            Student student = new Student();
            student.Name = requestModel.Name;
            student.Surname = requestModel.Surname;
            student.Email = requestModel.Email;
            student.Phone = requestModel.Phone;
            student.BirthDate = requestModel.BirthDate;

            _context.Students.Add(student);
            _context.SaveChanges();

           return Ok();
        }

        // api/student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentRequestDto model)
        {
            // oncelikle update edilecek ogrenciyi bulmamiz gerekiyor
            Student student = _context.Students.FirstOrDefault(q => q.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = model.Name;
            student.Surname = model.Surname;
            student.Email = model.Email;
            student.Phone = model.Phone;
            student.BirthDate = model.BirthDate;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = _context.Students.FirstOrDefault(q => q.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            student.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }


    }
}
