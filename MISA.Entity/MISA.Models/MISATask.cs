using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity.MISA.Models
{
    public class MISATask : BaseEntity
    {
        /// <summary>
        /// Id công việc
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Tên công việc
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id người được giao việc
        /// </summary>
        public Guid AssigneeId { get; set; }

        /// <summary>
        /// Id nhóm/dự án
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Id người giao việc
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Hạn hoàn thành
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Tiến độ
        /// </summary>
        public int? Progress { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int? TaskStatus { get; set; }
    }
}
