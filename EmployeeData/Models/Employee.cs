using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDapper.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [StringLength(50)]
        public string EmploymentStatus { get; set; }
    }
}
