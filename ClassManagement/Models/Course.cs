using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassManagement.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Range(0,5)]
        public int CreditLoad { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}