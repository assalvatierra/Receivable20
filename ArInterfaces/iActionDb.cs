using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iActionDb
    {
        bool DbDispose();
        IQueryable<ArAction> GetActions();
        bool AddAction(ArAction action);
        bool EditAction(ArAction action);
        bool RemoveAction(ArAction action);
        ArAction GetActionById(int id);
        IQueryable<ArActionItem> GetActionItems();
    } 
}
