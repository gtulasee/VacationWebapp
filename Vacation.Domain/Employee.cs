using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Domain.Enum;
using Vacation.Domain.Interfaces;

namespace Vacation.Domain
{
    public abstract class Employee : IEmployee
    {
        private readonly int _maxAllowedLeaves = 0;
        private  int _workDays = 0;

        public Employee(int maxAllowedLeaves)
        {
            _maxAllowedLeaves = maxAllowedLeaves;
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int WorkingDays { get => _workDays; set => _workDays=value; }
        public float AvailedVacationDays { get; set; }
        public float LeaveBalances { get => AccumulatedLeaves-AvailedVacationDays; }
        //Total Leaves can be used based on WorkingDays
        public float AccumulatedLeaves  {get => UpdateAccumulatedLeaves(_workDays);}

        public int MaxAllowedVacationDays { get => _maxAllowedLeaves; }

        public virtual EmployeeTypes EmployeeType { get;}

        public bool TakeVacation(float vacationDurationInDays)
        {
            var totalAvailed = AvailedVacationDays + vacationDurationInDays;
            if(totalAvailed<= AccumulatedLeaves)
            {
                AvailedVacationDays = totalAvailed;
                return true;
            }
            else
            {
                //throw exception - Cannot avail more than accumlated
                return false;
            }
        }
        public float UpdateAccumulatedLeaves(int workdays)
        {
            WorkingDays = workdays;
            return  ((float)MaxAllowedVacationDays* (float)WorkingDays)/ 260;
        }
    }
}
