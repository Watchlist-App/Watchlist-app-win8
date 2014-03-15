﻿using System;
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
        private ObservableCollection<MoviePreview> description = new ObservableCollection<MoviePreview>();
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
            //if ((Name.Text != "") && (pass != ""))
            //{

                string responce = await Request.getInfo("http://watchlist-app-server.herokuapp.com/user?name=Dmitry Mazuro&password=12345");
                User currentUser = Json.Serialization_User(responce);

                var dlg = new MessageDialog(currentUser.name); 
                dlg.ShowAsync();
               
                
                this.Frame.Navigate(typeof(SecondPage));
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

        private void showCurrent(Movie current)  //temporary output
        {
            //titleBox.Text = current.Title;
            //overview.Text = current.overview;
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

    }
}
