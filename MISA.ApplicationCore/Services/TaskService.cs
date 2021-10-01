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
    public class TaskService : BaseService<MISATask>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ServiceResponse _serviceResponse;

        public TaskService(IBaseRepository<MISATask> baseRepository,
            ITaskRepository taskRepository) : base(baseRepository)
        {
            _taskRepository = taskRepository;
            _serviceResponse = new ServiceResponse();
        }

        /// <summary>
        /// Phương thức lấy danh sách công việc trong 1 nhóm/dự án
        /// </summary>
        /// <param name="projectId">ID nhóm/dự án</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetByProject(Guid projectId)
        {
            _serviceResponse.Data = _taskRepository.GetByProject(projectId);

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
