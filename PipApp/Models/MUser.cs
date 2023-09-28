namespace PipApp.Models
{
    public class MUser : MBaseItem
    {
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
    }
}