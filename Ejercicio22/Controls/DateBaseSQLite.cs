using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ejercicio22.Models;
using SQLite;

namespace Ejercicio22.Controls
{
    public class DateBaseSQLite
    { 
    readonly SQLiteAsyncConnection db;


    //constructor de clase
    public DateBaseSQLite(string pathdb)
    {
        //crear la conexion de la base datos
        db = new SQLiteAsyncConnection(pathdb);
        //creacion de la tabla dentro de sqlite
        db.CreateTableAsync<SignatureModel>().Wait();
    }

    //Operaciones CRUD con SQLite
    //READ List Way
    public Task<List<SignatureModel>> ObtenerListaFirmas()
    {
        return db.Table<SignatureModel>().ToListAsync();
    }

    //Mostrar solo una persona
    public Task<SignatureModel> ObtenerFirmas(int pcodigo)
    {
        return db.Table<SignatureModel>()
            .Where(i => i.codigo == pcodigo)
            .FirstOrDefaultAsync();
    }

    //guardar persona
    public Task<int> GuardarFirma(SignatureModel firma)
    {
        if (firma.codigo != 0)
        {
            return db.UpdateAsync(firma);
        }
        else
        {
            return db.InsertAsync(firma);
        }



    }
    //Eliminar persona
    public Task<int> EliminarFirma(SignatureModel firma)
    {
        return db.DeleteAsync(firma);
    }


}
}

