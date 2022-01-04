using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DelonUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tax = GetAnnualTax(1404000);
            //var tax = GetAnnualTax(668736.00);
            //  var tax = GetAnnualTax(600000, 20000, 20000, 20000, 20000, 20000);// 500k - 43k
            //var tax = GetAnnualTax(400000,20000, 20000, 20000, 20000, 20000); // 300k - 21k
            Assert.AreEqual((Math.Round(tax, 2)), 102480.00);
        }
        public double GetAnnualTax(double annualTaxableIncome)
        {
            int share = 300000;
            int consolidatedRelief = 200000;
            double calculatedTaxableIncome = 0d;
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
        //public double GetAnnualTaxableIncome(double basicSalary,double housing, double transportAllowance, double leaveAllowance,double mealAndEntertainment, double utility)
        //{

        //    return (basicSalary + housing + transportAllowance + leaveAllowance + mealAndEntertainment + utility);
        //}
        //public double GetAnnualTax(double basicSalary, double housing, double transportAllowance, double leaveAllowance, double mealAndEntertainment, double utility)       
        //{      
        //    double annualTaxableIncome = GetAnnualTaxableIncome(basicSalary,housing, transportAllowance, leaveAllowance, mealAndEntertainment, utility);  

        //    int share = 300000;
        //    int consolidatedRelief = 200000;
        //    double calculatedTaxableIncome = 0d;
        //    annualTaxableIncome = annualTaxableIncome - consolidatedRelief;

        //    if (annualTaxableIncome < share) return calculatedTaxableIncome;

        //    if (annualTaxableIncome >= share)
        //    {
        //        annualTaxableIncome -= share;
        //        calculatedTaxableIncome += (share * 0.07);
        //    }

        //    if (annualTaxableIncome == 0) return calculatedTaxableIncome;
        //    else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
        //    {
        //        annualTaxableIncome -= share;
        //        calculatedTaxableIncome += (share * 0.11);
        //    }
        //    else
        //    {
        //        calculatedTaxableIncome += (annualTaxableIncome * 0.11);
        //        return calculatedTaxableIncome;
        //    }

        //    share = 500000;

        //    if (annualTaxableIncome == 0) return calculatedTaxableIncome;
        //    else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
        //    {
        //        annualTaxableIncome -= share;
        //        calculatedTaxableIncome += (share * 0.15);
        //    }
        //    else
        //    {
        //        calculatedTaxableIncome += (annualTaxableIncome * 0.15);
        //        return calculatedTaxableIncome;
        //    }

        //    if (annualTaxableIncome == 0) return calculatedTaxableIncome;
        //    else if (annualTaxableIncome > 0 && annualTaxableIncome >= share)
        //    {
        //        annualTaxableIncome -= share;
        //        calculatedTaxableIncome += (share * 0.19);
        //    }
        //    else
        //    {
        //        calculatedTaxableIncome += (annualTaxableIncome * 0.19);
        //        return calculatedTaxableIncome;
        //    }

        //    share = 1600000;

        //    if (annualTaxableIncome == 0) return calculatedTaxableIncome;
        //    else if (annualTaxableIncome > 0 && annualTaxableIncome < share)
        //    {
        //        calculatedTaxableIncome += (annualTaxableIncome * 0.21);
        //        return calculatedTaxableIncome;
        //    }
        //    else
        //    {
        //        annualTaxableIncome -= share;
        //        calculatedTaxableIncome += (share * 0.21);
        //    }

        //    if (annualTaxableIncome == 0) return calculatedTaxableIncome;
        //    else calculatedTaxableIncome += (annualTaxableIncome * 0.24);

        //    return calculatedTaxableIncome;
        //}
    }
}
