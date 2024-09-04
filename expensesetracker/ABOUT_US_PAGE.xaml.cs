namespace expensestracker;

public partial class ABOUT_US_PAGE : ContentPage
{
	public ABOUT_US_PAGE()
	{
		InitializeComponent();
	}

	private void BACK(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}