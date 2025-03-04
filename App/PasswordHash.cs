namespace MediatorR.App
{
    public class PasswordHash
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);    
        }
    }
}
