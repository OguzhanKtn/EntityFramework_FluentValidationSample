namespace FluentValidationSample.Models.DTO
{
    public record UpdateStudentRequestDto
    (
        string Name,
        string Surname,
        string Email,
        string? Phone,
        DateTime? BirthDate
    );
}
