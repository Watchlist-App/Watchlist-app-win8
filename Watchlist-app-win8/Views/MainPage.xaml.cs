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
using System.Net.Http;
using System.Threading.Tasks;

using Watchlist_app_win8.Views;
using Watchlist_app_win8.DataFetchers;


// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Watchlist_app_win8
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string URL = "https://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            String jsonResponse = await response.Content.ReadAsStringAsync();
            textBox1.Text = jsonResponse;
           // Movie myMovies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Movie>(jsonResponse);
           // Movie CurrentMovie = JsonConvert.DeserializeObject<Movie>(jsonResponse);
        }
    }
}


/*
 public async void PerformHttpGet(string url,out string responseText)
    {
        int respCode = 0;
        try
        {
            // used to build entire input
            StringBuilder sb = new StringBuilder();

            // used on each read operation
            byte[] buf = new byte[8192];

            // prepare the web page we will be asking for
            HttpClient searchClient;
            searchClient = new HttpClient();
            searchClient.MaxResponseContentBufferSize = 256000;
            HttpResponseMessage response = await searchClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseText = await response.Content.ReadAsStringAsync();
        }
        catch (WebException e)
        {
            string text = string.Empty;
            string outRespType = string.Empty;
            if (e.Response != null)
            {
                using (WebResponse response = e.Response)
                {
                    outRespType = response.ContentType;
                    HttpWebResponse exceptionResponse = (HttpWebResponse)response;
                    respCode = (int)exceptionResponse.StatusCode;

                    using (System.IO.Stream data = response.GetResponseStream())
                    {
                        text = new System.IO.StreamReader(data).ReadToEnd();
                    };
                };
            }
            throw e;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }     
*/