using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ thực thể
        /// </summary>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetAll();

        /// <summary>
        /// Lấy thông tin thực thể qua ID
        /// </summary>
        /// <param name="entityId">ID thực thể (khóa chính)</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetById(Guid entityId);

        /// <summary>
        /// Thêm thông tin thực thể vào DB
        /// </summary>
        /// <param name="entity">thông tin thực thể cần thêm</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entityId">ID thực thể (khóa chính)</param>
        /// <param name="entity">Thông tin mới</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse Update(Guid entityId, MISAEntity entity);
    }
}
