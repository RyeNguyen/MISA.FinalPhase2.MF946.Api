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
    public class TasksController : BaseEntityController<MISATask>
    {
        #region Declares
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        #endregion

        #region Constructor
        public TasksController(ITaskService taskService,
            ITaskRepository taskRepository) : base(taskService, taskRepository)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
        }
        #endregion

        /// <summary>
        /// Phương thức lấy danh sách công việc trong 1 nhóm/dự án
        /// </summary>
        /// <param name="departmentId">ID nhóm/dự án</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        [HttpGet("byProject")]
        public IActionResult GetByProject(Guid projectId)
        {
            try
            {
                var entities = _taskService.GetByProject(projectId);

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
