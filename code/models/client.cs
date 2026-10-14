using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMwpf.models
{
    public class client
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public float debt { get; set; }
        public float income { get; set; }
    }
}
