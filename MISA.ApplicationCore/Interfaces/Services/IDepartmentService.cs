using MISA.ApplicationCore.Entities;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IDepartmentService : IBaseService<Department>
    {
        /// <summary>
        /// Phương thức lọc dữ liệu phòng ban và các dự án trong phòng ban
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (02/10/2021)
        public ServiceResponse SearchData(string searchKeyword);
    }
}
