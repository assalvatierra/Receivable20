using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels.Models;

namespace ArInterfaces
{
    public interface iCategoryDb
    {
        bool DbDispose();
        IQueryable<ArCategory> GetCategories();
        bool AddCategory(ArCategory category);
        bool EditCategory(ArCategory category);
        bool RemoveCategory(ArCategory category);
        ArCategory GetCategoryById(int id);

    }
}
