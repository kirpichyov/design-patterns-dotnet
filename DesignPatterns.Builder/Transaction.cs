namespace DesignPatterns.Builder;

public sealed class Transaction
{
    public Guid Id { get; set; }
    public Guid ExternalId { get; set; }
    public decimal Amount { get; set; }
    public decimal? FeeAmount { get; set; }
    public decimal? Quote { get; set; }
    public string Note { get; set; }
    public string FromCardNumber { get; set; }
    public string ToCardNumber { get; set; }
    public string ToIbanAddress { get; set; }
    public string FromCryptoAddress { get; set; }
    public string ToCryptoAddress { get; set; }
    public string CryptoCoin { get; set; }
    public string CryptoNetwork { get; set; }
    public string Currency { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
}