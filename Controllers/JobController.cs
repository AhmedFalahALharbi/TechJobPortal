using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class JobController : Controller
    {
        private static List<JobListing> _jobListings = new List<JobListing>
        {
            new JobListing 
            { 
                Id = 1, 
                Title = "Software Developer", 
                CompanyName = "Tech Solutions Inc.", 
                Location = "Ryiadh",
                JobType = JobType.FullTime,
                PostedDate = DateTime.Now.AddDays(-5)
            },
            new JobListing 
            { 
                Id = 2, 
                Title = "UX Designer", 
                CompanyName = "Creative Designs", 
                Location = "Medinah",
                JobType = JobType.Remote,
                PostedDate = DateTime.Now.AddDays(-3)
            },
            new JobListing 
            { 
                Id = 3, 
                Title = "Marketing Specialist", 
                CompanyName = "Growth Marketing", 
                Location = "Jeddah",
                JobType = JobType.PartTime,
                PostedDate = DateTime.Now.AddDays(-7)
            },
            new JobListing 
            { 
                Id = 4, 
                Title = "Data Analyst", 
                CompanyName = "Data Insights", 
                Location = "Remote",
                JobType = JobType.Contract,
                PostedDate = DateTime.Now.AddDays(-1)
            },
            new JobListing 
            { 
                Id = 5, 
                Title = "Project Manager", 
                CompanyName = "Project Solutions", 
                Location = "Islmabad",
                JobType = JobType.FullTime,
                PostedDate = DateTime.Now.AddDays(-10)
            }
        };

        public IActionResult Index()
        {
            return View(_jobListings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobListing jobListing)
        {
            if (ModelState.IsValid)
            {
                jobListing.Id = _jobListings.Count > 0 ? _jobListings.Max(j => j.Id) + 1 : 1;
                jobListing.PostedDate = DateTime.Now;
                
                _jobListings.Add(jobListing);
                return RedirectToAction(nameof(Index));
            }
            return View(jobListing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var jobListing = _jobListings.FirstOrDefault(j => j.Id == id);
            if (jobListing != null)
            {
                _jobListings.Remove(jobListing);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}