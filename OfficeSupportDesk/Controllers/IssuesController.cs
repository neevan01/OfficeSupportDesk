using System;
using System.Windows;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Dapper;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace OfficeSupportDesk.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssue _repo;
        private readonly IUser _repo2;
        public IssuesController(IIssue repo,IUser repo2)
        {
            this._repo = repo;
            this._repo2=repo2;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Issue issue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@category", issue.Category);
            param.Add("@subcategory", issue.SubCategory);
            param.Add("@state", issue.State);
            param.Add("@impact", issue.Impact);
            param.Add("@urgency", issue.Urgency);
            param.Add("@priority", issue.Priority);
            param.Add("@assign", issue.AssignedTo);
            param.Add("@issue", issue.Issues);            
            _repo.ExecuteAsync("sp_Issues_CreateToken", CommandType.StoredProcedure, param);
            return RedirectToAction("UserPage", "Users");
        }

        public JsonResult GetSubCategory()
        {
            DynamicParameters param = new DynamicParameters();            
            Task<IEnumerable<DomainModel.Issue>> issues = _repo.GetListAsync("sp_Issues_GetSubCategory", CommandType.StoredProcedure, param);
            List<DomainModel.Issue> us = issues.Result.ToList();
            return Json(us);
        }

        public JsonResult GetCategory()
        {
            DynamicParameters param = new DynamicParameters();
            Task<IEnumerable<DomainModel.Issue>> issues = _repo.GetListAsync("sp_Issues_GetCategory", CommandType.StoredProcedure, param);
            List<DomainModel.Issue> us = issues.Result.ToList();
            return Json(us);
        }
        
        public JsonResult GetAssignee()
        {
            DynamicParameters param = new DynamicParameters();
            Task<IEnumerable<DomainModel.User>> issues = _repo2.GetListAsync("sp_Issues_GetAssignee", CommandType.StoredProcedure, param);
            List<DomainModel.User> us = issues.Result.ToList();
            return Json(us);
        }
    }
}
