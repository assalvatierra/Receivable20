﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using ArDBLayer;

namespace ArServices
{
    public class ActionMgr : iActionMgr
    {
        private ActionDb db;

        public ActionMgr()
        {
            this.db = new ActionDb();
        }

        public ActionMgr(ArDBContainer arDB)
        {
            this.db = new ActionDb(arDB);
        }

        public bool AddAction(ArAction action)
        {
            try
            {
                return db.AddAction(action);
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

        public bool EditAction(ArAction action)
        {
            try
            {
                return db.EditAction(action);
            }
            catch
            {
                return false;
            }
        }

        public ArAction GetActionById(int? id)
        {

            try
            {
                return db.GetActionById((int)id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArAction> GetActions()
        {

            try
            {
                return db.GetActions().ToList();
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
                return db.GetActionItems().ToList();
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
                ArAction action = db.GetActionById(id);

                return db.RemoveAction(action);
            }
            catch
            {
                return false;
            }
        }
    }
}