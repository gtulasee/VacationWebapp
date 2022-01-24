using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Domain.Enum;

namespace Vacation.Domain
{
    //Salaried Employee
    public class ManagerEmployee : Employee
    {
        private int _maxAllowedLeaves = 0;
        public override EmployeeTypes EmployeeType { get => EmployeeTypes.Manager; }

        public ManagerEmployee(int maxAllowedLeaves) :base(maxAllowedLeaves)
        {
            _maxAllowedLeaves = maxAllowedLeaves;
        }        
    }
}
