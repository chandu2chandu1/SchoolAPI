using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Core.Domain
{
    public class School
    {

        public int Id { get; set; }

        [Required]
        public string Schoolname { get; set; }

        [Required]
        public string Address { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}