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
using ReviewFlixMobile.Views;


namespace ReviewFlixMobile.ViewModels
{
    public partial class FilmListViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Film> Films { get; set; } = new();

        public FilmListViewModel(ApiService apiService)
        {
            _apiService = apiService;
            LoadFilms();
        }

        private async void LoadFilms()
        {
            try
            {
                var films = await _apiService.GetFilmsAsync();
                Films.Clear();
                foreach (var film in films)
                {
                    Films.Add(film);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania filmów: {ex.Message}");
            }
        }
    }
}
