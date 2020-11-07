using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iActionMgr
    {
        bool AddAction(ArAction action);
        bool AddAction(int actionId, DateTime dtPreformed, string performedBy, int transactionId);
        bool EditAction(ArAction action);
        bool RemoveAction(int id);
        ArAction GetActionById(int? id);
        List<ArAction> GetActions();
        IEnumerable<ArActionItem> GetActionItems();
        bool DbDispose();
        ArAction GetTransLastAction(int transId);

    }
}
