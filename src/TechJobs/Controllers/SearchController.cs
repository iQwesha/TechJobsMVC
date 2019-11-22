using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {

        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();
        private static object columnChoice;
        private static dynamic jobs;

        static SearchController()
        {

            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }


        public IActionResult Index()
        {
            ViewBag.columns = SearchController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
             ViewBag.columns = SearchController.columnChoices;
            
            if (searchType.Equals("all"))
            {

                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);


            }
           

            return View("Index");

        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}

