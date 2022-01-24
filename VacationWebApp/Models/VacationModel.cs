using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationWebApp.Models
{    public class VacationModel
    {
        public int EmployeeId { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "vacation must be a positive number")]
        public float VacationDays { get; set; }
    }

}