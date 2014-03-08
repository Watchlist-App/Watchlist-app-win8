using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Collections.ObjectModel;
using Windows.UI.Popups; 


using Watchlist_app_win8.Views;
using Watchlist_app_win8.DataFetchers;
using Watchlist_app_win8.Logic;


// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Watchlist_app_win8
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<MoviePreview> _movies;
        private ObservableCollection<Movie> MovieInfo = new ObservableCollection<Movie>();

        public MainPage()
        {
            Data.EventHandler = new Data.MyEvent(showGroup);
            this.InitializeComponent();
            StartClass.start("https://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        private async void showGroup(Movies current)  //temporary output
        {
            Movie temp = new Movie();
            _movies = current.results;
            foreach (var value in _movies)
                { 
                value.fullPosterPath += value.poster_path;
                temp = await InfoLoader.getMoreInfo(value.id);
                MovieInfo.Add(temp);
                value.overview = temp.overview;
                }
               
            gvMain.ItemsSource = _movies;           
        }

        private void showCurrent(Movie current)  //temporary output
        {
            //titleBox.Text = current.Title;
            //overview.Text = current.overview;
        }

        private async void gvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoviePreview temp = (MoviePreview)gvMain.SelectedItem;
            InfoLoader.getMoreInfo(temp.id);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string temp = searchBox.Text;
            if (temp != "")
                StartClass.start("http://api.themoviedb.org/3/search/movie?query=" + temp + "&api_key=86afaae5fbe574d49418485ca1e58803");
        }

    }
}
