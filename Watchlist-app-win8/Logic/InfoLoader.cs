using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Watchlist_app_win8.DataFetchers;

namespace Watchlist_app_win8.Logic
{
    class InfoLoader
    {
        public static async Task<Movie> getMoreInfo(string id)
        {
            string URL = "http://api.themoviedb.org/3/movie/" + id + "?api_key=86afaae5fbe574d49418485ca1e58803&append_to_response=releases,trailers";
            string responce = await Request.getInfo(URL);
            Movie current = Json.deserializeJsonMetaData(responce);
            return current;
            //Info.EventHandler(current);
        }
    }
}
