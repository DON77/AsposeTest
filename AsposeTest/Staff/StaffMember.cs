using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest.Staff
{
    /// <summary>
    /// Staff Member
    /// Represents the base class,contains the shared logic for all staff members
    /// </summary>
    public abstract class StaffMember
    {
        /// <summary>
        /// The Name of the Staff Member
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Date when the member joined the company
        /// </summary>
        public DateTime JoinedDate { get; set; }

        /// <summary>
        /// The base Salary of the Staff member
        /// </summary>
        public long BaseSalary { get; set; }

        /// <summary>
        /// The Subordinates' list of the staff member
        /// </summary>
        public abstract List<StaffMember> Subordinates { get; set; }

        /// <summary>
        /// Calculates the number of years the staff member worked with the company
        /// </summary>
        protected int YearsWorkedInTheCompany()
        {
            return (DateTime.Now - JoinedDate).Days / 365;
        }

        /// <summary>
        /// Returns the current salary of the member
        /// </summary>
        public abstract double CurrentSalary();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The Name of the Staff Member</param>
        /// <param name="joinDate">The Date when the member joined the company</param>
        /// <param name="baseSalary">The base Salary of the Staff member</param>
        /// <param name="subordinates">The Subordinates' list of the staff member</param>
        public StaffMember(
            string name,
            DateTime joinDate,
            long baseSalary,
            List<StaffMember> subordinates = null)
        {
            this.Name = name;
            this.JoinedDate = joinDate;
            this.BaseSalary = baseSalary;
            this.Subordinates = subordinates;
        }

        /// <summary>
        /// Calculate the summary of all the staff members provided in 
        /// the list including the salaries of their subordinates
        /// </summary>
        /// <param name="staffMembers">The list of staff members</param>
        /// <returns>The salaries summary</returns>
        public static double CalculateStaffMembersSalaryIncludingSubordinates(
            List<StaffMember> staffMembers)
        {
            double sum = 0;
            foreach (StaffMember staffMember in staffMembers)
            {
                sum += staffMember.CurrentSalary();
                if (staffMember.Subordinates != null)
                {
                    sum += CalculateStaffMembersSalaryIncludingSubordinates(
                        staffMember.Subordinates
                    );
                }
            }
            return sum;
        }
    }
}
