using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using AzadiSoft.OnlineStore.DomainClasses;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.ServiceLayer
{
    public interface IProduct_Service: IGenericService<Product>
    {
        IList<ProductViewModel> GetViewModels(Expression<Func<Product, bool>> expression = null);

        ProductViewModel GetViewModel(int id);

        IQueryable<Product> GetWithDetails(Expression<Func<Product, bool>> expression = null);
    }
}