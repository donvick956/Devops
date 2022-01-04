using DelonBoard.Entity.Models;
using DelonBoard.Service.EmailService;
using DelonBoard.Service.EmailService.Services;
using DelonBoard.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Service.Implementations
{
    public class HRServices : IHRServices
    {
        private readonly IMailService _mailer;
        private readonly IEmployeeService _employeeContext;

        #region Constructor
        public HRServices(IEmployeeService employee, IMailService mailer)
        {
            _mailer = mailer;
            _employeeContext = employee;
        }
        #endregion

        #region Methods
        public void SendOfferLetter(int employeeId)
        {
            Employee employee = _employeeContext.GetByIdAsync(employeeId);
            
            if (employee != null)
            {
                var meassage = new StringBuilder();
                meassage.Append($"Dear {employee.FirstName} {employee.LastName}\n\nCongratulations!\n\nSequel to your interview with us, you have been offered employment as a {employee.Designation}. " +
                    "Please find attached your offer letter.\n\nPlease confirm acceptance or otherwise within the next 48 hours.\n\nSincerely yours\n\nHead of HR\nDelonJobs");
                MailRequest mailDetails = new MailRequest();
                mailDetails.Recipient = employee.Email;
                mailDetails.Content = meassage.ToString();
                mailDetails.Subject = "OFFER OF EMPLOYMENT";
                if (employee.EmploymentType == "Full-Time")
                {                    
                    mailDetails.PlaceHolders = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("{{DATE}}", Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"))),
                        new KeyValuePair<string, string>("{{STREET NUMBER AND STREET NAME}}", employee.HouseNoAndStreet),
                        new KeyValuePair<string, string>("{{MORE ADDRESS}}", employee.MoreAddress),
                        new KeyValuePair<string, string>("{{CITY, STATE}}", $"{employee.City} {employee.State}"),
                        new KeyValuePair<string, string>("{{FIRST NAME}}", employee.FirstName),
                        new KeyValuePair<string, string>("{{LAST NAME}}", employee.LastName),
                        new KeyValuePair<string, string>("{{JOB TYPE}}", employee.EmploymentType),
                        new KeyValuePair<string, string>("{{LINE MANAGER}}", _employeeContext.LineManager),
                        new KeyValuePair<string, string>("{{RESUMPTION DATE}}", employee.DateOfResumption.ToString("d")),
                        new KeyValuePair<string, string>("{{BRANCH OFFICE ADDRESS}}", employee.OfficeBranchAddress),
                        new KeyValuePair<string, string>("{{STAFF NUMBER}}", employee.StaffNumber.ToString()),
                        new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", employee.AnnualGrossSalary.ToString()),
                        new KeyValuePair<string, string>("{{OFFICE HOURS}}", _employeeContext.HoursOfWork),
                        new KeyValuePair<string, string>("{{WORK DAYS}}", _employeeContext.WorkDays),
                        new KeyValuePair<string, string>("{{FIRST NAME  LAST NAME}}", $"{employee.FirstName} {employee.LastName}"),
                        new KeyValuePair<string, string>("{{DESIGNATION}}", employee.Designation),
                        new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", employee.AnnualGrossSalary.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HEALTH INSURANCE}}", employee.HealthInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{LIFE INSURANCE}}", employee.LifeInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PERFORMANCE-BASED BONUS}}", GetPerformanceBasedBonus(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PENSION STAFF CONTRIBUTION}}", GetPensionStaffContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY BEFORE TAXES}}", GetAnnualNetSalaryBeforeTaxes(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PENSION EMPLOYER CONTRIBUTION}}", GetPensionEmployerContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET PENSION}}", GetNetSalaryBeforeTaxesAndPensionEmployerContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{BASIC SALARY}}", GetBasicSalary(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HOUSING}}", GetHousing(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{TRANSPORT}}", GetTransport(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL LEAVE}}", GetAnnualLeave(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MEAL AND ENTERTAINMENT}}", GetMealAndEntertainment(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{UTILITY}}", GetUtility(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL TAXABLE INCOME}}", GetAnnualTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY TAXABLE INCOME}}", GetMonthlyTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL TAX}}", GetAnnualTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY PAYE}}", GetMonthlyPAYE(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY AFTER TAX}}", GetAnnualNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY NET SALARY AFTER TAX}}", GetMonthlyNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00"))
                    };
                } else if (employee.EmploymentType == "Regular Contract")
                {
                    mailDetails.PlaceHolders = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("{{DATE}}", Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"))),
                        new KeyValuePair<string, string>("{{STREET NUMBER AND STREET NAME}}", employee.HouseNoAndStreet),
                        new KeyValuePair<string, string>("{{MORE ADDRESS}}", employee.MoreAddress),
                        new KeyValuePair<string, string>("{{CITY, STATE}}",  $"{employee.City} {employee.State}"),
                        new KeyValuePair<string, string>("{{FIRST NAME}}", employee.FirstName),
                        new KeyValuePair<string, string>("{{LAST NAME}}", employee.LastName),
                        new KeyValuePair<string, string>("{{JOB TYPE}}", employee.EmploymentType),
                        new KeyValuePair<string, string>("{{CONTRACT DURATION}}", employee.ContractDuration),
                        new KeyValuePair<string, string>("{{LINE MANAGER}}", _employeeContext.LineManager),
                        new KeyValuePair<string, string>("{{RESUMPTION DATE}}", employee.DateOfResumption.ToString("d")),
                        new KeyValuePair<string, string>("{{BRANCH OFFICE ADDRESS}}", employee.OfficeBranchAddress),
                        new KeyValuePair<string, string>("{{STAFF NUMBER}}", employee.StaffNumber.ToString()),
                        new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", employee.AnnualGrossSalary.ToString()),
                        new KeyValuePair<string, string>("{{OFFICE HOURS}}", _employeeContext.HoursOfWork),
                        new KeyValuePair<string, string>("{{WORK DAYS}}", _employeeContext.WorkDays),
                        new KeyValuePair<string, string>("{{FIRST NAME  LAST NAME}}", $"{employee.FirstName} {employee.LastName}"),
                        new KeyValuePair<string, string>("{{DESIGNATION}}", employee.Designation),
                        new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", employee.AnnualGrossSalary.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HEALTH INSURANCE}}", employee.HealthInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{LIFE INSURANCE}}", employee.LifeInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PERFORMANCE-BASED BONUS}}", GetPerformanceBasedBonus(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PENSION STAFF CONTRIBUTION}}", GetPensionStaffContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY BEFORE TAXES}}", GetAnnualNetSalaryBeforeTaxes(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{PENSION EMPLOYER CONTRIBUTION}}", GetPensionEmployerContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET PENSION}}", GetNetSalaryBeforeTaxesAndPensionEmployerContribution(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{BASIC SALARY}}", GetBasicSalary(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HOUSING}}", GetHousing(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{TRANSPORT}}", GetTransport(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL LEAVE}}", GetAnnualLeave(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MEAL AND ENTERTAINMENT}}", GetMealAndEntertainment(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{UTILITY}}", GetUtility(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL TAXABLE INCOME}}", GetAnnualTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY TAXABLE INCOME}}", GetMonthlyTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL TAX}}", GetAnnualTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY PAYE}}", GetMonthlyPAYE(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY AFTER TAX}}", GetAnnualNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY NET SALARY AFTER TAX}}", GetMonthlyNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00"))
                    };
                } else
                {
                    mailDetails.PlaceHolders = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("{{DATE}}", Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"))),
                        new KeyValuePair<string, string>("{{STREET NUMBER AND STREET NAME}}", employee.HouseNoAndStreet),
                        new KeyValuePair<string, string>("{{MORE ADDRESS}}", employee.MoreAddress),
                        new KeyValuePair<string, string>("{{CITY, STATE}}", $"{employee.City} {employee.State}"),
                        new KeyValuePair<string, string>("{{FIRST NAME}}", employee.FirstName),
                        new KeyValuePair<string, string>("{{LAST NAME}}", employee.LastName),
                        new KeyValuePair<string, string>("{{JOB TYPE}}", employee.EmploymentType),
                        new KeyValuePair<string, string>("{{CONTRACT DURATION}}", employee.ContractDuration),
                        new KeyValuePair<string, string>("{{LINE MANAGER}}", _employeeContext.LineManager),
                        new KeyValuePair<string, string>("{{RESUMPTION DATE}}", employee.DateOfResumption.ToString("d")),
                        new KeyValuePair<string, string>("{{BRANCH OFFICE ADDRESS}}", employee.OfficeBranchAddress),
                        new KeyValuePair<string, string>("{{STAFF NUMBER}}", employee.StaffNumber.ToString()),
                        new KeyValuePair<string, string>("{{OFFICE HOURS}}", _employeeContext.HoursOfWork),
                        new KeyValuePair<string, string>("{{WORK DAYS}}", _employeeContext.WorkDays),
                        new KeyValuePair<string, string>("{{FIRST NAME  LAST NAME}}", $"{employee.FirstName} {employee.LastName}"),
                        new KeyValuePair<string, string>("{{DESIGNATION}}", employee.Designation),
                        new KeyValuePair<string, string>("{{ANNUAL GROSS SALARY}}", employee.AnnualGrossSalary.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HEALTH INSURANCE}}", employee.HealthInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{LIFE INSURANCE}}", employee.LifeInsurance.ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY BEFORE TAXES}}", GetAnnualSalaryBeforeTaxForDevs(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{BASIC SALARY}}", GetBasicSalary(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{HOUSING}}", GetHousing(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{TRANSPORT}}", GetTransport(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL LEAVE}}", GetAnnualLeave(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MEAL AND ENTERTAINMENT}}", GetMealAndEntertainment(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{UTILITY}}", GetUtility(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL TAXABLE INCOME}}", GetAnnualTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY TAXABLE INCOME}}", GetMonthlyTaxableIncome(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL WITHHOLDING TAX}}", GetAnnualWithholdingTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY WITHHOLDING TAX}}", GetMonthlyWithholdingTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{ANNUAL NET SALARY AFTER TAX}}", GetAnnualNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00")),
                        new KeyValuePair<string, string>("{{MONTHLY NET SALARY AFTER TAX}}", GetMonthlyNetSalaryAfterTax(employee.EmployeeID).ToString("#,##0.00"))
                    };
                }
                
                _mailer.SendEmailAsync(mailDetails, employee.EmploymentType);
            }
        }

        public double GetPerformanceBasedBonus(int employeeId)
        {
            Employee employee = _employeeContext.GetByIdAsync(employeeId);
            return employee.AnnualGrossSalary * 0.25;
        }

        #region Optional Fields
        public double GetPensionStaffContribution(int employeeId)
        {
            double value = 0d;
            Employee employee = _employeeContext.GetByIdAsync(employeeId);

            if(employee.PensionStaffContribution == "Yes")
            {
                value = employee.AnnualGrossSalary * 0.08;
            }
            return value;            
        }

        public double GetPensionEmployerContribution(int employeeId)
        {
            double value = 0d;
            Employee employee = _employeeContext.GetByIdAsync(employeeId);

            if (employee.PensionEmployeeContribution == "Yes")
            {
                value = employee.AnnualGrossSalary * 0.1;
            }
            return value;
        }
        #endregion

        public double GetAnnualNetSalaryBeforeTaxes(int employeeId)
        {
            Employee employee = _employeeContext.GetByIdAsync(employeeId);
            #region New Additions
            var pensionContribution = 0d;
            if (employee.PensionStaffContribution == "Yes")
            {
                pensionContribution = GetPensionStaffContribution(employeeId);
            }
            #endregion
            return employee.AnnualGrossSalary - employee.HealthInsurance - employee.LifeInsurance - GetPerformanceBasedBonus(employeeId) - pensionContribution;
        }  

        public double GetNetSalaryBeforeTaxesAndPensionEmployerContribution(int employeeId)
        {
            #region New Additions
            //Employee employee = _employeeContext.GetByIdAsync(employeeId);
            //var pensionEmployerContribution = 0d;
            //if (employee.PensionEmployeeContribution == "Yes")
            //{
            //    pensionEmployerContribution = GetPensionEmployerContribution(employeeId);
            //}
            #endregion
            return GetAnnualNetSalaryBeforeTaxes(employeeId) + GetPensionEmployerContribution(employeeId);
        }

        public double GetBasicSalary(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.32;

        public double GetHousing(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.23;

        public double GetTransport(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.15;

        public double GetAnnualLeave(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.19;

        public double GetMealAndEntertainment(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.06;

        public double GetUtility(int employeeId) => GetAnnualNetSalaryBeforeTaxes(employeeId) * 0.05;

        public double GetAnnualTaxableIncome(int employeeId) => GetBasicSalary(employeeId) + GetHousing(employeeId) + GetTransport(employeeId) + GetAnnualLeave(employeeId) + GetMealAndEntertainment(employeeId) + GetUtility(employeeId);

        public double GetMonthlyTaxableIncome(int employeeId) => GetAnnualTaxableIncome(employeeId) / 12;

        public double GetAnnualTax(int employeeId) // 1,440000, 36000, 0
        {
            int share = 300000;
            double calculatedTaxableIncome = 0d;
            const int consolidatedRelief = 200000;
            double annualTaxableIncome = GetAnnualTaxableIncome(employeeId);
            double percentageDeduction = 0.2 * annualTaxableIncome;
            annualTaxableIncome = annualTaxableIncome - consolidatedRelief - percentageDeduction;

            if (annualTaxableIncome < share) return calculatedTaxableIncome;

            if (annualTaxableIncome >= share)
            {
                annualTaxableIncome -= share;
                calculatedTaxableIncome += (share * 0.07);
            }

            if (annualTaxableIncome == 0) return calculatedTaxableIncome;
            else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
            {
                annualTaxableIncome -= share;
                calculatedTaxableIncome += (share * 0.11);
            }
            else
            {
                calculatedTaxableIncome += (annualTaxableIncome * 0.11);
                return calculatedTaxableIncome;
            }

            share = 500000;

            if (annualTaxableIncome == 0) return calculatedTaxableIncome;
            else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
            {
                annualTaxableIncome -= share;
                calculatedTaxableIncome += (share * 0.15);
            }
            else
            {
                calculatedTaxableIncome += (annualTaxableIncome * 0.15);
                return calculatedTaxableIncome;
            }

            if (annualTaxableIncome == 0) return calculatedTaxableIncome;
            else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
            {
                annualTaxableIncome -= share;
                calculatedTaxableIncome += (share * 0.19);
            }
            else
            {
                calculatedTaxableIncome += (annualTaxableIncome * 0.19);
                return calculatedTaxableIncome;
            }

            share = 1600000;

            if (annualTaxableIncome == 0) return calculatedTaxableIncome;
            else if (annualTaxableIncome > 0 && annualTaxableIncome < share)
            {
                calculatedTaxableIncome += (annualTaxableIncome * 0.21);
                return calculatedTaxableIncome;
            }
            else
            {
                annualTaxableIncome -= share;
                calculatedTaxableIncome += (share * 0.21);
            }

            if (annualTaxableIncome == 0) return calculatedTaxableIncome;
            else calculatedTaxableIncome += (annualTaxableIncome * 0.24);

            return calculatedTaxableIncome;
        }

        public double GetMonthlyPAYE(int employeeId) => GetAnnualTax(employeeId) / 12;

        public double GetAnnualNetSalaryAfterTax(int employeeId) => GetAnnualTaxableIncome(employeeId) - GetAnnualTax(employeeId);

        public double GetMonthlyNetSalaryAfterTax(int employeeId) => (GetAnnualNetSalaryAfterTax(employeeId) / 12);
                      
        public double GetAnnualSalaryBeforeTaxForDevs(int employeeId)
        {
            Employee employee = _employeeContext.GetByIdAsync(employeeId);
            return employee.AnnualGrossSalary - employee.HealthInsurance - employee.LifeInsurance;
        }

        //public double GetAnnualSalaryBeforeTaxForRegular(int employeeId)
        //{
        //    Employee employee = _employeeContext.GetByIdAsync(employeeId);
        //    double performanceBonus = GetPerformanceBasedBonus(employeeId);
        //    return employee.AnnualGrossSalary - employee.HealthInsurance - employee.LifeInsurance - performanceBonus;
        //}

        public double GetAnnualWithholdingTax(int employeeId)
        {
            var threshhold = 360000;
            double annualTaxable = GetAnnualTaxableIncome(employeeId);
            if(annualTaxable <= threshhold)
            {
                return 0;
            }
            return Math.Round((annualTaxable * 0.05), 2);
        }
        
        public double GetMonthlyWithholdingTax(int employeeId) => Math.Round((GetAnnualWithholdingTax(employeeId) / 12), 2);
        #endregion
    }
}