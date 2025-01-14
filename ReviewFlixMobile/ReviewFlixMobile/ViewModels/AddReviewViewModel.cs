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
    public partial class AddReviewViewModel : ObservableObject
    {
        private readonly int _filmId;
        private readonly ApiService _apiService;

        [ObservableProperty]
        private string reviewTitle;

        [ObservableProperty]
        private string reviewContent;

        [ObservableProperty]
        private int selectedRating; // Wybrana ocena

        public ObservableCollection<int> Ratings { get; set; } = new ObservableCollection<int> { 1, 2, 3, 4, 5 };

        public AddReviewViewModel(int filmId)
        {
            _filmId = filmId;
            _apiService = new ApiService();
            SelectedRating = 3; // Domyślna ocena
        }

        [RelayCommand]
        public async Task SubmitReviewAsync()
        {
            var newReview = new Review
            {
                FilmId = _filmId,
                Title = ReviewTitle,
                Content = ReviewContent,
                Rating = SelectedRating,
                DateAdded = DateTime.UtcNow
            };

            try
            {
                await _apiService.AddReviewAsync(newReview);

                
                await Application.Current.MainPage.Navigation.PopAsync();

                await Application.Current.MainPage.DisplayAlert("Success", "Your review has been added.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to add review: {ex.Message}", "OK");
            }
        }
    }
}
