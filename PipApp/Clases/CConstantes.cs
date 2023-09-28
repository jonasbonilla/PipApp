using PipApp.Models;

namespace PipApp.Clases
{
    public static class CConstantes
    {
        /// <summary>
        /// Nombre de la BD sqlite
        /// </summary>
        public const string DatabaseFilename = "NetMaui.db3";

        /// <summary>
        /// Opciones para la creación de la BD sqlite
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// Ruta donde se crea la BD sqlite
        /// </summary>
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        /// <summary>
        /// Auxiliar para crear las tablas (basado en los nombres de los modelos indicados)
        /// </summary>
        /// <returns></returns>
        public static List<string> TableNames() => new List<string> {
            nameof(MUser) };
    }
}