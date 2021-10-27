namespace WebApplication1.Code;

using System.Security.Cryptography;
using System.Text;
public class Hashing : IHashing
{
    public string MDHash(string valueToHash)
    {
        byte[] valueAsBytes = ASCIIEncoding.ASCII.GetBytes(valueToHash);
        byte[] hashedMD5 = MD5.HashData(valueAsBytes);
        string hashedValueAsString = Convert.ToBase64String(hashedMD5);
        return hashedValueAsString;
    }

    public string BcryptHash(string valueToHash)
    {
        String hashed = BCrypt.Net.BCrypt.HashPassword(valueToHash, BCrypt.Net.SaltRevision.Revision2Y);
        return hashed;
    }
    ////private string? _text;

    ////public string? GetText(string txt)
    ////{
    ////    return _text;
    ////}

    ////public void SetText(string txt)
    ////{
    ////    _text = txt;
    //}
    //public string NewText { get; set; }
    //public Hashing(string txt) => (NewText) = (txt);
    //public string Text() => "My Text here";
}