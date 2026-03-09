using Microsoft.Extensions.DependencyInjection;

namespace AppImcMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window w = new(new AppShell())
            {
                Height = 600,
                Width = 400
            };
            return w;
        }
    }
}