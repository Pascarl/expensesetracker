using expensesetracker.Models.DbService;
using expensesetracker.Models.ExpensesModel;
using expensesetracker.Models.IncomeModel;
using Microcharts;
using SkiaSharp;

namespace expensestracker;

public partial class ADD_PAGE : ContentPage
{
	double totalExpenses;
	double totalIncome;
    DateTime dateTime = DateTime.UtcNow.Date;
    private ExpensesDB _ExpensesDB;

	public ADD_PAGE(ExpensesDB expensesDB)
	{
		InitializeComponent();
		_ExpensesDB = expensesDB;
		GetTotal();
	}

	// displays actionsheet for selected expense //
	private async void tappedExpense(object sender, EventArgs e)
	{
		string option = await DisplayActionSheet("Choose an option", "Delete", "Cancel");
		switch(option)
		{
			case "Delete":
				var delete = Expenseslist.SelectedItem as EXPENSES;
				await _ExpensesDB.deleteexpenses(delete);
				GetTotal();
                break;
			case "Cancel":
				break;
		}
    }

	// gets expenses by date //
    private async void selected(object sender, EventArgs e)
    {
        Expenseslist.ItemsSource = await _ExpensesDB.getexpensesforMonth(Datepick.Date);
    }

	// gets total income after expenses and displays results as a pie chart //
    private async void GetTotal()
    {
        List<EXPENSES> expenseslist = new List<EXPENSES>();
		List<Income> incomeslist = new List<Income>();
		expenseslist = await _ExpensesDB.getexpensesforMonth(Datepick.Date);
		incomeslist = await _ExpensesDB.getincomeforMonth(Datepick.Date);
        Expenseslist.ItemsSource = await _ExpensesDB.getexpensesforMonth(Datepick.Date);

        totalIncome = 0;
        totalExpenses = 0;

        foreach (EXPENSES Expense in expenseslist)
		{
			 totalExpenses = totalExpenses + Expense.Expenses;
		}

        foreach (Income income  in incomeslist)
        {
            totalIncome = totalIncome + income.IncomeTotal;
        }

		TOTAL.Text = (totalIncome - totalExpenses).ToString();
        ChartEntry[] entries = new[]
        {
        new ChartEntry(Convert.ToInt32(totalExpenses))
        {
            Label = "EXPENSES",
            ValueLabel = $"R{totalExpenses}",
            Color = SKColor.Parse("2c1e50")
        },
        new ChartEntry(Convert.ToInt32(totalIncome))
        {
            Label = "INCOME",
            ValueLabel = $"R{totalIncome}",
            Color = SKColor.Parse("2c3e50")
        },
    };

        Chartview1.Chart = new PieChart
        {
            Entries = entries
        };
    }

	// clears entry fields //
    private void ClearFunc()
	{
        Exentry.Text = null;
        costen.Text = null;
    }

	// adds a new expense //
	private async void ADD(object sender, EventArgs e)
	{
        if (Exentry.Text == null)
		{
			await DisplayAlert("alert", "Please enter a expense!", "ok");
		}
		else if (costen.Text == null)
		{
            await DisplayAlert("alert", "Please enter a cost!", "ok");
        }
		else
		{
			await _ExpensesDB.createexpenses(new EXPENSES()
			{
				DateTime = Datepick.Date,
				Expenses = Convert.ToInt32(costen.Text),
				Expensesname = Exentry.Text,
			});
			ClearFunc();
            GetTotal();
        }
	}

	// clears entry fields //
	private void cancel(object sender, EventArgs e) 
	{
		Exentry.Text = null;
		costen.Text = null;
    }

	// navigates back to the home page //
	private void BACK(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

}