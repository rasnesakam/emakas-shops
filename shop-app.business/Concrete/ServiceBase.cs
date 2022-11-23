using shop_app.data.Abstract;
using shop_app.service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async virtual void CreateEntity(TEntity entity)
        {
            await _unitOfWork.GetRepository<TEntity>().Create(entity);
            await _unitOfWork.GetRepository<TEntity>().SaveChanges();
        }

        public async virtual void DeleteEntity(TEntity entity)
        {
            await _unitOfWork.GetRepository<TEntity>().Delete(entity);
            await _unitOfWork.GetRepository<TEntity>().SaveChanges();
        }

        public async virtual Task<List<TEntity>> GetEntities()
        {
            return await _unitOfWork.GetRepository<TEntity>().GetAll();
        }

        public async virtual Task<TEntity> GetEntity(Guid id)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetById(id);
        }

        public async virtual void UpdateEntity(TEntity entity)
        {
            await _unitOfWork.GetRepository<TEntity>().Update(entity);
            await _unitOfWork.GetRepository<TEntity>().SaveChanges();
        }
    }
}
