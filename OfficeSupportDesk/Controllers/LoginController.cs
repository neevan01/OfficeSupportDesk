using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeSupportDesk.Controllers
{
    public class LoginController : Controller
    {
        //private readonly IUser _repo;

        public IActionResult Index()
        {
            return View();
        }

        //public JsonResult GetUserLists()
        //{

        //    DynamicParameters param = new DynamicParameters();
        //    Task<IEnumerable<DomainModel.User>> users = _repo.GetListAsync("sp_Users_GetUsers", CommandType.StoredProcedure, param);
        //    List<DomainModel.User> us = users.Result.ToList();
        //    return Json(us);
        //}

        public JsonResult LoginUser(string uname, string pw)
        {            
            string msg = string.Empty;
            if (uname == "admin" && pw == "admin")
            {
                
                msg = "1";
            }
            else
            {
                msg = "0";
            }
          
            return Json(msg);
            
        }
    }
}
