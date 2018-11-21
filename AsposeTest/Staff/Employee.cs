using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest.Staff
{
    public class Employee : StaffMember
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The Name of the Employee</param>
        /// <param name="joinDate">The Date when the Employee joined the company</param>
        /// <param name="baseSalary">The base Salary of the Employee</param>
        public Employee(string name, DateTime joinDate, long baseSalary)
            : base(name, joinDate, baseSalary)
        {

        }

        /// <summary>
        /// <see cref="StaffMember.Subordinates"/>
        /// </summary>
        public override List<StaffMember> Subordinates
        {
            get
            {
                return null;
            }
            set { }
        }

        /// <summary>
        /// <see cref="StaffMember.CurrentSalary"/>
        /// </summary>
        public override double CurrentSalary()
        {
            int yearsCount = YearsWorkedInTheCompany();
            return yearsCount < 10 ?
                (1 + yearsCount * 0.03) * BaseSalary : 1.3 * BaseSalary;
        }
    }
}
