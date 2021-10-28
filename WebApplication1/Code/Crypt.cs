using Microsoft.AspNetCore.DataProtection;

namespace WebApplication1.Code
{
    public class Crypt
    {
        public string Encrypt(string payload, IDataProtector _protector)
        {
            return _protector.Protect(payload);
        }
        public string Decrypt(string ProtectedPayload, IDataProtector _protector)
        {
            return _protector.Unprotect(ProtectedPayload);
        }
    }
}
