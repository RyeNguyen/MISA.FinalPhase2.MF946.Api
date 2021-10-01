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
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Phương thức lấy danh sách nhóm/dự án trong 1 phòng ban
        /// </summary>
        /// <param name="DepartmentId">ID phòng ban</param>
        /// <returns>Danh sách nhóm/dự án</returns>
        /// Author: NQMinh (01/10/2021)
        public List<Project> GetByDepartment(Guid DepartmentId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                var storeName = "Proc_ProjectGetByDepartment";

                parameters.Add("DepartmentId", DepartmentId);

                var entities = _dbConnection.Query<Project>(storeName, param: parameters, commandType: CommandType.StoredProcedure);

                return entities.ToList();
            }
        }
    }
}
