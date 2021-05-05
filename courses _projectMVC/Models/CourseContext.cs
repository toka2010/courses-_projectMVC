using System;
using System.Data.Entity;
using System.Linq;

namespace courses__projectMVC.Models
{
    public class CourseContext : DbContext
    {
        
        public CourseContext()
            : base("name=CourseContext")
        {
        }

        public virtual  DbSet<User> Users { get; set; }
        public virtual DbSet<ContactUs> Contacts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Reservation> Reservations{ get; set; }
    }

    
}