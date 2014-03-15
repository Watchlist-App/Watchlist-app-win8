using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Watchlist_app_win8.DataFetchers
{
    class Users
    {
        public ObservableCollection<User> results { get; set; }
    }

    class User
    {       
            public string id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public string email { get; set; } 
    }
}
