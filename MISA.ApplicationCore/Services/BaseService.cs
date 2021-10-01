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
                    devMsg = "Lỗi",
                    userMsg = "Lỗi",
                    Code = MISACode.NotValid
                };
                _serviceResponse.Data = errorMsg;
                _serviceResponse.Message = "Lỗi";
                _serviceResponse.MISACode = MISACode.NotValid;
            }
            return _serviceResponse;
        }
        #endregion

        public ServiceResponse GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Insert(MISAEntity entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse Update(Guid entityId, MISAEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
