namespace DesignPatterns.Builder;

public class TransactionBuilder
{
    // It also can be just fields or some object with editable properties.
    private readonly Transaction _transaction = new();

    public TransactionBuilder(DateTime createdAtUtc)
    {
        _transaction.CreatedAtUtc = createdAtUtc;
    }
    
    public TransactionBuilder AsSuccessful(DateTime dateTimeUtc)
    {
        _transaction.Status = TransactionStatus.Success;
        _transaction.CompletedAtUtc = dateTimeUtc;
        return this;
    }
    
    public TransactionBuilder AsFailed(DateTime dateTimeUtc)
    {
        _transaction.Status = TransactionStatus.Failed;
        _transaction.CompletedAtUtc = dateTimeUtc;
        return this;
    }

    public TransactionBuilder WithFiatAmount(decimal value, string currency)
    {
        _transaction.Amount = value;
        _transaction.Currency = currency;
        return this;
    }

    public TransactionBuilder WithNote(string note)
    {
        _transaction.Note = note;
        return this;
    }

    public TransactionBuilder FromCard(string cardNumber, decimal amount)
    {
        _transaction.FromCardNumber = cardNumber;
        _transaction.Amount = amount;
        return this;
    }
    
    public TransactionBuilder ToCard(string cardNumber)
    {
        _transaction.ToCardNumber = cardNumber;
        return this;
    }
    
    public TransactionBuilder ToIban(string address)
    {
        _transaction.ToIbanAddress = address;
        return this;
    }

    public TransactionBuilder WithFee(decimal fee)
    {
        _transaction.FeeAmount = fee;
        return this;
    }

    public CryptoTransactionBuilder AsCrypto() => new CryptoTransactionBuilder(_transaction);
    
    public Transaction Build() => _transaction;
}

public class CryptoTransactionBuilder
{
    private readonly Transaction _transaction;

    public CryptoTransactionBuilder(Transaction transaction)
    {
        _transaction = transaction;
    }

    public CryptoTransactionBuilder From(string cryptoAddress, decimal amount, string coin, string network)
    {
        _transaction.FromCryptoAddress = cryptoAddress;
        _transaction.Amount = amount;
        _transaction.CryptoCoin = coin;
        _transaction.CryptoNetwork = network;
        return this;
    }

    public CryptoTransactionBuilder WithQuote(decimal quote)
    {
        _transaction.Quote = quote;
        return this;
    }

    public CryptoTransactionBuilder To(string address)
    {
        _transaction.ToCryptoAddress = address;
        return this;
    }

    public Transaction Build() => _transaction;
}