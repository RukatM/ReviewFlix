using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewFlixMobile.ViewModels;

namespace ReviewFlixMobile.Views
{
    public partial class AddReviewPage : ContentPage
    {
        public AddReviewPage(int filmId)
        {
            InitializeComponent();
            BindingContext = new AddReviewViewModel(filmId);
        }
    }

}
