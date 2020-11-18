using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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
        private ArDBContainer db;

        public TransPostMgr()
        {
            db = new ArDBContainer();
        }

        public TransPostMgr(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool AddTransPost(ArTransPost transPost)
        {
            try
            {
                if (transPost == null)
                {
                    return false;
                }

                db.ArTransPosts.Add(transPost);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Trasnsaction Post");
            }
        }

        public bool CreateTransPost(ArTransaction transaction, DateTime postDate, decimal balance)
        {
            try
            {
                ArTransPost arTransPost = new ArTransPost();
                arTransPost.DtPost = postDate;
                arTransPost.Amount = transaction.Amount;
                arTransPost.Balance = balance;
                arTransPost.ArTransactionId = transaction.Id;

                return AddTransPost(arTransPost);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Trasnsaction Post");
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
                throw new EntitySqlException("Services: Unable to Edit Trasnsaction Post");
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
                throw new EntitySqlException("Services: Unable to Get Trasnsaction by Id");
            }
        }

        public List<ArTransPost> GetTransPosts()
        {
            try
            {
                return db.ArTransPosts.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Trasnsaction Posts");
            }
        }

        public bool RemoveTransPost(ArTransPost transPost)
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
                throw new EntitySqlException("Services: Unable to Remove Trasnsaction");
            }
        }
    }
}
