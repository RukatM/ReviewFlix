using Microsoft.Extensions.DependencyInjection;
using ReviewFlixMobile.Views;

namespace ReviewFlixMobile
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new NavigationPage(serviceProvider.GetRequiredService<FilmListPage>());
        }
    }
}
