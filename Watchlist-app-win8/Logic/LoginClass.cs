using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups; 


using Watchlist_app_win8.Views;
using Watchlist_app_win8.DataFetchers;
using Watchlist_app_win8.Logic;

namespace Watchlist_app_win8.Logic
{
    class LoginClass
    {

        public static User currentUser;

        public async static Task<User> startLogin()
        {
             string responce = await Request.getInfo("http://watchlist-app-server.herokuapp.com/user?name=Dmitry Mazuro&password=12345");
             currentUser = Json.Serialization_User(responce);
             return currentUser;

        }
    }
}
