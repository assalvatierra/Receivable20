﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using System.Data.Entity.Core;
using System.Data.Entity;

namespace ArServices
{
    public class ActionMgr : iActionMgr
    {
        private ArDBContainer db;
        private DateClassMgr dateMgr;

        public ActionMgr()
        {
            this.db = new ArDBContainer();
            this.dateMgr = new DateClassMgr();
        }

        public ActionMgr(ArDBContainer arDB)
        {
            this.db = arDB;
            this.dateMgr = new DateClassMgr();
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
                throw new EntitySqlException("Services: Unable to Get Recievable Actions");
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
                throw new EntitySqlException("Services: Unable to Get Recievable Actions Items");
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
                throw new EntitySqlException("Services: Unable to Remove Recievable Actions");
            }
        }

        public bool AddAction(int actionId, string performedBy, int transactionId)
        {
            try
            {
                ArAction action = new ArAction();
                action.ArActionItemId = actionId;
                action.DtPerformed = dateMgr.GetCurrentDateTime();
                action.PreformedBy = performedBy;
                action.ArTransactionId = transactionId;

                return AddAction(action);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Recievable Actions");
            }
        }


        public bool AddAction(int actionId, string performedBy, int transactionId, string remarks)
        {
            try
            {
                ArAction action = new ArAction();
                action.ArActionItemId = actionId;
                action.DtPerformed = dateMgr.GetCurrentDateTime();
                action.PreformedBy = performedBy;
                action.ArTransactionId = transactionId;
                action.Remarks = remarks;

                return AddAction(action);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Recievable Actions");
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
                throw new EntitySqlException("Services: Unable to Trans Last Action");
            }
        }
    }
}
