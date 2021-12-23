using PM2E3201810070111.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E3201810070111.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Pagos>().Wait();
        }

        //Operaciones crud de sqlite
        //Read List way
        public Task<List<Pagos>> ObtenerListaPagos()
        {
            return db.Table<Pagos>().ToListAsync();
        }

        //read one by one 
        public Task<Pagos> ObtenerPagos(int pcodigo)
        {
            return db.Table<Pagos>()
                .Where(i => i.Id_pago == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create o update personas
        public Task<int> GrabarPagos(Pagos empl)
        {
            if (empl.Id_pago != 0)
            {
                return db.UpdateAsync(empl);
            }
            else
            {
                return db.InsertAsync(empl);
            }

        }



        //delete
        public Task<int> EliminarPagos(Pagos emp)
        {
            return db.DeleteAsync(emp);
        }
    }
}
