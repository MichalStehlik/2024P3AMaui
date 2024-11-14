using System.ComponentModel;

namespace BindingDemo
{
    public partial class MainPage : ContentPage
    {
        private int _value = 33;
        private int _value2 = 44;

        public MainPage()
        {
            InitializeComponent();
            sliValue.Value = _value;
            lblValue.Text = sliValue.Value.ToString();
        }

        private void sliValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _value = (int)e.NewValue;
            //lblValue.Text = e.NewValue.ToString();
        }

        private void sliValue2_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }

}
