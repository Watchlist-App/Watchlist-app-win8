using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist_app_win8.Logic
{
    public static class Data                    //delegate prototype
    {
        public delegate void MyEvent(string result);
        public static MyEvent EventHandler;
    }
}
