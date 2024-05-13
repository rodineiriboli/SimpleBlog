namespace SimpleBlog.Application.Helpers
{
    public interface ICryptoPassHelper
    {
        string CreatePass(string pass, string salt);
        string CreateSaltSaltKey();
    }
}
