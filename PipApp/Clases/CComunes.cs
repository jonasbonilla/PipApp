namespace PipApp.Clases
{
    public enum TipoPlataforma
    {
        Windows,
        Android,
        Ios
    }

    /// <summary>
    /// Comunes
    /// </summary>
    public static class CComunes
    {
        /// <summary>
        /// Para saber si la plataforma sobre la que está corriendo es iOS
        /// </summary>
        public static TipoPlataforma Plataforma { get; set; }

        /// <summary>
        /// Para saber si la plataforma sobre la que está corriendo tiene lector de huellas
        /// </summary>
        public static bool HasFingerprint { get; set; }
    }
}