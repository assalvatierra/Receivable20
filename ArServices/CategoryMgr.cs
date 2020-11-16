using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return false;
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
                return false;
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
                return false;
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
                return null;
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
                return null;
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
                return false;
            }
        }
    }
}
