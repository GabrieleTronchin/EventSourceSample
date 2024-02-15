namespace EventSource.Application.Account.Events
{
    public class AccountCredited : Transaction
    {
        public override void Apply(Domain.Account account)
        {
            account.Balance += Amount;
        }

        public AccountDebited ToDebit()
        {
            return new AccountDebited
            {
                Amount = Amount,
                To = From,
                From = To,
                Description = Description
            };
        }

        public override string ToString()
        {
            return $"{Time} Credited {Amount.ToString("C")} From {From}";
        }
    }
}