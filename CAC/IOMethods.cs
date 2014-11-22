using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAC
{
    public static class IOMethods
    {
        private static List<dynamic> _IO = new List<dynamic>();

        public static List<dynamic> IO
        {
            get
            { return _IO;}

            set
            { _IO.Add(value); }
        }
    }
}
