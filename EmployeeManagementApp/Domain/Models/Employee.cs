using EmployeeManagementApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementApp.Domain.Models
{
    public class Employee : BaseEntity
    {
        #region Basic Data
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string PersonalNumber { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public EducationLevel EducationLevel { get; set; }
        #endregion


        #region Secondary Data
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string? PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = null!;

        public DateTime? HireDate { get; set; }
        public decimal? GrossSalary { get; set; }
        #endregion



    }
}
