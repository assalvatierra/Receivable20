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
    }
}
