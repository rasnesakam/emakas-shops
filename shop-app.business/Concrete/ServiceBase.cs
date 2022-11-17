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

        public virtual void CreateEntity(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Create(entity);
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
        }

        public virtual List<TEntity> GetEntities()
        {
            return _unitOfWork.GetRepository<TEntity>().GetAll();
        }

        public virtual TEntity GetEntity(Guid id)
        {
            return _unitOfWork.GetRepository<TEntity>().GetById(id);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Update(entity);
        }
    }
}
