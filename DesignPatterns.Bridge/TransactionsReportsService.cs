using DesignPatterns.Bridge.Models;

namespace DesignPatterns.Bridge;

public class TransactionsReportsService
{
    private readonly IDataSource _dataSource;
    private readonly IDataRenderer _dataRenderer;

    public TransactionsReportsService(IDataSource dataSource, IDataRenderer dataRenderer)
    {
        _dataSource = dataSource;
        _dataRenderer = dataRenderer;
    }

    public async Task<string> GetStringRepresentation(string query)
    {
        var data = await _dataSource.GetAsync<Transaction>(query);
        var dataAsString = await _dataRenderer.RenderToStringAsync(data);

        return dataAsString;
    }
}