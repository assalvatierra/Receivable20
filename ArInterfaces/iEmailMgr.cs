using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iEmailMgr
    {
        bool SendEmail(string recipient);
        bool SendEmail(string recipient, string emailMsg);
        bool SendEmail_test(string recipient);
    }
}
