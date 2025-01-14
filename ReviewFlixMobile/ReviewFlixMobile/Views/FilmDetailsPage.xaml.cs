using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewFlixMobile.ViewModels;
using ReviewFlixMobile.Models;


namespace ReviewFlixMobile.Views
{

    public partial class FilmDetailsPage : ContentPage
    {
        public FilmDetailsPage(FilmDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnAddReviewClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as FilmDetailsViewModel;
            if (viewModel != null)
            {
                await Navigation.PushAsync(new AddReviewPage(viewModel.SelectedFilm.Id));
            }
        }
    }
}
