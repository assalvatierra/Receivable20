using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArModels.Models
{
    public class ArRptModel
    {
        public class ArRptTransPending
        {
            public int Id { get; set; }
            public int AccountId   { get; set; }
            public string Account  { get; set; }
            public decimal Amount  { get; set; }
            public decimal Payment { get; set; }
            public decimal Balance { get; set; }
            public string Status   { get; set; }
        }


        public class ArAccountStatement
        {
            public int ArTransId { get; set; }
            public int InvoiceId { get; set; }
            public string InvoiceRef { get; set; }
            public DateTime InvoiceDate { get; set; }
            public String Description { get; set; }
            public Decimal Amount { get; set; }
            public Decimal Payment { get; set; }
        }
    }
}
