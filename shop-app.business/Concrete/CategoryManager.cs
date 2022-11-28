using shop_app.data.Abstract;
using shop_app.data.Exceptions;
using shop_app.entity;
using shop_app.service.Abstract;
using shop_app.shared.Utilities.Results.Abstract;
using shop_app.shared.Utilities.Results.ComplexTypes;
using shop_app.shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.service.Concrete
{
    public class CategoryManager : ServiceBase<Category>, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IDataResult<Category>> GetCagetoryByURI(string uri)
        {
            try
            {
                Category category = await _unitOfWork.CategoryRepository.GetCategoryByURI(uri);
                return new DataResult<Category>(category);
            }
            catch (NoElementFoundException exception)
            {
                return new DataResult<Category>(ResultStatus.Error, $"{uri} kimliğiyle bir kategori bulunamadı", exception);
            }
        }

        public async Task<IDataResult<IEnumerable<Category>>> GetPopularCategories()
        {
            try
            {
                IEnumerable<Category> category = await _unitOfWork.CategoryRepository.GetPopularCategories();
                return new DataResult<IEnumerable<Category>>(category);
            }
            catch (NoElementFoundException exception)
            {
                return new DataResult<IEnumerable<Category>>(ResultStatus.Error, $"Kategori bulunamadı", exception);
            }
        }
    }
}
