using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist_app_win8.DataFetchers
{

    //Movie metadata
    //
    //
    //
     class MoviePreview
     {
        public MoviePreview()
        {
            id = "empty";
        }
        public string Title { get; set; }
        public string poster_path { get; set; } 
        public string id { get; set; }

        //public ObservableCollection<Movie> movieCall = new ObservableCollection<Movie>();
    }

    class Movie
    {
        public Movie()
        {
            id = "empty";
        }
        public string Title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int Watch_flag { get; set; }
        public string Release_Date { get; set; }
        public string source { get; set; }
        public string budget { get; set; }
        public string runtime { get; set; }
        public string Vote_Average { get; set; }
        public string revenue { get; set; }
        public string id { get; set; }

        //public ObservableCollection<Movie> movieCall = new ObservableCollection<Movie>();
    }

}
