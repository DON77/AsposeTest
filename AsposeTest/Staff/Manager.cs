using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest.Staff
{
    /// <summary>
    /// Manager
    /// </summary>
    public class Manager : StaffMember
    {
        private List<StaffMember> subordinates;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The Name of the Manager</param>
        /// <param name="joinDate">The Date when the Manager joined the company</param>
        /// <param name="baseSalary">The base Salary of the Manager</param>
        /// <param name="subordinates">The Subordinates' list of the Manager</param>
        public Manager(
            string name,
            DateTime joinDate,
            long baseSalary,
            List<StaffMember> subordinates = null)
            : base(name, joinDate, baseSalary, subordinates)
        {

        }

        /// <summary>
        /// <see cref="StaffMember.Subordinates"/>
        /// </summary>
        public override List<StaffMember> Subordinates
        {
            get
            {
                return subordinates;
            }
            set
            {
                subordinates = value;
            }
        }

        /// <summary>
        /// <see cref="StaffMember.CurrentSalary"/>
        /// </summary>
        public override double CurrentSalary()
        {
            int yearsCount = YearsWorkedInTheCompany();
            double salary = yearsCount < 8 ?
                (1 + yearsCount * 0.05) * BaseSalary : 1.4 * BaseSalary;
            if (Subordinates != null)
            {
                foreach (StaffMember subordinate in Subordinates)
                {
                    salary += 0.005 * subordinate.CurrentSalary();
                }
            }
            return salary;
        }
    }
}
