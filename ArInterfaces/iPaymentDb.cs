using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iPaymentDb
    {
        bool DbDispose();
        IQueryable<ArPayment> GetPayment();
        bool AddPayment(ArPayment payment);
        bool EditPayment(ArPayment payment);
        bool RemovePayment(ArPayment payment);
        ArPayment GetPaymentById(int id);
        IQueryable<ArPaymentType> GetPaymentTypes();
    }
}
