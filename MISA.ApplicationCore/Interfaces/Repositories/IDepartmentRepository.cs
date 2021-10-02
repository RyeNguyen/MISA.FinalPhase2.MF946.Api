using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        /// <summary>
        /// Phương thức lọc dữ liệu phòng ban và các dự án trong phòng ban
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách phòng ban</returns>
        /// Author: NQMinh (02/10/2021)
        public List<MISAEntity> SearchData<MISAEntity>(string searchKeyword);
    }
}
