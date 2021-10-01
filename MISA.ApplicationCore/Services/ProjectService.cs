using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.Entity;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ServiceResponse _serviceResponse;

        public ProjectService(IBaseRepository<Project> baseRepository,
            IProjectRepository projectRepository) : base(baseRepository)
        {
            _projectRepository = projectRepository;
            _serviceResponse = new ServiceResponse();
        }

        /// <summary>
        /// Phương thức lấy danh sách dự án/nhóm trong 1 phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetByDepartment(Guid departmentId)
        {
            _serviceResponse.Data = _projectRepository.GetByDepartment(departmentId);

            if (_serviceResponse.Data != null)
            {
                _serviceResponse.MISACode = MISACode.IsValid;
            }
            else
            {
                var errorMsg = new
                {
                    devMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    userMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    Code = MISACode.NotValid
                };
                _serviceResponse.Data = errorMsg;
                _serviceResponse.Message = Entity.Properties.MessageErrorVN.messageErrorGet;
                _serviceResponse.MISACode = MISACode.NotValid;
            }
            return _serviceResponse;
        }
    }
}
