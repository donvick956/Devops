using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Entity.Models
{
    public class Employee : IEmployee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [DisplayName("First Name*")]
        [StringLength(100, ErrorMessage = "Cannot be more than 100 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [MinLength(3, ErrorMessage = "First name should be at least 3 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name*")]
        [StringLength(100, ErrorMessage = "Cannot be more than 100 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [MinLength(3, ErrorMessage = "Last name should be at least 3 characters long.")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email*")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required]
        [DisplayName("House Number and Street Name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        public string HouseNoAndStreet { get; set; }

        [Required]
        [DisplayName("More Address*")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        public string MoreAddress { get; set; }

        [Required]
        [DisplayName("City*")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        public string City { get; set; }

        [Required]
        [DisplayName("State*")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        public string State { get; set; }

        [Required]
        [DisplayName("Date of birth*")]
        public DateTime DOB { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Next of Kin*")]
        public string NextOfKin { get; set; } // 1440000, 36000, 0

        [Required]
        [DisplayName("Next of Kin Phone number*")]
        public string NextOfKinPhone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Name*")]
        public string Reference1Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Occupation*")]
        public string Reference1Occupation { get; set; }

        [Required]       
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Place of Work*")]
        public string Reference1PlaceOfWork { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Phone Number*")]
        public string Reference1PhoneNumber { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email address")]
        [DisplayName("Email*")]
        public string Reference1Email { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Contact Address*")]
        public string Reference1Address { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid value")]
        [DisplayName("Relationship*")]
        public string Reference1Relationship { get; set; }



        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Name*")]
        public string Reference2Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid name")]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Occupation*")]
        public string Reference2Occupation { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Place of Work*")]
        public string Reference2PlaceOfWork { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Phone Number*")]
        public string Reference2PhoneNumber { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email address")]
        [DisplayName("Email*")]
        public string Reference2Email { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [DisplayName("Contact Address*")]
        public string Reference2Address { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Cannot be more than 40 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid value")]
        [DisplayName("Relationship*")]
        public string Reference2Relationship { get; set; }

        // [Required]
        //[DisplayName("Upload Passport")]
        //public byte[] Passport { get; set; }

        [Required]
        [DisplayName("Date of Employment*")]
        public DateTime DateOfEmployment { get; set; }

        [Required]
        [DisplayName("Date of Resumption*")]
        public DateTime DateOfResumption { get; set; }

        [Required]
        [DisplayName("Annual Gross Salary*")]
        public float AnnualGrossSalary { get; set; }

        [Required]
        [DisplayName("Health Insurance*")]
        public float HealthInsurance { get; set; }

      
        [DisplayName("Life Insurance")]
        public float LifeInsurance { get; set; }

        [Required]
        [DisplayName("Office Branch Address*")]
        public string OfficeBranchAddress { get; set; }

        [Required]
        [DisplayName("Staff Number*")]
        public string StaffNumber { get; set; }

        [Required]
        [DisplayName("Designation*")]
        public string Designation { get; set; }

        [Required]
        [DisplayName("Phone Number*")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Gender*")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Marital Status*")]
        public string MaritalStatus { get; set; }

        [Required]
        [DisplayName("Employment Type*")]
        public string EmploymentType { get; set; }


        [DisplayName("Contract Duration")]
        public string ContractDuration { get; set; }

        [Required]
        [DisplayName("Department*")]
        public string Department { get; set; }

        [Required]
        [DisplayName("Qualification*")]
        public string Qualification { get; set; }

        [Required]
        [DisplayName("Pension Staff Contribution?*")]
        public string PensionStaffContribution { get; set; }
        [Required]
        [DisplayName("Pension Employee Contribution?*")]
        public string PensionEmployeeContribution { get; set; }
    }
}