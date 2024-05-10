namespace SimpleBlog.Domain.Enums
{
    public class SignInResultEnum
    {
        private static readonly SignInResultEnum _success = new SignInResultEnum { Succeeded = true };
        private static readonly SignInResultEnum _failed = new SignInResultEnum();

        public bool Succeeded { get; protected set; }
        public static SignInResultEnum Success => _success;
        public static SignInResultEnum Failed => _failed;

        public override string ToString()
        {
            return Succeeded ? "Succeeded" : "Failed";
        }
    }
}
