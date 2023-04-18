using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp18.Models;

namespace WpfApp18.Repo
{
    public  class Tables
    {
        public Tablee Table1 { get; set; } = new Tablee("Table1", false);
        public Tablee Table2 { get; set; } = new Tablee("Table2", false);
        public Tablee Table3 { get; set; } = new Tablee("Table3", false);
        public Tablee Table4 { get; set; } = new Tablee("Table4", false);
        public Tablee Table5 { get; set; } = new Tablee("Table5", false);
        public Tablee Table6 { get; set; } = new Tablee("Table6", false);

    }
}
