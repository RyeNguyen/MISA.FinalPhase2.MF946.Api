using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Declares
        private readonly IBaseRepository<MISAEntity> _baseRepository;
        private readonly ServiceResponse _serviceResponse;
        private readonly string _className;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResponse = new ServiceResponse();
            _className = typeof(MISAEntity).Name;

            if (_className == "MISATask")
            {
                _className = "Task";
            }
        }
        #endregion

        #region Lấy danh sách thực thể từ DB
        /// <summary>
        /// Lấy danh sách thực thể từ DB
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetAll()
        {
            _serviceResponse.Data = _baseRepository.GetAll();

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
        #endregion

        #region Lấy thông tin thực thể qua ID
        /// <summary>
        /// Lấy thông tin thực thể qua ID
        /// </summary>
        /// <param name="entityId">ID thực thể</param>
        /// <returns>Thông tin thực thể cần lấy</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse GetById(Guid entityId)
        {
            _serviceResponse.Data = _baseRepository.GetById(entityId);

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
                _serviceResponse.Data = null;
                _serviceResponse.MISACode = MISACode.NotValid;
                _serviceResponse.Message = Entity.Properties.MessageErrorVN.messageErrorGet;
            }

            return _serviceResponse;
        }
        #endregion

        #region Thêm mới thực thể vào cơ sở dữ liệu
        /// <summary>
        /// Thêm mới thực thể vào cơ sở dữ liệu
        /// </summary>
        /// <param name="entity">Thông tin thực thể cần thêm</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse Insert(MISAEntity entity)
        {
            var rowAffects = _baseRepository.Insert(entity);
            _serviceResponse.Data = rowAffects;
            _serviceResponse.Message = Entity.Properties.MessageSuccessVN.messageSuccessInsert;
            _serviceResponse.MISACode = MISACode.IsValid;
            return _serviceResponse;
        }
        #endregion

        #region Cập nhật thông tin thực thể
        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entityId">ID thực thể cần sửa</param>
        /// <param name="entity">Thông tin mới</param>
        /// <returns>Phản hồi tương ứng</returns>
        /// Author: NQMinh (01/10/2021)
        public ServiceResponse Update(Guid entityId, MISAEntity entity)
        {
            var rowAffects = _baseRepository.Update(entityId, entity);
            _serviceResponse.Data = rowAffects;
            _serviceResponse.Message = Entity.Properties.MessageSuccessVN.messageSuccessUpdate;
            _serviceResponse.MISACode = MISACode.IsValid;
            return _serviceResponse;
        }
        #endregion
    }
}
