using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Employee: AuditableEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        [DisplayName("Country")]
        public string CountryName { get; set; }


        [Required(ErrorMessage = "DOB is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [DisplayName("State")]
        public int StateId { get; set; }
        [DisplayName("State")]
        public string StateName { get; set; }
        [DisplayName("Status")]
        public List<EmployeeTask> EmployeeTask { get; set; }
        public bool IsActive { get; set; }  
    }
}
