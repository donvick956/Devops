using System;

namespace DelonBoard.Entity.Models
{
    public interface IEmployee
    {
        float AnnualGrossSalary { get; set; }
        string ContractDuration { get; set; }
        DateTime DateOfEmployment { get; set; }
        DateTime DateOfResumption { get; set; }
        string Department { get; set; }
        string Designation { get; set; }
        DateTime DOB { get; set; }
        string Email { get; set; }
        int EmployeeID { get; set; }
        string EmploymentType { get; set; }
        string FirstName { get; set; }
        string Gender { get; set; }
        float HealthInsurance { get; set; }
        string LastName { get; set; }
        float LifeInsurance { get; set; }
        string MaritalStatus { get; set; }
        string NextOfKin { get; set; }
        string NextOfKinPhone { get; set; }
        string OfficeBranchAddress { get; set; }
        string PhoneNumber { get; set; }
        string Qualification { get; set; }
        string StaffNumber { get; set; }
        public string HouseNoAndStreet { get; set; }
        public string MoreAddress { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
    }
}