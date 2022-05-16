using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat.Json
{
    public class Data
    {
        public int fieldCount { get; set; }
        public int affectedRows { get; set; }
        public int insertId { get; set; }
        public int serverStatus { get; set; }
        public int warningCount { get; set; }
        public string message { get; set; }
        public bool protocol41 { get; set; }
        public int changedRows { get; set; }
    }
}
