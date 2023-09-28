namespace PipApp.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio Datos
    /// </summary>
    public interface IDataService
    {
        Task Init();
        Task<T> GetItemAsync<T>(int id) where T : class;
        Task<IEnumerable<T>> GetItemsAsync<T>() where T : class;
        Task<int> SaveItemAsync<T>(T item) where T : class;
        Task<int> DeleteItemAsync<T>(T item) where T : class;
    }
}