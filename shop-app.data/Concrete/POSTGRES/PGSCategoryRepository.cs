using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_app.data.Abstract;
using shop_app.entity;

namespace shop_app.data.Concrete.POSTGRES
{
	public class PGSCategoryRepository : ICategoryRepository
	{
		Category GetById(Guid id)
		{}

		List<Category> GetAll()
		{}

		void Create(Category entity)
		{}

		void Update(Category entity)
		{}
	}
}