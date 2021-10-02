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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Phương thức lọc dữ liệu phòng ban và các dự án trong phòng ban
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách phòng ban</returns>
        /// Author: NQMinh (02/10/2021)
        public List<MISAEntity> SearchData<MISAEntity>(string searchKeyword)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@SearchKeyword", searchKeyword ?? string.Empty);

                var storeName = "Proc_SearchDepartmentProject";
                var data = _dbConnection.Query<MISAEntity>(storeName, param: parameters, commandType: CommandType.StoredProcedure);

                return data.ToList();
            }
        }
    }
}
