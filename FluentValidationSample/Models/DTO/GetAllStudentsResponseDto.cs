namespace FluentValidationSample.Models.DTO
{
    public record GetAllStudentsResponseDto
    (
         int ID,
         string Name,
         string Surname, 
         string Email,
         string UniversityName
    );
}
