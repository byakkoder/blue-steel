namespace Byakkoder.BlueSteel.ServerApp
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Byakkoder.BlueSteel.ServerApp" };
        }
    }
}
