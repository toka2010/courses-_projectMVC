using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace courses__projectMVC.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Coursedescription { get; set; }
        [Required]
        public string WhatCourseLearn1 { get; set; }
        public string WhatCourseLearn2 { get; set; }
        public string WhatCourseLearn3 { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int NofArticles { get; set; }
        [Required]
        public int NofHoures { get; set; }
        [Required]
        public string image{ get; set; }
        [NotMapped]
        public string courseErrorMsg { get; set; }

    }
}