using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.Entity.MISA.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class TaskRepository : BaseRepository<MISATask>, ITaskRepository
    {
        public TaskRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Phương thức lấy danh sách công việc trong 1 nhóm/dự án
        /// </summary>
        /// <param name="ProjectId">ID nhóm/dự án</param>
        /// <returns>Danh sách công việc</returns>
        /// Author: NQMinh (01/10/2021)
        public List<MISATask> GetByProject(Guid ProjectId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                var storeName = "Proc_TaskGetByProject";

                parameters.Add("ProjectId", ProjectId);

                var entities = _dbConnection.Query<MISATask>(storeName, param: parameters, commandType: CommandType.StoredProcedure);

                return entities.ToList();
            }
        }
    }
}
