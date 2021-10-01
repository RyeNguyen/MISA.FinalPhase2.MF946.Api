using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.Entity;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FinalPhase2.MF946.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectsController : BaseEntityController<Project>
    {
        #region Declares
        private readonly IProjectService _projectService;
        private readonly IProjectRepository _projectRepository;
        #endregion

        #region Constructor
        public ProjectsController(IProjectService projectService,
            IProjectRepository projectRepository) : base(projectService, projectRepository)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
        }
        #endregion

        /// <summary>
        /// Phương thức lấy danh sách nhóm/dự án trong 1 phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        [HttpGet("byDepartment")]
        public IActionResult GetByDepartment(Guid departmentId)
        {
            try
            {
                var entities = _projectService.GetByDepartment(departmentId);

                if (entities.Data != null)
                {
                    return Ok(entities.Data);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                var errorObj = new
                {
                    devMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    userMsg = Entity.Properties.MessageErrorVN.messageErrorGet,
                    Code = MISACode.NotValid
                };
                return BadRequest(errorObj);
            }
        }
    }
}
