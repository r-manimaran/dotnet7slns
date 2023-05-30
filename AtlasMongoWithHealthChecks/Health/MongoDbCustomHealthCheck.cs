using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AtlasMongoWithHealthChecks.Health;

public class MongoDbCustomHealthCheck : IHealthCheck
{
    private readonly ILogger<MongoDbCustomHealthCheck> _logger;
    private readonly IOptions<DatabaseSettings> _dbSettings;

    public MongoDbCustomHealthCheck(ILogger<MongoDbCustomHealthCheck> logger,
                                    IOptions<DatabaseSettings> dbSettings)
    {
        _logger = logger;
        _dbSettings = dbSettings;
    }
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await IsHealthy();
            return HealthCheckResult.Healthy();
        }
        catch(Exception ex)
        {
            _logger.LogError($"Exception:{ex.ToString()}");
            return HealthCheckResult.Unhealthy();

        }
    }

    private async Task IsHealthy()
    {
        string connectionString = _dbSettings.Value.ConnectionString;
        string dbName = _dbSettings.Value.DatabaseName;

        MongoUrl mongoUrl = new MongoUrl(connectionString);
        IMongoDatabase dbInstance = new MongoClient(mongoUrl)
                                    .GetDatabase(dbName)
                                    .WithReadPreference(new ReadPreference(ReadPreferenceMode.Secondary));
        _ = await dbInstance.RunCommandAsync<BsonDocument>(new BsonDocument { { "ping", 1 } });
    }
}
