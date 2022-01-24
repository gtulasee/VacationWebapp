using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Domain.Interfaces;
using System.Configuration;
using System.Collections.Specialized;
using Vacation.Domain.Enum;

namespace Vacation.Domain.Factory
{
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeTypes type, NameValueCollection appSettings)
        {
            switch (type)
            {
                case EmployeeTypes.Contract:
                    return new ContractEmployee(int.Parse(appSettings["ContractEmployeeMaxVacation"]));
                case EmployeeTypes.Salaried:
                    return new SalariedEmployee(int.Parse(appSettings["SalariedEmployeeMaxVacation"]));
                case EmployeeTypes.Manager:
                    return new ManagerEmployee(int.Parse(appSettings["ManagerEmployeeMaxVacation"]));
                default:
                    return null;
            }
            
        }
    }
       
}
