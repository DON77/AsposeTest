using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsposeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsposeTest.Staff;

namespace AsposeTest.Tests
{
    [TestClass()]
    public class CompanyTests
    {
        [TestMethod()]
        public void CreateCompanyStaffTest()
        {
            Company company = new Company();
            StaffMember Employee1 = CompanyStaff.CreateMember(
                StaffMemberType.Emloyee,
                "Employee1",
                new DateTime(2017, 10, 1),
                100
            );
            StaffMember Employee2 = CompanyStaff.CreateMember(
                StaffMemberType.Emloyee,
                "Employee2",
                new DateTime(2000, 10, 1),
                100
            );
            StaffMember Manager1 = CompanyStaff.CreateMember(
                StaffMemberType.Manager, 
                "Manager1", 
                new DateTime(2017, 10, 1), 
                100,
                new List<StaffMember>() { Employee1, Employee2 }
            );
            StaffMember Manager2 = CompanyStaff.CreateMember(
                StaffMemberType.Manager,
                "Manager2",
                new DateTime(2000, 10, 1),
                100,
                new List<StaffMember>() { Manager1 }
            );
            StaffMember Employee3 = CompanyStaff.CreateMember(
                StaffMemberType.Emloyee,
                "Employee3",
                new DateTime(2017, 10, 1),
                100
            );
            StaffMember Manager3 = CompanyStaff.CreateMember(
               StaffMemberType.Manager,
               "Manager3",
               new DateTime(2017, 10, 1),
               100,
               new List<StaffMember>() { Employee3 }
            );
            StaffMember Sales1 = CompanyStaff.CreateMember(
               StaffMemberType.Sales,
               "Sales1",
               new DateTime(2017, 10, 1),
               100,
               new List<StaffMember>() { Manager2, Manager3 }
            );
            company.BoardMembers.Add(Sales1);
            Assert.AreEqual(Employee1.CurrentSalary(), 103);
            Assert.AreEqual(Employee2.CurrentSalary(), 130);
            Assert.AreEqual(Manager1.CurrentSalary(), 106.165);
            Assert.AreEqual(Manager2.CurrentSalary(), 140.530825);
            Assert.AreEqual(Employee3.CurrentSalary(), 103);
            Assert.AreEqual(Manager3.CurrentSalary(), 105.515);
            Assert.AreEqual(Sales1.CurrentSalary(), 103.064632475);
            Assert.AreEqual(Math.Round(company.getSalariesSum(), 9), 791.275457475);
        }
    }
}