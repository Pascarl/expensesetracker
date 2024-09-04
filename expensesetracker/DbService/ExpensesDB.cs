using expensesetracker.Models.ExpensesModel;
using expensesetracker.Models.IncomeModel;
using SQLite;


namespace expensesetracker.Models.DbService
{
    public class ExpensesDB
    {
        private const string DB_NAME = "ExpensesDB.db3";
        private readonly SQLiteAsyncConnection _connection;
        public string dateTime;
        public string Dbpath = Path.Combine(FileSystem.AppDataDirectory,DB_NAME); 
        public ExpensesDB()
        {
            _connection = new SQLiteAsyncConnection(Dbpath);
            _connection.CreateTableAsync<EXPENSES>();
            _connection.CreateTableAsync<Income>();

        }

        // crud fuctions for Income table //
        public async Task<List<EXPENSES>> getexpensesbydate(DateTime date)
        {
            DateTime check = date.Date; 
            return await _connection.Table<EXPENSES>().Where(x => x.DateTime == check).ToListAsync();
        }

        public async Task<List<EXPENSES>> getexpensesforMonth(DateTime date)
        {
            DateTime check = date.Date;
            DateTime start = new DateTime(date.Year, date.Month, 01);
            return await _connection.Table<EXPENSES>().Where(x => x.DateTime >= start && x.DateTime <= check).ToListAsync();
        }

        public async Task createexpenses(EXPENSES exp)
        {
            await _connection.InsertAsync(exp);
        }

        public async Task updateexpenses(EXPENSES exp)
        {
            await _connection.UpdateAsync(exp);
        }

        public async Task deleteexpenses(EXPENSES exp)
        {
            if (exp != null)
            {
                await _connection.DeleteAsync(exp);

            }
        }

        // crud fuctions for Income table //
        public async Task<List<Income>> getincomebydate(DateTime date)
        {
            DateTime check = date.Date;
            return await _connection.Table<Income>().Where(x => x.DateTime == check).ToListAsync();
        }

        public async Task<List<Income>> getincomeforMonth(DateTime date)
        {
            DateTime check = date.Date;
            DateTime start = new DateTime(date.Year, date.Month, 01);
            return await _connection.Table<Income>().Where(x => x.DateTime >= start && x.DateTime <= check).ToListAsync();
        }

        public async Task createincome(Income exp)
        {
            await _connection.InsertAsync(exp);
        }

        public async Task updateincome(Income exp)
        {
            await _connection.UpdateAsync(exp);
        }

        public async Task deleteincome(Income exp)
        {
            if (exp != null)
            {
                await _connection.DeleteAsync(exp);

            }
        }
    }
}
