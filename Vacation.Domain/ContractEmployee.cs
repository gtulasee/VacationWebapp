using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Domain.Enum;
using Vacation.Domain.Interfaces;

namespace Vacation.Domain
{
    public class ContractEmployee : Employee,IEmployeeAdditional
    {
        private   int _maxAllowedLeaves = 0;
        public override EmployeeTypes EmployeeType { get => EmployeeTypes.Contract; }
        public ContractEmployee(int maxAllowedLeaves) :base(maxAllowedLeaves)
        {
            _maxAllowedLeaves = maxAllowedLeaves;
        }

        // If a new function needs to be added like leaves
        // calculation differnt from others, Then Declare the same in IEmployeeAdditional
        // and implement here 
    }
}
