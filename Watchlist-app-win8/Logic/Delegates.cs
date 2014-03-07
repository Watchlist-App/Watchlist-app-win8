using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Watchlist_app_win8.DataFetchers;

namespace Watchlist_app_win8.Logic
{
    static class Data                    //delegate prototype
    {
        public delegate void MyEvent(Movies current);
        public static MyEvent EventHandler;
    }
}
