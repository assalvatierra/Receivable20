using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransPaymentDb
    {
        bool DbDispose();

        bool AddTransPayment(ArTransPayment transPayment);
        bool EditTransPayment(ArTransPayment transPayment);
        bool DeleteTransPayment(ArTransPayment transPayment);
        ArTransPayment GetTransPaymentById(int id);
        IQueryable<ArTransPayment> GetTransPayments();
    }
}
