using SimpleApi.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Service.Intrfaces
{
    public interface IProductService
    {
        int Add(ProductModel entity);
        ProductViewModel GetById(int id);
        List<ProductViewModel> GetAll();
        List<ProductViewModel> Find(Expression<Func<ProductModel, bool>> expression);
        int Update(ProductViewModel entity);
        void Delete(int id);

        List<ProductViewModel> List(int start, int size);
    }
}
