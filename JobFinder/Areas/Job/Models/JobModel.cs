using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JobFinder.Areas.Job.Models
{
    public class JobModel
    {
        public int JobID { get; set; }
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Requirements { get; set; }

        public string Location { get; set; }

        public string Salary { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
