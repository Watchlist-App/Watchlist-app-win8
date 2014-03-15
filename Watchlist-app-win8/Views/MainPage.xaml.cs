using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Watchlist_app_win8.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

using Watchlist_app_win8.Common;
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
        private ObservableCollection<MoviePreview> description = new ObservableCollection<MoviePreview>();
        private ObservableCollection<Movie> MovieInfo = new ObservableCollection<Movie>();

        private NavigationHelper navigationHelper;

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public MainPage()
        {
            Data.EventHandler = new Data.MyEvent(showGroup);
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;           

            StartClass.start("https://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803");

            if (LoginClass.currentUser != null)
            {
                logincontrol1.IsOpen = false;
                gvMain.IsEnabled = true;
                gvMain.Opacity = 1.0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            if (!logincontrol1.IsOpen)
            {
                gvMain.IsEnabled = false;
                this.Opacity = 0;
                container.IsEnabled = true;
                logincontrol1.IsOpen = true;
                pop.Width = Window.Current.Bounds.Width;
            }
            else
            {
                logincontrol1.IsOpen = false;
                this.Opacity = 1.0;
                gvMain.IsEnabled = true;
                gvMain.Opacity = 1.0;
            }
        }

        private async void loginClick(object sender, RoutedEventArgs e)
        {
            await LoginClass.startLogin(id.Text, pwd.Text);
            this.Frame.Navigate(typeof(SecondPage));

            logincontrol1.IsOpen = false;
            this.Opacity = 1.0;
            gvMain.IsEnabled = true;
            gvMain.Opacity = 1.0;
        }



        private async void showGroup(Movies current)  //temporary output
        {
            Movie temp = new Movie();
            _movies = current.results;
            foreach (var value in _movies)
                { 
                value.fullPosterPath += value.poster_path;
                value.fullBackdropPath += value.backdrop_path;
                temp = await InfoLoader.getMoreInfo(value.id);
                MovieInfo.Add(temp);
                value.overview = temp.overview;
                value.Vote_Average += "/10";
                }
               
            gvMain.ItemsSource = _movies;           
        }


        private async void gvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            description.Add((MoviePreview)gvMain.SelectedItem);
            //gvSecond.ItemsSource = description;
        }

        private void searchButtonClick(object sender, RoutedEventArgs e)
        {
            string temp = searchBox.Text;
            if (temp != "")
                StartClass.start("http://api.themoviedb.org/3/search/movie?query=" + temp + "&api_key=86afaae5fbe574d49418485ca1e58803");
        }

        private void tempName(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

    }
}
