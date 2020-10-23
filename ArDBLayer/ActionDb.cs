using ArInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ArModels.Models;

namespace ArDBLayer
{
    public class ActionDb : iActionDb
    {
        private ArDBContainer db;

        public ActionDb()
        {
            this.db = new ArDBContainer();
        }

        public ActionDb(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool AddAction(ArAction action)
        {
            try
            {
                if (action != null)
                {
                    db.ArActions.Add(action);
                    db.SaveChanges();
                    return true;
                }
                return false;
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

        public bool EditAction(ArAction action)
        {

            try
            {
                if (action != null)
                {
                    db.Entry(action).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public ArAction GetActionById(int id)
        {
            try
            {
                return db.ArActions.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArActionItem> GetActionItems()
        {
            try
            {
                return db.ArActionItems;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArAction> GetActions()
        {
            try
            {
                return db.ArActions;
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveAction(ArAction action)
        {
            try
            {

                if (action != null)
                {
                    db.ArActions.Remove(action);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
