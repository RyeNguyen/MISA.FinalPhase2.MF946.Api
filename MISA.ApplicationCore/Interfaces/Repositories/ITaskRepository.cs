using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repositories
{
    public interface ITaskRepository : IBaseRepository<MISATask>
    {
        /// <summary>
        /// Lấy danh sách công việc trong một nhóm/dự án
        /// </summary>
        /// <param name="ProjectId">ID nhóm/dự án</param>
        /// <returns>Danh sách công việc</returns>
        /// Author: NQMinh (01/10/2021)
        public List<MISATask> GetByProject(Guid ProjectId);
    }
}
