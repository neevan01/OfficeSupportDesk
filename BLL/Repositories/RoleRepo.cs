using BLL.Interfaces;
using DAL;
using DomainModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BLL.Repositories
{
    public class RoleRepo : DbConnection<Role>, IRole
    {
        private readonly IConfiguration _config;
        public RoleRepo(IConfiguration config) : base(config)
        {
            this._config = config;
        }
    }
}
