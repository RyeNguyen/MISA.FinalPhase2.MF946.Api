using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        /// <summary>
        /// Lấy danh sách nhóm/dự án trong một phòng ban
        /// </summary>
        /// <param name="DepartmentId">ID phòng ban</param>
        /// <returns>Danh sách nhóm/dự án</returns>
        /// Author: NQMinh (01/10/2021)
        public List<Project> GetByDepartment(Guid DepartmentId);
    }
}
