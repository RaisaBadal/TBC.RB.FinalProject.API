using AutoMapper;
using Microsoft.Extensions.Logging;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Domain.Entitites;
using RB.TBC.FinalProject.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.TBC.FinalProject.Application.Services
{
    public class FeadbackService : AbstractService<FeadbackService>, IFeadbackService
    {

        private readonly IFeadbackRepository work;
        public FeadbackService(IMapper map, ILogger<FeadbackService> log, IFeadbackRepository work) : base(map, log)
        {
            this.work = work;
        }

        #region AddAsync
        public async Task<string> AddAsync(FeadbackModel entity,string UserId,string UserName,string Email)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var mapped = mapper.Map<Feadback>(entity);
            if (mapped is not null)
            {
                mapped.UserId = UserId;
                mapped.FeadbackId = Guid.NewGuid().ToString();
                mapped.FeadbackDate = DateTime.Now;
                mapped.Name = UserName;
                mapped.Email = Email;
                mapped.Status = true;
                return await work.AddAsync(mapped);
            }
            throw new ArgumentNullException("Internal server error");
        }
        #endregion

        #region GetAllActiveAsync
        public async Task<IEnumerable<FeadbackModel>> GetAllAsync()
        {
            var ser = await work.GetAllAsync();
            if (ser.Any())
            {
                var filtered = ser.Where(io => io.Status == true).ToList();
                var mapped = mapper.Map<IEnumerable<FeadbackModel>>(filtered);
                return mapped;
            }
            throw new ArgumentNullException("Not found");
        }
        #endregion


        #region GetByIdAsync
        public async Task<FeadbackModel> GetByIdAsync(string id)
        {
            var ser = await work.GetByIdAsync(id);
            if (ser is not null)
            {
                var mapped = mapper.Map<FeadbackModel>(ser);
                return mapped;
            }
            throw new ArgumentNullException("Not Foun");
        }
        #endregion

        #region RemoveAsync
        public async Task<bool> RemoveAsync(string Id)
        {
            var feadbback = await work.GetByIdAsync(Id);
            if (feadbback is not null)
            {
                return await work.RemoveAsync(feadbback);
            }
            throw new ArgumentNullException("Not Found");
        }
        #endregion

        #region SoftDeleteAsync
        public async Task<bool> SoftDeleteAsync(string id)
        {
            var feadbback = await work.SoftDeleteAsync(id);
            return feadbback;
        }
        #endregion
    }
}
