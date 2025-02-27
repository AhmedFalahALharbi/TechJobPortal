using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public enum JobType
    {
        [Display(Name = "Full-time")]
        FullTime,
        
        [Display(Name = "Part-time")]
        PartTime,
        
        [Display(Name = "Remote")]
        Remote,
        
        [Display(Name = "Contract")]
        Contract
    }

    public class JobListing
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Job title is required")]
        [Display(Name = "Job Title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Company name is required")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Location")]
        public string Location { get; set; }
        
        [Display(Name = "Job Type")]
        public JobType JobType { get; set; }
        
        [Display(Name = "Posted Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}