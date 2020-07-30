using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbConnection<T> : IConnection<T> where T : class
    {
        private readonly IConfiguration _config;
        public DbConnection(IConfiguration config)
        {
            this._config = config;
        }
        public async Task<int> DeleteAsyncReturn(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            using var con = GetDbConnection();
            con.Open();
            return await SqlMapper.QueryFirstOrDefaultAsync<int>(con, sqlQuery, parameters, commandType: type);
        }

        public void Dispose()
        {
            GetDbConnection().Close();
        }

        public async Task ExecuteAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            using var con = GetDbConnection();
            con.Open();
            var tasks = await con.ExecuteAsync(sqlQuery, parameters, commandType: type);
        }

        public Task<IEnumerable<T>> FilterAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            //not implemented
            throw new NotImplementedException();
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DbCon"));
        }

        public async Task<T> GetFirstAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            using var con = GetDbConnection();
            con.Open();
            return await SqlMapper.QueryFirstOrDefaultAsync<T>(con, sqlQuery, parameters, commandType: type);
        }

        public async Task<IEnumerable<T>> GetListAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            using var con = GetDbConnection();
            con.Open();
            return await SqlMapper.QueryAsync<T>(con, sqlQuery, parameters, commandType: type);
        }
        //not implemented here
        public Task UpdatteAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
