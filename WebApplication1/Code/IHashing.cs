namespace WebApplication1.Code;

    public interface IHashing
    {
        public string MDHash(string valueToHash);
        public string BcryptHash(string valueToHash);
    }

