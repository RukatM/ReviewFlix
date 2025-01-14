using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewFlixMobile.ViewModels;
using ReviewFlixMobile.Models;
using ReviewFlixMobile.Services;

namespace ReviewFlixMobile.Views
{
    public partial class FilmListPage : ContentPage
    {
        public FilmListPage(FilmListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnFilmTapped(object sender, EventArgs e)
        {
            var tappedEventArgs = (TappedEventArgs)e;
            var selectedFilm = tappedEventArgs.Parameter as Film;
            if (selectedFilm != null)
            {
                await Navigation.PushAsync(new FilmDetailsPage(new FilmDetailsViewModel(selectedFilm, new ApiService())));
            }
        }


    }
}