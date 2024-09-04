using expensesetracker.Models.DbService;
using Microcharts;
using SkiaSharp;
using expensesetracker.Models.ExpensesModel;
using expensesetracker.Models.IncomeModel;

namespace expensesetracker;

public partial class VIEWINCOME_PAGE : ContentPage
{
    double totalExpenses;
    double totalIncome;
    DateTime dateTime = DateTime.UtcNow.Date;
    private ExpensesDB _expensesDB;
    public VIEWINCOME_PAGE(ExpensesDB expensesDB)
	{
		InitializeComponent();
        _expensesDB = expensesDB;
        GetTotal();
	}

    private async void tappedExpense(object sender, EventArgs e)
    {
        string option = await DisplayActionSheet("Choose an option", "Delete", "Cancel");
        switch (option)
        {
            case "Delete":
                var delete = Incomelist.SelectedItem as Income;
                await _expensesDB.deleteincome(delete);
                GetTotal();
                break;
            case "Cancel":
                break;
        }
    }

    private async void selected(object sender, EventArgs e)
    {
        Incomelist.ItemsSource = await _expensesDB.getincomebydate(Datepick.Date);
    }

    private async void GetTotal()
    {
        List<EXPENSES> expenseslist = new List<EXPENSES>();
        List<Income> incomeslist = new List<Income>();
        expenseslist = await _expensesDB.getexpensesforMonth(Datepick.Date);
        incomeslist = await _expensesDB.getincomeforMonth(Datepick.Date);
        Incomelist.ItemsSource = await _expensesDB.getincomeforMonth(Datepick.Date);

        totalIncome = 0;
        totalExpenses = 0;

        foreach (EXPENSES Expense in expenseslist)
        {
            totalExpenses = totalExpenses + Expense.Expenses;
        }

        foreach (Income income in incomeslist)
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
}