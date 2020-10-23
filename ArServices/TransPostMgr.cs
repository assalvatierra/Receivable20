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
    public class TransPostMgr : iTransPostMgr
    {
        private TransPostDb db;

        public TransPostMgr()
        {
            db = new TransPostDb();
        }

        public TransPostMgr(ArDBContainer arDB)
        {
            this.db = new TransPostDb(arDB);
        }

        public bool AddTransPost(ArTransPost transPost)
        {
            try
            {
                return db.AddTransPost(transPost);
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
                return db.EditTransPost(transPost);
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
                return db.GetTransPostById(id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArTransPost> GetTransPosts()
        {
            try
            {
                return db.GetTransPosts().ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveTransPost(ArTransPost transPost)
        {
            try
            {
                return db.AddTransPost(transPost);
            }
            catch
            {
                return false;
            }
        }
    }
}
