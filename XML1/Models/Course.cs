using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XML1.Models
{
    public enum CourseTypeEnum
    {
        FullTime,
        PartTime
    }

    public class Course
    {
        [Display(Name = "Course Code")]
        [Required]        
        public string CourseCode { get; set; }
        [Required]
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        [Required]
        [Display(Name = "Course Type")]
        public CourseTypeEnum CourseType { get; set; }
        [Required]
        [Display(Name = "Credits")]
        public int CourseCredits { get; set; }
        [Required]
        [Display(Name = "Validation Date")]        
        [Range(2000,2019)]
        public int CourseValidationDate { get; set; }

    }
}