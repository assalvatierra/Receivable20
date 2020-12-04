using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;

namespace ArServices
{
    public class CategoryMgr : iCategoryMgr
    {
        private ArDBContainer db;

        public CategoryMgr()
        {
            this.db = new ArDBContainer();
        }

        public CategoryMgr(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool AddCategory(ArCategory category)
        {
            try
            {
                if (category == null)
                {
                    return false;
                }

                db.ArCategories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Category");
            }
        }

        public bool DbDispose()
        {

            try
            {
                db.Dispose();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Dispose Db");
            }
        }

        public bool EditCategory(ArCategory category)
        {

            try
            {
                if (category == null)
                {
                    return false;
                }

                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Category");
            }
        }

        public List<ArCategory> GetCategories()
        {
            try
            {
                return db.ArCategories.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Categories");
            }
        }

        public ArCategory GetCategoryById(int? id)
        {
            try
            {
                return db.ArCategories.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Category by Id");
            }
        }

        public bool RemoveCategory(int id)
        {
            try
            {
                var category = GetCategoryById(id);

                db.ArCategories.Remove(category);
                db.SaveChanges();

                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Remove Category");
            }
        }
    }
}
