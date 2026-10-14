using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMwpf.models
{
    public class Money
    {
        public int Id { get; set; }

        public float balance { get; set; } // current balance
        public float totalincome { get; set; } //total revenue
        public float totaldebt { get; set; } // total debt owed to banks etc
        public float outstandingbalance { get; set; } // total money owed to company/user

    }
}
