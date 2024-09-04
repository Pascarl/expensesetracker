using System.Text;
using Microcharts;
using SkiaSharp;

namespace expensestracker;

public partial class ADD_PAGE : ContentPage
{
	public List<string> EXPENSES = new List<string>();
	public string entry = null;
	public string exp = null;
	public int cst = 0;
	public int income = 0;
	public int totalexp = 0;
	StringBuilder expenseslist = new StringBuilder();
	StringBuilder costlist = new StringBuilder();



    public ADD_PAGE()
	{
		InitializeComponent();

		
    }

	private void ADD(object sender, EventArgs e)
	{
		if (Exentry.Text == null)
		{
			DisplayAlert("alert", "Please enter a expense!", "ok");
		}
		else if (costen.Text == null)
		{
            DisplayAlert("alert", "Please enter a cost!", "ok");
        }
		else if (totalincome.Text == null)
		{
            DisplayAlert("alert", "Please enter total monthly income!", "ok");
        }
		else
		{
			totalexp = totalexp + (int)Convert.ToInt32(costen.Text);
			exp = Exentry.Text;
			cst = (int)Convert.ToInt32(costen.Text);
			costlist.Append(cst + "\n");
			expenseslist.Append(exp + "\n");
			exen.Text = expenseslist.ToString();
			cstlist.Text = costlist.ToString();
            income = Convert.ToInt32(totalincome.Text);
            totalafter.Text = (income - totalexp).ToString();
			Exentry.Text = null;
            costen.Text = null;

            ChartEntry[] entries = new[]
            {
                new ChartEntry(income - totalexp)
                {
                    Label = "Total After Expeneses",
                    ValueLabel = $"R{income - totalexp}",
                    Color = SKColor.Parse("2c3e50")
                },

                new ChartEntry(totalexp)
                {
					
                    Label = "EXPENSES",
                    ValueLabel =  $"R{totalexp}",
                    Color = SKColor.Parse("2c1e50")
                },

               
            };

			Chartview1.Chart = new PieChart
			{
				Entries = entries
			};
        }
	}

	private void cancel(object sender, EventArgs e) 
	{
		Exentry.Text = null;
		costen.Text = null;
		totalincome.Text = null;
		totalafter.Text = null;
    }

    private void save(object sender, EventArgs e)
	{

	}

	private void BACK(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}