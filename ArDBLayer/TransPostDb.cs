using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using System.Data.Entity;

namespace ArDBLayer
{
    public class TransPostDb : iTransPostDb
    {
        private ArDBContainer db;

        public TransPostDb()
        {
            this.db = new ArDBContainer();
        }

        public TransPostDb(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool AddTransPost(ArTransPost transPost)
        {
            try
            {
                if (transPost != null)
                {
                    return false;
                }

                db.ArTransPosts.Add(transPost);
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
            try {
                db.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransPost(ArTransPost transPost)
        {
            try
            {

                if (transPost != null)
                {
                    return false;
                }

                db.ArTransPosts.Add(transPost);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTransPost(ArTransPost transPost)
        {

            try
            {

                if (transPost != null)
                {
                    return false;
                }

                db.Entry(transPost).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ArTransPost GetTransPostById(int id)
        {
            try
            {

                return db.ArTransPosts.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArTransPost> GetTransPosts()
        {
            try
            {
                return db.ArTransPosts;
            }
            catch
            {
                return null;
            }
        }
    }
}
