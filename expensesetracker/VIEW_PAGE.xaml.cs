namespace expensestracker;

public partial class VIEW_PAGE : ContentPage
{
	public VIEW_PAGE()
	{
		InitializeComponent();
	}

	private void BACK(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}