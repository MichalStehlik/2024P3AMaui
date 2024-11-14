using Bumptech.Glide.Util;

namespace Clock
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            this.Dispatcher.Dispatch(() => { lblClock.Text = DateTime.Now.ToString("HH:mm:ss"); });
            return true;
            /*
            Device.BeginInvokeOnMainThread(() =>
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            });
            return true;
            */
        }
    }

}
