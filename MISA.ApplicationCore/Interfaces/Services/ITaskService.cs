using MISA.ApplicationCore.Entities;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface ITaskService : IBaseService<MISATask>
    {
        /// <summary>
        /// Lấy danh sách công việc trong 1 nhóm/dự án
        /// </summary>
        /// <param name="ProjectId">ID nhóm/dự án</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetByProject(Guid ProjectId);
    }
}
