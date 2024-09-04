using expensesetracker;
using expensesetracker.Models.DbService;
using expensesetracker.Models.IncomeModel;

namespace expensestracker
{
    public partial class MainPage : ContentPage
    {
        readonly DateTime DateTime = DateTime.UtcNow;
        private readonly ExpensesDB _expensesDB;
        
        public MainPage(ExpensesDB expensesDB)
        {
            InitializeComponent();
            _expensesDB = expensesDB;

        }

        private void Clear()
        {
            incomeNametxt.Text = string.Empty;
            incomeTotaltxt.Text = string.Empty;
        }
        private void ADDPAGE(object sender, EventArgs e)
        {
            Clear();
            Navigation.PushAsync(new ADD_PAGE(_expensesDB));
        }

        private void VIEWPAGE(object sender, EventArgs e)
        {
            Clear();
            Navigation.PushAsync(new VIEWINCOME_PAGE(_expensesDB));
        }

        private void ABOUTUS(object sender, EventArgs e)
        {
            Clear();
            Navigation.PushAsync(new ABOUT_US_PAGE());
        }

        private async void ADDbtn(object sender, EventArgs e)
        {
            if(incomeNametxt.Text == null)
            {
                await DisplayAlert("Error", "Please enter income name!", "OK");
            }
            else if (incomeTotaltxt.Text == null)
            {
                await DisplayAlert("Error", "Please enter income total!", "OK");

            }
            else
            {
                await _expensesDB.createincome(new Income
                {
                    DateTime = DateTime.UtcNow.Date,
                    IncomeName = incomeNametxt.Text,
                    IncomeTotal = Convert.ToInt32(incomeTotaltxt.Text)
                });
                Clear();
                await DisplayAlert("Information", "Income added successfully", "OK");
            }
        }
    }

}
