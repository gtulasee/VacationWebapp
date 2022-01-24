using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vacation.Domain;
using System.Configuration;
using Vacation.Domain.Interfaces;
using Vacation.Domain.Factory;
using System.Collections.Specialized;
using Vacation.Domain.Enum;

namespace VacationWebApp.DataContext
{
    public class EmployeeDataContext
    {
        // For storing employees instead of retrieving from DB
        private static List<IEmployee> _employees = null;
        public List<IEmployee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new List<IEmployee>();


                    //Prepopulate data
                    AddEmployee(EmployeeTypes.Contract,1000,"John");
                    AddEmployee(EmployeeTypes.Contract, 1001, "Jack");
                    AddEmployee(EmployeeTypes.Contract, 1002, "Stella");
                    AddEmployee(EmployeeTypes.Contract, 1003, "Park");
                    AddEmployee(EmployeeTypes.Contract, 1004, "Reers");
                    AddEmployee(EmployeeTypes.Contract, 1005, "Daniel");
                    AddEmployee(EmployeeTypes.Contract, 1006, "Bonnie");
                    AddEmployee(EmployeeTypes.Contract, 1007, "Stephen");
                    AddEmployee(EmployeeTypes.Contract, 1008, "Marry");
                    AddEmployee(EmployeeTypes.Contract, 1009, "Thomas");
                    
                    AddEmployee(EmployeeTypes.Salaried, 2000, "Jose");
                    AddEmployee(EmployeeTypes.Salaried, 2001, "Robert");
                    AddEmployee(EmployeeTypes.Salaried, 2002, "Chris");
                    AddEmployee(EmployeeTypes.Salaried, 2003, "Matthews");
                    AddEmployee(EmployeeTypes.Salaried, 2004, "Amar");
                    AddEmployee(EmployeeTypes.Salaried, 2005, "Cristopher");
                    AddEmployee(EmployeeTypes.Salaried, 2006, "Danielle");
                    AddEmployee(EmployeeTypes.Salaried, 2007, "Joseph");
                    AddEmployee(EmployeeTypes.Salaried, 2008, "Paul");
                    AddEmployee(EmployeeTypes.Salaried, 2009, "Jam");


                    AddEmployee(EmployeeTypes.Manager, 3000, "Alexa");
                    AddEmployee(EmployeeTypes.Manager, 3001, "Dennis");
                    AddEmployee(EmployeeTypes.Manager, 3002, "Scott");
                    AddEmployee(EmployeeTypes.Manager, 3003, "Mark");
                    AddEmployee(EmployeeTypes.Manager, 3004, "Joel");
                    AddEmployee(EmployeeTypes.Manager, 3005, "Bob");
                    AddEmployee(EmployeeTypes.Manager, 3006, "Shawn");
                    AddEmployee(EmployeeTypes.Manager, 3007, "Johnson");
                    AddEmployee(EmployeeTypes.Manager, 3008, "Jonardhan");
                    AddEmployee(EmployeeTypes.Manager, 3009, "Jakky");


                }
                return _employees;
            }
            set => _employees = value;
        }
        public void AddEmployee(EmployeeTypes employeeType,int employeeId,String employeeName)
        {
            IEmployee employee = EmployeeFactory
                                            .GetEmployeeInstance(employeeType, ConfigurationManager.AppSettings);
            employee.EmployeeId = employeeId; employee.EmployeeName = employeeName;

            _employees.Add(employee);
        }
        public List<IEmployee> GetEmployees()
        {
            return Employees;
        }
        public IEmployee GetEmployee(int id)
        {
            return GetEmployees().FirstOrDefault(P => P.EmployeeId == id);
        }
    }
}