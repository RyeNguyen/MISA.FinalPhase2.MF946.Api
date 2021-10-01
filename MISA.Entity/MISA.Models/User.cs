using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entity.MISA.Models
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Ảnh đại diện
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Màu nền ảnh đại diện
        /// </summary>
        public string AvatarColor { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string JobPositionName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Tên cơ cấu tổ chức
        /// </summary>
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// Tên vai trò
        /// </summary>
        public string RoleName { get; set; }
    }
}
