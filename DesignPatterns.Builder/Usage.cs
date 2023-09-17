namespace DesignPatterns.Builder;

public class Usage
{
    public void Main()
    {
        Transaction fromCardToIban = new TransactionBuilder(DateTime.UtcNow)
            .FromCard("1234 1234 1234 1234", 12000.0m)
            .ToIban("UA213223130000026007233566001")
            .WithNote("Payment for education services for John Doe.")
            .WithFee(250m)
            .Build();

        Transaction crypto = new TransactionBuilder(DateTime.UtcNow.AddDays(-1))
            .AsSuccessful(DateTime.UtcNow)
            .AsCrypto()
            .From("0x131ewqfrmeituj32i5235325asdf", 50.25m, "usdc", "goerli")
            .To("0xegiiw5i925921i492kteg")
            .WithQuote(0.99998m)
            .Build();
    }
}