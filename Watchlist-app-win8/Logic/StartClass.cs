using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Watchlist_app_win8.DataFetchers;

namespace Watchlist_app_win8.Logic
{
    static class StartClass
    {
        public static async void start()
        {
            string URL = "https://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803";
            string responce = await Request.getInfo(URL);
            Data.EventHandler(responce);   
        }

    }
}
