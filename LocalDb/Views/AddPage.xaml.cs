using LocalDb.ViewModels;

namespace LocalDb.Views;

[QueryProperty("Item", "Item")]
public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
        BindingContext = (Application.Current.MainPage as AppShell).MVM;
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void Save_Clicked(object sender, EventArgs e)
    {
        (BindingContext as MainViewModel).AddCommand.Execute(null);
        Shell.Current.GoToAsync("..");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}