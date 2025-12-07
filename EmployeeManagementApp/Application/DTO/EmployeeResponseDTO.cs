namespace EmployeeManagementApp.Application.DTO
{
    public class EmployeeResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? GrossSalary { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
