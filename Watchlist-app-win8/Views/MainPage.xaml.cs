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

        public MainPage()
        {
            Data.EventHandler = new Data.MyEvent(showGroup);
            Info.EventHandler = new Info.MyEvent(showCurrent);
            this.InitializeComponent();
            StartClass.start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        private void showGroup(Movies current)  //temporary output
        {

            _movies = current.results;
            foreach (var value in _movies)
                value.fullPosterPath += value.poster_path;
            gvMain.ItemsSource = _movies;           
        }

        private void showCurrent(Movie current)  //temporary output
        {
            
            titleBox.Text = current.Title;
            overview.Text = current.overview;
        }

        private async void gvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoviePreview temp = (MoviePreview)gvMain.SelectedItem;
            InfoLoader.getMoreInfo(temp.id);
        }

    }
}
