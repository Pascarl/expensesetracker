namespace expensestracker
{
    public partial class MainPage : ContentPage
    {
        readonly DateTime DateTime = DateTime.UtcNow;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ADDPAGE(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ADD_PAGE());
        }

        private void VIEWPAGE(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VIEW_PAGE());
        }

        private void ABOUTUS(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ABOUT_US_PAGE());
        }
    }

}
