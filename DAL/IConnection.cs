using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConnection<T>:IDisposable where T:class
    {
        IDbConnection GetDbConnection();
        Task<T> GetFirstAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null);
        Task<IEnumerable<T>> GetListAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null);
        Task<IEnumerable<T>> FilterAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null);
        //Deals with both Add and Delete
        Task ExecuteAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null);
        Task<int> DeleteAsyncReturn(string sqlQuery, CommandType type, DynamicParameters parameters = null);
        Task UpdatteAsync(string sqlQuery, CommandType type, DynamicParameters parameters = null);        
        
    }
}
