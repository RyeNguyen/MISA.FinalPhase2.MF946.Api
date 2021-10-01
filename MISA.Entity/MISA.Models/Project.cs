using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity.MISA.Models
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// Id nhóm/dự án
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Tên nhóm/dự án
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Tên icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Màu icon
        /// </summary>
        public string IconColor { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? ProjectStatus { get; set; }
    }
}
