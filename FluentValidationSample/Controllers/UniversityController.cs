using FluentValidationSample.Models.DTO;
using FluentValidationSample.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        AkademiIstanbulContext _context;
        
        public UniversityController(AkademiIstanbulContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllUniversitiesResponseDto> universities = _context.Universities
                .Where(x => !x.IsDeleted)
                .Select(q => new GetAllUniversitiesResponseDto(
                    q.Name,
                    q.City
                ))
                .ToList();

            return Ok(universities);
        }

        [HttpPost]
        public IActionResult Add(CreateUniversityRequestDto model)
        {
            University university = new University();
            university.Name = model.Name;
            university.City = model.City;

            _context.Universities.Add(university);
            _context.SaveChanges();

            return Ok(model);
        }
    }
}
