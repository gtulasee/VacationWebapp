using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Domain.Enum;
using Vacation.Domain.Factory;

namespace Vacation.Domain.Interfaces
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        EmployeeTypes EmployeeType { get ;}
        string EmployeeName { get; set; }
        int WorkingDays { get; set; }
        float AvailedVacationDays { get; set; }
        float LeaveBalances { get; }
        float AccumulatedLeaves { get; }
        int MaxAllowedVacationDays { get; }
        bool TakeVacation(float vacationDurationInDays);
        float UpdateAccumulatedLeaves(int workdays);
    }
}
