using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Core.Domain
{
    public class Student
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SurName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public School School { get; set; }

    }
}