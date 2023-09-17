using DesignPatterns.Bridge.ConcreteDataSources;
using DesignPatterns.Bridge.ConcreteRenderers;

namespace DesignPatterns.Bridge;

public class Usage
{
    public static async Task Main()
    {
        var mongoToHtmlBridge = new TransactionsReportsService(new MongoDbDataSource(), new HtmlRenderer());
        var html = await mongoToHtmlBridge.GetStringRepresentation("some bson query here");

        var postgreSqlToJsonBridge = new TransactionsReportsService(new PostgreSqlDbDataSource(), new JsonRenderer());
        var json = await postgreSqlToJsonBridge.GetStringRepresentation("some sql query here");
    }
}