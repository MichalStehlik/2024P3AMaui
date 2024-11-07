namespace NavigationFree
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DogsPage());
        }

        private void DogsBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//DogsPage");
        }
    }

}
