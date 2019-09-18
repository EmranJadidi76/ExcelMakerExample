using ExcelCustomAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    // Use https://www.nuget.org/packages/ExcelCustomAttribute 
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "Employee FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "Employee LastName")]
        public string LastName { get; set; }
        [Display(Name = "Employee Gender")]
        [BooleanDisplay("Man","Woman")]
        public bool IsMale { get; set; }
        [Display(Name = "Employee Degree")]
        [EnumDisplay()]
        public Degree Degree { get; set; }
    }

    public enum Degree
    {
        [Display(Name = "Associate's degree")]
        Expert = 1,

        [Display(Name = "Doctoral degree")]
        Doctora = 2
    }
}
