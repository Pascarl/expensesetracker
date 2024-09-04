using SQLite;
using System.Diagnostics.CodeAnalysis;

namespace expensesetracker.Models.ExpensesModel
{
    [Table("EXPENSES")]
    public class EXPENSES
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int ID { get; set; }

        [Column("DateTime")]
        public DateTime DateTime { get; set; }

        [Column("Expenses")]
        [AllowNull]
        public double Expenses { get; set; }

        [Column("Expensesname")]
        [AllowNull]
        public string Expensesname { get; set; }

    }
}
