using Prism;
using Prism.Ioc;
using HealthyLifeApp.ViewModels;
using HealthyLifeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HealthyLifeApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();

            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<Exercise, ExerciseViewModel>();
            containerRegistry.RegisterForNavigation<Articles, ArticlesViewModel>();
            
            containerRegistry.RegisterForNavigation<ActivityHistory, ActivityHistoryViewModel>();
            containerRegistry.RegisterForNavigation<Journal, JournalViewModel>();
        }
    }
}
