using shop_app.data.Abstract;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.Concrete;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.data.Exceptions;
using System.Xml.Linq;

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

        public async virtual Task<IResult> Create(TEntity entity)
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

        public async virtual Task<IResult> Delete(TEntity entity)
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

        public async virtual Task<IDataResult<IEnumerable<TEntity>>> GetAll()
        {
            try
            {
                IEnumerable<TEntity> entity = await _unitOfWork.GetRepository<TEntity>().GetAll();
                return new DataResult<IEnumerable<TEntity>>(entity);
            }
            catch(Exception e)
            {
                return new DataResult<IEnumerable<TEntity>>(ResultStatus.Error, "BAŞARAMDIK ABİ", e);
            }
        }

        public async virtual Task<IDataResult<TEntity>> GetOne(Guid id)
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

        public async Task<IDataResult<IEnumerable<TEntity>>> GetPart(int start, int size)
        {
            try
            {
                IEnumerable<TEntity> list = await _unitOfWork.GetRepository<TEntity>().GetPart(start,size);
            }
            catch (NoElementFoundException noElement)
            {
                new DataResult<TEntity>(ResultStatus.Error, "BAŞARAMDIK ABİ", noElement);
            }
            catch (ArgumentException argumentException)
            {
                new DataResult<TEntity>(ResultStatus.Error, "BAŞARAMDIK ABİ", argumentException);
            }
        }

        public async virtual Task<IResult> Update(TEntity entity)
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
