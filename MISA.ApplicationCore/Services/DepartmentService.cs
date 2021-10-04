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
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ServiceResponse _serviceResponse;

        public DepartmentService(IBaseRepository<Department> baseRepository,
            IDepartmentRepository departmentRepository) : base(baseRepository)
        {
            _departmentRepository = departmentRepository;
            _serviceResponse = new ServiceResponse();
        }

        /// <summary>
        /// Phương thức lọc dữ liệu phòng ban và các dự án trong phòng ban
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách phòng ban</returns>
        /// Author: NQMinh (02/10/2021)
        public ServiceResponse SearchData(string searchKeyword)
        {
            var departmentList = _departmentRepository.SearchData<Department>(searchKeyword);

            if (departmentList != null)
            {
                departmentList = departmentList.GroupBy(i => i.DepartmentId).Select(i => i.First()).ToList();
                var projectList = _departmentRepository.SearchData<Project>(searchKeyword);

                if (projectList != null)
                {
                    foreach (var department in departmentList)
                    {
                        foreach (var project in projectList)
                        {
                            if (department.DepartmentId == project.DepartmentId)
                            {
                                if (project.ProjectName != null)
                                {
                                    department.ProjectList.Add(project);
                                }
                            }
                        }
                    }
                }

                _serviceResponse.MISACode = MISACode.IsValid;
                _serviceResponse.Data = departmentList;
            }
            else
            {
                var errorMsg = new
                {
                    devMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    userMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    Code = MISACode.NotValid
                };
                _serviceResponse.Data = null;
                _serviceResponse.MISACode = MISACode.NotValid;
                _serviceResponse.Message = Entity.Properties.MessageErrorVN.messageErrorGet;
            }

            return _serviceResponse;
        }
    }
}
