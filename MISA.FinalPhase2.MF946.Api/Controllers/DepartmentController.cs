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
    public class DepartmentsController : BaseEntityController<Department>
    {
        #region Declares
        private readonly IDepartmentService _departmentService;
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentsController(IDepartmentService departmentService,
            IDepartmentRepository departmentRepository) : base(departmentService, departmentRepository)
        {
            _departmentService = departmentService;
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức lọc dữ liệu phòng ban và các dự án trong phòng ban
        /// </summary>
        /// <param name="searchKeyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách phòng ban</returns>
        /// Author: NQMinh (02/10/2021)
        [HttpGet("search")]
        public IActionResult SearchData(string searchKeyword)
        {
            try
            {
                var entities = _departmentService.SearchData(searchKeyword);

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
        #endregion
    }
}
