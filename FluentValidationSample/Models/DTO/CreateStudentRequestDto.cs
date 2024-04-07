namespace FluentValidationSample.Models.DTO
{
    public record CreateStudentRequestDto
    (
        string Name,
        string Surname,
        string Email,
        string? Phone,
        DateTime? BirthDate
    );
}
