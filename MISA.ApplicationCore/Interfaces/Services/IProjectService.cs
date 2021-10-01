using MISA.ApplicationCore.Entities;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IProjectService : IBaseService<Project>
    {
        /// <summary>
        /// Lấy danh sách nhóm/dự án trong 1 phòng ban
        /// </summary>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetByDepartment(Guid DepartmentId);
    }
}
