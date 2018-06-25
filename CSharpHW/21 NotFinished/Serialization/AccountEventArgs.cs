namespace Delegates
{
    public class AccountEventArgs
    {
        public string Message { get; set; }

        public int Id { get; set; }

        public AccountEventArgs(string message, int id)
        {
            Message = message;
            Id = id;
        }
    }
}
