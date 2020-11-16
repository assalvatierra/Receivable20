using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using ArDBLayer;
using System.Data.Entity.Core;
using System.Data.Entity;

namespace ArServices
{
    public class ActionMgr : iActionMgr
    {
        private ArDBContainer db;

        public ActionMgr()
        {
            this.db = new ArDBContainer();
        }

        public ActionMgr(ArDBContainer arDB)
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
                throw new EntitySqlException("Services: Unable to Add Recievable Account");
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
                throw new EntitySqlException("Services: Unable to Add Recievable Account");
            }
        }

        public ArAction GetActionById(int? id)
        {

            try
            {
                return db.ArActions.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account by Id");
            }
        }

        public List<ArAction> GetActions()
        {

            try
            {
                return db.ArActions.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ArActionItem> GetActionItems()
        {
            try
            {
                return db.ArActionItems.ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveAction(int id)
        {
            try
            {
                ArAction action = GetActionById(id);

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

        public bool AddAction(int actionId, DateTime dtPreformed, string performedBy, int transactionId)
        {
            try
            {
                ArAction action = new ArAction();
                action.ArActionItemId = actionId;
                action.DtPerformed = dtPreformed;
                action.PreformedBy = performedBy;
                action.ArTransactionId = transactionId;

                return AddAction(action);
            }
            catch
            {
                return false;
            }
        }

        public ArAction GetTransLastAction(int transId)
        {
            try
            {
                var actionList = GetActions().Where(a => a.ArTransactionId == transId).OrderByDescending(a=>a.DtPerformed).ToList();

                if(actionList != null)
                {
                    return actionList.LastOrDefault();
                }
                return new ArAction { ArActionItemId = 1 };
            }
            catch
            {
                return null;
            }
        }
    }
}
