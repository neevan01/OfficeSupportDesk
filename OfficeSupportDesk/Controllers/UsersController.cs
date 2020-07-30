using System;
using System.Collections.Generic;
using DomainModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace OfficeSupportDesk.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _repo;
        public UsersController(IUser repo)
        {
            this._repo = repo;
        }

        //[Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult UserPage()
        {
            return View();
        }
        public JsonResult GetUserLists()
        {
            DynamicParameters param = new DynamicParameters();
            Task<IEnumerable<DomainModel.User>> users = _repo.GetListAsync("sp_Users_GetUsers", CommandType.StoredProcedure, param);
            List<DomainModel.User> us = users.Result.ToList();
            return Json(us);
        }
    }
}
