using BLL.Interfaces;
using DAL;
using DomainModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    public class UserRepo:DbConnection<User>,IUser
    {
        private readonly IConfiguration _config;
        public UserRepo(IConfiguration config) : base(config)
        {
            this._config = config;
        }
    }
}
