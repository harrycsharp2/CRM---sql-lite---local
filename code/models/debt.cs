using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMwpf.models
{
    public class debt
    {
        public int Id { get; set; }
        public string owedto { get; set; }
        public int amountowed { get; set; }
        public int amountpayed { get; set; }
    }
}
