using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels.Models;
using ArInterfaces;
using System.Data.Entity;

namespace ArDBLayer
{
    public class CategoryDb : iCategoryDb
    {
        private ArDBContainer db;

        public CategoryDb()
        {
            this.db = new ArDBContainer();
        }

        public CategoryDb(ArDBContainer arDB)
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

        public IQueryable<ArCategory> GetCategories()
        {

            try
            {
                return db.ArCategories;
            }
            catch
            {
                return null;
            }
        }

        public ArCategory GetCategoryById(int id)
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

        public bool RemoveCategory(ArCategory category)
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
    }
}
