using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repositories
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy danh sách thực thể
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Author: NQMinh (01/10/2021)
        public List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin thực thể qua ID
        /// </summary>
        /// <param name="entityId">ID thực thể</param>
        /// <returns>Thực thể cần lấy</returns>
        /// Author: NQMinh (01/10/2021)
        public MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm thông tin thực thể vào DB
        /// </summary>
        /// <param name="entity">Thông tin cần thêm</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author: NQMinh (01/10/2021)
        public int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entityId">ID thực thể cần sửa</param>
        /// <param name="entity">Thông tin mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author: NQMinh (01/10/2021)
        public int Update(Guid entityId, MISAEntity entity);

        /// <summary>
        /// Xóa thực thể khỏi DB
        /// </summary>
        /// <param name="entityIds">Danh sách ID của thực thể cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author: NQMinh (01/10/2021)
        public int Delete(List<Guid> entityIds);
    }
}
