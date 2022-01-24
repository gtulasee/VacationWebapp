using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationWebApp.Models
{
    public class WorkDayModel
    {
        public int EmployeeId { get; set; }

        [Range(0, 260, ErrorMessage = "WorkDays must be a positive number between 0 and 260")]
        public int WorkDays { get; set; }       
    }
}