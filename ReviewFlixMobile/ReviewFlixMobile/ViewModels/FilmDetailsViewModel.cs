using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReviewFlixMobile.Models;
using ReviewFlixMobile.Services;

namespace ReviewFlixMobile.ViewModels
{
    public partial class FilmDetailsViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public Film SelectedFilm { get; }

        public ObservableCollection<Review> Reviews { get; set; } = new();

        public ObservableCollection<Actor> Cast { get; set; } = new();
        public Finance Finance { get; set; }

        public FilmDetailsViewModel(Film selectedFilm, ApiService apiService)
        {
            SelectedFilm = selectedFilm;
            _apiService = apiService;
            LoadReviews();
            LoadCast();
            LoadFinance();
        }

        private async void LoadReviews()
        {
            try
            {
                var reviews = await _apiService.GetReviewsAsync(SelectedFilm.Id);
                Reviews.Clear();
                foreach (var review in reviews)
                {
                    Reviews.Add(review);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania recenzji: {ex.Message}");
            }
        }

        private async void LoadCast()
        {
            try
            {
                var cast = await _apiService.GetCastAsync(SelectedFilm.Id);
                Cast.Clear();
                foreach (var actor in cast)
                {
                    Cast.Add(actor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania obsady: {ex.Message}");
            }
        }

        private async void LoadFinance()
        {
            try
            {
                Finance = await _apiService.GetFinanceAsync(SelectedFilm.Id);
                OnPropertyChanged(nameof(Finance));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania finansów: {ex.Message}");
            }
        }
    }
}