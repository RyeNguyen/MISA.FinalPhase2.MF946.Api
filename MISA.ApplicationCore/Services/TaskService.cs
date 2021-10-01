using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
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

        public ServiceResponse GetByProject(Guid ProjectId)
        {
            throw new NotImplementedException();
        }
    }
}
