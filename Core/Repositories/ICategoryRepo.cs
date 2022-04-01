using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        Task<Category> GetSingleCategoryWithProdAsync(int categoryid);
    }
}
