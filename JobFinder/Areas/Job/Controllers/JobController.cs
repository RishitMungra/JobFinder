using Microsoft.AspNetCore.Mvc;
using JobFinder.Areas.Job.Models;
using JobFinder.DAL.Job;
using System.Data;

namespace JobFinder.Areas.Job.Controllers
{
    [Area("Job")]
    [Route("Job/[controller]/[action]")]
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        JobDAL JobDAL = new JobDAL();

        #region Job List
        public IActionResult JobList()
        {
            DataTable dataTable = JobDAL.JobSelectAll();
            return View(dataTable);
        }
        #endregion

        #region Job Add Edit
        public IActionResult JobAdd(int JobID)
        {
            JobModel JobModel = JobDAL.JobByID(JobID);
            if (JobModel != null)
            {
                return View("JobAddEdit", JobModel);
            }
            else
            {
                return View("JobAddEdit");
            }
        }
        #endregion

        #region Job Save
        public IActionResult JobSave(JobModel JobModel)
        {
            //if (ModelState.IsValid)
            //{
                if (JobDAL.JobSave(JobModel))
                {
                    TempData["SuccessMessage"] = "Data Added Successfully.";
                    return RedirectToAction("JobList");
                }
            //}
            return View("JobAddEdit");
        }
        #endregion

        #region Job Delete
        public IActionResult JobDelete(int JobID)
        {
            bool isSuccess = JobDAL.JobDelete(JobID);
            if (isSuccess)
            {
                return RedirectToAction("JobList");
            }
            return RedirectToAction("JobList");
        }
        #endregion

        #region Job List (User Side)
        public IActionResult FindJob()
        {
            DataTable dataTable = JobDAL.JobSelectAll();
            return View(dataTable);
        }
        #endregion

        #region About (User Side)
        public IActionResult About()
        {
            DataTable dataTable = JobDAL.JobSelectAll();
            return View(dataTable);
        }
        #endregion

        #region Job List By ID (User Side)
        public IActionResult FindJobByID(int JobID)
        {
            DataTable dataTable = JobDAL.FindJobByID(JobID);
            return View(dataTable);
        }
        #endregion
    }
}
