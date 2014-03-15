using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Watchlist_app_win8.DataFetchers
{

    //Movie metadata
    //
    //
    //
    class Movies
    {
        public ObservableCollection<MoviePreview> results { get; set; }
        public List<MoviePreview> watchlist { get; set; }
    }

     class MoviePreview
     {
        public MoviePreview()
        {
            id = "empty";
            fullPosterPath = "http://image.tmdb.org/t/p/w300";
            fullBackdropPath = "http://image.tmdb.org/t/p/w500";
        }
        public string Title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public string id { get; set; }
        public string Vote_Average { get; set; }

        public string fullPosterPath { get; set; }
        public string fullBackdropPath { get; set; }

        public ObservableCollection<MoviePreview> movieCall = new ObservableCollection<MoviePreview>();
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

        public ObservableCollection<Movie> movieCall = new ObservableCollection<Movie>();
    }

}
