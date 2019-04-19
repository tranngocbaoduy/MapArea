using MyMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap.DBConnection
{
    class DataProvider
    {
        private static DataProvider _ins;

        // create DB if _ins null, use only 1 time in Project
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public MYMAPEntities2 DB { get; set; }

        private DataProvider()
        {
            DB = new MYMAPEntities2();
        }
    }
}
