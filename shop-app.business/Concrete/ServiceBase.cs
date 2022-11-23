using shop_app.data.Abstract;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using shop_app.shared.Utilities.Results.ComplexTypes;

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

        public async virtual Task<IResult> CreateEntity(TEntity entity)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().Create(entity);
                await _unitOfWork.GetRepository<TEntity>().SaveChanges();
                return new Result(ResultStatus.Success);
            }
            catch (Exception e)
            {
                return new Result(ResultStatus.Error, "hata", e);
            }

        }

        public async virtual Task<IResult> DeleteEntity(TEntity entity)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().Delete(entity);
                await _unitOfWork.GetRepository<TEntity>().SaveChanges();
                return new Result(ResultStatus.Success);
            }
            catch (Exception e)
            {
                return new Result(ResultStatus.Error, "hata", e);
            }
        }

        public async virtual Task<IDataResult<List<TEntity>>> GetEntities()
        {
            try
            {
                List<TEntity> entity = await _unitOfWork.GetRepository<TEntity>().GetAll();
                return new DataResult<List<TEntity>>(entity);
            }
            catch(Exception e)
            {
                return new DataResult<List<TEntity>>(ResultStatus.Error, "BAŞARAMDIK ABİ", e);
            }
        }

        public async virtual Task<IDataResult<TEntity>> GetEntity(Guid id)
        {
            try
            {
                TEntity entity = await _unitOfWork.GetRepository<TEntity>().GetById(id);
                return new DataResult<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new DataResult<TEntity>(ResultStatus.Error, "BAŞARAMDIK ABİ", e);
            }
        }

        public async virtual Task<IResult> UpdateEntity(TEntity entity)
        {
            try
            {
                await _unitOfWork.GetRepository<TEntity>().Update(entity);
                await _unitOfWork.GetRepository<TEntity>().SaveChanges();
                return new Result(ResultStatus.Success);
            }
            catch (Exception e)
            {
                return new Result(ResultStatus.Error,"hata",e);
            }
        }
    }
}
