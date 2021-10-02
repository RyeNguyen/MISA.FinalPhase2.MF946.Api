using MISA.Entity.MISA.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity.MISA.Models
{
    public class Department : BaseEntity
    {
        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [MISARequired("Tên phòng ban")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Danh sách các nhóm/dự án trong phòng ban
        /// </summary>
        public List<Project> ProjectList { get; set; } = new List<Project>();

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id chủ sở hữu
        /// </summary>
        public Guid? UserId { get; set; }
    }
}
