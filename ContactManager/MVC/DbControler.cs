//Author Iliya Popov 12.12.2023
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace ContactManager.MVC
{
    public class DbControler
    {
        private readonly SQLiteAsyncConnection connSqliteDb;
        public DbControler(string dbFilePath)
        {
            this.connSqliteDb = new SQLiteAsyncConnection(dbFilePath);
            this.connSqliteDb.CreateTableAsync<DbCitizensModelTbl>();
        }
        public Task<int> InsertCitizensData(DbCitizensModelTbl citizens)
        {
            return this.connSqliteDb.InsertAsync(citizens);
        }
        public Task<List<DbCitizensModelTbl>> ReadCitizensTbl()
        {
            return this.connSqliteDb.Table<DbCitizensModelTbl>().ToListAsync();
        }
        public Task <int> UpdateCitizensData(DbCitizensModelTbl citizens)
        {
            return this.connSqliteDb.UpdateAsync(citizens);
        }
        public Task<int> DeleteCitizensData(DbCitizensModelTbl citizens)
        {
            return this.connSqliteDb.DeleteAsync(citizens);
        }
        public Task<List<DbCitizensModelTbl>>SearchCitizensData(string value)
        {
            return this.connSqliteDb.Table<DbCitizensModelTbl>().Where(citizen=>citizen.Names.StartsWith(value)).ToListAsync();
        }
    }
}
