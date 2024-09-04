using SQLite;

namespace expensesetracker.Models.IncomeModel
{
    [Table("INCOME")]
    public class Income
    {
        [Column("ID")]
        [AutoIncrement]
        [PrimaryKey]
        public int ID { get; set; }

        [Column("DateTime")]
        public DateTime DateTime { get; set; }

        [Column("IncomeTotal")]
        public double IncomeTotal { get; set; }

        [Column("IncomeName")]
        public string IncomeName { get; set; }
    }
}
