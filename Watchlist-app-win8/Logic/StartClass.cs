using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Watchlist_app_win8.DataFetchers;

namespace Watchlist_app_win8.Logic
{
    static class StartClass
    {
        public static async void start(string URL)
        {
            Movies current = new Movies();
            string responce = await Request.getInfo(URL);
            current = Json.deserializeJson(responce);
            Data.EventHandler(current);   
        }

    }
}
