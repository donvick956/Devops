using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Service.Interfaces
{
    public interface IHRServices
    {
        double GetAnnualLeave(int employeeId);
        double GetAnnualNetSalaryAfterTax(int employeeId);
        double GetAnnualNetSalaryBeforeTaxes(int employeeId);
        double GetAnnualTax(int employeeId);
        double GetAnnualTaxableIncome(int employeeId);
        double GetBasicSalary(int employeeId);
        double GetHousing(int employeeId);
        double GetMealAndEntertainment(int employeeId);
        double GetMonthlyNetSalaryAfterTax(int employeeId);
        double GetMonthlyPAYE(int employeeId);
        double GetMonthlyTaxableIncome(int employeeId);
        double GetNetSalaryBeforeTaxesAndPensionEmployerContribution(int employeeId);
        double GetPensionEmployerContribution(int employeeId);
        double GetPensionStaffContribution(int employeeId);
        double GetPerformanceBasedBonus(int employeeId);
        double GetTransport(int employeeId);
        double GetUtility(int employeeId);
        void SendOfferLetter(int employeeId);
        double GetAnnualSalaryBeforeTaxForDevs(int employeeId);
        //double GetAnnualSalaryBeforeTaxForRegular(int employeeId);
        double GetAnnualWithholdingTax(int employeeId);
        double GetMonthlyWithholdingTax(int employeeId);
    }
}