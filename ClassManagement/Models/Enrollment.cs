using System;

namespace ClassManagement.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}