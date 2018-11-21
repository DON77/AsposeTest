using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest.Staff
{
    /// <summary>
    /// Sales
    /// </summary>
    public class Sales : StaffMember
    {
        private List<StaffMember> subordinates;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The Name of the Sales</param>
        /// <param name="joinDate">The Date when Sales joined the company</param>
        /// <param name="baseSalary">The base Salary of the Sales</param>
        /// <param name="subordinates">The Subordinates' list of the Sales</param>
        public Sales(
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
            double salary = yearsCount < 35 ?
                (1 + yearsCount * 0.01) * BaseSalary : 1.35 * BaseSalary;
            if (Subordinates != null)
            {
                salary +=
                    StaffMember.CalculateStaffMembersSalaryIncludingSubordinates
                    (
                        Subordinates
                    ) * 0.003;
            }
            return salary;
        }
    }
}
