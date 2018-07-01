using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AzadiSoft.OnlineStore.DataLayer;
using AzadiSoft.OnlineStore.DomainClasses;
using AzadiSoft.OnlineStore.Framework;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.ServiceLayer
{
    public class Product_Service : GenericService<Product>, IProduct_Service
    {
        public Product_Service(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IList<ProductViewModel> GetViewModels(Expression<Func<Product, bool>> expression = null)
        {
            var query = GetWithDetails(expression);

            var models = query.ToList().Select(x => x.ToModel()).ToList();

            return models;
        }

        public ProductViewModel GetViewModel(int id)
        {
            var query = GetViewModels(x => x.ID == id).SingleOrDefault();

            return query;
        }

        public IQueryable<Product> GetWithDetails(Expression<Func<Product, bool>> expression = null)
        {
            var query = GetAllQueryable(expression)
                .Include(x => x.Product_Spec_Mapping)
                .Include(x => x.Photos)
                .Include(x => x.Product_Spec_Mapping.Select(t => t.Spec))
                .Include(x => x.Product_Spec_Mapping.Select(t => t.SpecOption))
                ;

            return query;

        }
    }
}