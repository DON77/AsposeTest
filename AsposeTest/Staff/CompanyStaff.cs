using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest.Staff
{
    /// <summary>
    /// Company Staff 
    /// Simplifies the staff members creation by providing a single interface
    /// </summary>
    public static class CompanyStaff
    {
        /// <summary>
        /// Creates a new staff member of given type
        /// </summary>
        /// <param name="staffMemberType">The type of the staff member</param>
        /// <param name="name">The Name of the Staff Member</param>
        /// <param name="joinDate">The Date when the member joined the company</param>
        /// <param name="baseSalary">The base Salary of the Staff member</param>
        /// <param name="subordinates">The Subordinates' list of the staff member</param>
        public static StaffMember CreateMember(
            StaffMemberType staffMemberType,
            string name,
            DateTime joinDate,
            long baseSalary,
            List<StaffMember> subordinates = null)
        {
            switch (staffMemberType)
            {
                case StaffMemberType.Emloyee:
                    return new Employee(name, joinDate, baseSalary);
                case StaffMemberType.Manager:
                    return new Manager(name, joinDate, baseSalary, subordinates);
                case StaffMemberType.Sales:
                    return new Sales(name, joinDate, baseSalary, subordinates);
                default:
                    return null;
            }
        }
    }
}
