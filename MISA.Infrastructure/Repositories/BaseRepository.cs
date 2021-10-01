﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Declares
        protected readonly string _connectionString;
        protected IDbConnection _dbConnection;
        protected IConfiguration _configuration;
        private readonly string _className;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MisaFinal");
            _className = typeof(MISAEntity).Name;
        }
        #endregion

        #region Methods
        #region Phương thức lấy tất cả dữ liệu thực thể
        /// <summary>
        /// Lấy toàn bộ danh sách thực thể từ DB
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Author: NQMinh(01/10/2021)
        public List<MISAEntity> GetAll()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var storeName = $"Proc_{_className}GetAll";

                var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);

                return entities.ToList();
            }
        }
        #endregion

        #region Phương thức lấy thông tin thực thể qua ID
        /// <summary>
        /// Lấy thông tin thực thể theo ID
        /// </summary>
        /// <param name="entityId">ID thực thể</param>
        /// <returns>Thông tin thực thể cần lấy</returns>
        /// Author: NQMinh(01/10/2021)
        public MISAEntity GetById(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                var storeName = $"Proc_{_className}GetById";

                parameters.Add($"@{_className}Id", entityId);

                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(storeName, param: parameters, commandType: CommandType.StoredProcedure);

                return entity;
            }
        }
        #endregion

        #region Phương thức thêm thực thể vào DB
        /// <summary>
        /// Thêm mới thực thể
        /// </summary>
        /// <param name="entity">thông tin thực thể</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author: NQMinh(01/10/2021)
        public int Insert(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                //Khai báo dynamic param:
                var dynamicParams = new DynamicParameters();

                var columnsName = string.Empty;
                var columnsParam = string.Empty;

                //Đọc từng property của object:
                var properties = entity.GetType().GetProperties();

                //Duyệt từng property:
                foreach (var prop in properties)
                {
                    //Lấy tên của prop:
                    var propName = prop.Name;

                    //Lấy value của prop:
                    var propValue = prop.GetValue(entity);

                    //Lấy kiểu dữ liệu của prop:
                    var propType = prop.PropertyType;
                    dynamicParams.Add($"@{propName}", propValue);

                    columnsName += $"{propName},";
                    columnsParam += $"@{propName},";
                }

                var storeName = $"Proc_{_className}Insert";

                var rowAffects = _dbConnection.Execute(storeName, param: dynamicParams, commandType: CommandType.StoredProcedure);

                //Trả về số bản ghi thêm mới:
                return rowAffects;
            }
        }
        #endregion

        #region Sửa thông tin tin thực thể
        /// <summary>
        /// Sửa thông tin thực thể
        /// </summary>
        /// <param name="entityId">ID của thực thể cần sửa</param>
        /// <param name="entity">Dữ liệu cần sửa của thực thể</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Author: NQMinh (01/10/2021)
        public int Update(Guid entityId, MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                //Khai báo dynamic param:
                DynamicParameters dynamicParams = new();

                //var queryString = string.Empty;

                //Đọc từng property của object:
                var properties = entity.GetType().GetProperties();

                //Duyệt từng property:
                foreach (var prop in properties)
                {
                    //Lấy tên của prop:
                    var propName = prop.Name;

                    //Lấy value của prop:
                    var propValue = prop.GetValue(entity);

                    //Thêm param tương ứng với mỗi property của đối tượng:
                    if (propName != $"{_className}Id")
                    {
                        dynamicParams.Add($"@{propName}", propValue);
                    }
                }

                dynamicParams.Add($"@{_className}Id", entityId);

                var storeName = $"Proc_{_className}Update";

                var rowAffects = _dbConnection.Execute(storeName, param: dynamicParams, commandType: CommandType.StoredProcedure);

                return rowAffects;
            }
        }
        #endregion
        #endregion
    }
}