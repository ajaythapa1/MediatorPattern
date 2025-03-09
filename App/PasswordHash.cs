namespace MediatorR.App
{
    public class PasswordHash
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);    
        }

        public static bool VerifyPassword(string enteredPassword , string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }
    }
}
