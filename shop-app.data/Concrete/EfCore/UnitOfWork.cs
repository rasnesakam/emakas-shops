using Microsoft.EntityFrameworkCore;
using shop_app.data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _shopContext;

        public UnitOfWork(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository => _productRepository ?? new EfCoreProductRepository(_shopContext);

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new EfCoreCategoryRepository(_shopContext);

        private IOrderRepository _orderRepository;
        public IOrderRepository OrdersRepository => _orderRepository ?? new EfCoreOrderRepository(_shopContext);

        private IAddressRepository _addressRepository;
        public IAddressRepository AddressRepository => _addressRepository ?? new EfCoreAddressRepository(_shopContext);

        private IPropertyRepository _propertyRepository;
        public IPropertyRepository PropertyRepository => _propertyRepository ?? new EfCorePropertyRepository(_shopContext);

        private IReviewRepository _reviewRepository;
        public IReviewRepository ReviewRepository => _reviewRepository ?? new EfCoreReviewRepository(_shopContext);


        IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new EfCoreRepositoryBase<TEntity>(_shopContext);
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }

        IRepositoryBase<T> IUnitOfWork.GetRepository<T>()
        {
           return new EfCoreRepositoryBase<T>(_shopContext);
        }
    }
}
