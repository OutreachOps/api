namespace OutreachOperations.Api.Domain.Security
{
    interface PasswordHash
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }

    public class BCryptPasswordHash : PasswordHash
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
