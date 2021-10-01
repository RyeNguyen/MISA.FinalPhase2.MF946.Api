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

        public ServiceResponse GetByDepartment(Guid DepartmentId)
        {
            throw new NotImplementedException();
        }
    }
}
