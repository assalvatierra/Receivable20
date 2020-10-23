using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels.Models;

namespace ArInterfaces
{
    public interface iCategoryMgr
    {
        bool AddCategory(ArCategory category);
        bool EditCategory(ArCategory category);
        bool RemoveCategory(int id);
        ArCategory GetCategoryById(int? id);
        List<ArCategory> GetCategories();
        bool DbDispose();
    }
}
