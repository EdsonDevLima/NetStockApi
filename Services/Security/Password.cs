using Microsoft.AspNetCore.Identity;

namespace NetStock.Services
{
    public class PasswordHasher
    {

        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password)
        {

            return _hasher.HashPassword(null, password);

        }

        public bool Verify(string plainPassword, string hashedPassword)
        {

            var result = _hasher.VerifyHashedPassword(null, hashedPassword, plainPassword);

            return result == PasswordVerificationResult.Success;
        }





    }
}