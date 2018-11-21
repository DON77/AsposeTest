using AsposeTest.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest
{
    /// <summary>
    /// Represents the Company
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Company()
        {
            BoardMembers = new List<StaffMember>();
        }

        /// <summary>
        /// The Board Members' list of the company
        /// </summary>
        public List<StaffMember> BoardMembers { get; set; }

        /// <summary>
        /// Calcullates the Summary of the company's staff members salaries 
        /// </summary>
        public double getSalariesSum()
        {
            return StaffMember
                .CalculateStaffMembersSalaryIncludingSubordinates(
                    BoardMembers
                );
        }
    }
}
