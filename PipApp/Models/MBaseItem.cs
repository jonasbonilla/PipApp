using SQLite;

namespace PipApp.Models
{
    /// <summary>
    /// Modelo base para las tablas que usaremos en sqlite (campos comunes)
    /// </summary>
    public class MBaseItem
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Descripcion { get; set; }
    }
}