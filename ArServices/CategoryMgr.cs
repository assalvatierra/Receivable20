using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArDBLayer;
using ArInterfaces;
using ArModels.Models;

namespace ArServices
{
    public class CategoryMgr : iCategoryMgr
    {
        private CategoryDb db;

        public CategoryMgr()
        {
            this.db = new CategoryDb();
        }

        public CategoryMgr(ArDBContainer arDB)
        {
            this.db = new CategoryDb(arDB);
        }

        public bool AddCategory(ArCategory category)
        {
            try
            {
                return db.AddCategory(category);
            }
            catch
            {
                return false;
            }
        }

        public bool DbDispose()
        {

            try
            {
                return db.DbDispose();
            }
            catch
            {
                return false;
            }
        }

        public bool EditCategory(ArCategory category)
        {

            try
            {
                return db.EditCategory(category);
            }
            catch
            {
                return false;
            }
        }

        public List<ArCategory> GetCategories()
        {
            try
            {
                return db.GetCategories().ToList();
            }
            catch
            {
                return null;
            }
        }

        public ArCategory GetCategoryById(int? id)
        {
            try
            {
                return db.GetCategoryById((int)id);
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveCategory(int id)
        {
            try
            {
                ArCategory category = db.GetCategoryById(id);

                return db.RemoveCategory(category);
            }
            catch
            {
                return false;
            }
        }
    }
}
