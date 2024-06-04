using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PM0220242P.Models;



namespace PM0220242P.Controllers
{
    public class PersonasController
    {
        readonly SQLiteAsyncConnection _connection;

        public PersonasController()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
               //SQLite.SQLiteOpenFlags.ReadOnly |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPerson.db3"), extensiones);
            _connection.CreateTableAsync<Models.Personas>();
        }

        // Crud Methods

        // Create  //Update
        public async Task<int> StorePerson(Models.Personas personas)
        {
            if (personas.Id == 0)
            {
                return await _connection.InsertAsync(personas);
            }
            else
            {
                return await _connection.UpdateAsync(personas);
            }
        }

        //Read

        public async Task<List<Models.Personas>> GetListPersons()
        {
            return await _connection.Table<Models.Personas>().ToListAsync();
        }

        //

        public async Task<Models.Personas> GetPerson(int id)
        {
            return await _connection.Table<Models.Personas>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        //Delete
        public async Task<int> DeletePerson(Models.Personas person)
        {
            return await _connection.DeleteAsync(person);
        }
    }
}
