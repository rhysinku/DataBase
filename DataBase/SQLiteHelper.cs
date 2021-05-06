using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace DataBase
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper (string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Person>().Wait();
        }

        // insert & update
        public Task<int> SaveItemAsync (Person person)
        {
            if (person.PersonID != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
            
        }

        // delete
        public Task<int> DeleteItemAsync (Person person)
        {
            return db.DeleteAsync(person);
        }

        //read all
        public Task<List<Person>> GetItemsAsync()
        {
            return db.Table<Person>().ToListAsync();
        }

        //read item
        public Task<Person> GetItemAsync (int personId)
        {
            return db.Table<Person>().Where(i => i.PersonID == personId).FirstOrDefaultAsync();
        }
        
        public Task<int> DeleteAll <T>()
        {
            return db.DeleteAllAsync<Person>();
        }

    }
}
