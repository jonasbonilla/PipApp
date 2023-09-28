using PipApp.Clases;
using PipApp.Interfaces;
using PipApp.Models;
using SQLite;

namespace PipApp.Services
{
    /// <summary>
    /// Servicio Datos
    /// </summary>
    public class SDataService : IDataService
    {
        SQLiteAsyncConnection Database;

        public async Task Init()
        {
            if (Database is not null) return;
            Database = new SQLiteAsyncConnection(CConstantes.DatabasePath, CConstantes.Flags);

            // crear N tablas desde una lista
            foreach (string tableName in CConstantes.TableNames())
            {
                Type modelType = Type.GetType($"NetMaui.Models.{tableName}");

                // Verifica si el modelo existe
                if (modelType != null)
                {
                    // Crea la tabla en la base de datos
                    await Database.CreateTableAsync(modelType);
                }
            }
        }

        private int GetIdValue<T>(T model)
        {
            // verificamos si modelo tiene la propiedad 'Id'
            var idProperty = typeof(T).GetProperty("Id") ??
                throw new InvalidOperationException("The model does not have an 'Id' property.");
            var idValue = (int)idProperty.GetValue(model);
            return idValue;
        }

        public async Task<T> GetItemAsync<T>(int id) where T : class
        {
            await Init();
            // Devolvemos la instancia cuyo 'Id' coincida con id
            return typeof(T).Name switch
            {
                nameof(MUser) => await Database.Table<MUser>().FirstOrDefaultAsync(item => item.Id == id) as T,
                _ => null,
            };
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>() where T : class
        {
            await Init();
            return typeof(T).Name switch
            {
                nameof(MUser) => (IEnumerable<T>)await Database.Table<MUser>().ToListAsync(),
                _ => new List<T>(),
            };
        }

        public async Task<int> SaveItemAsync<T>(T item) where T : class
        {
            await Init();
            if (GetIdValue(item) != 0) return await Database.UpdateAsync(item);
            return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync<T>(T item) where T : class
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
