using MongoDB.Driver;

internal class MongoConnectionStringBuilder
{
    private object connectionString;

    public MongoConnectionStringBuilder(object connectionString)
    {
        this.connectionString = connectionString;
    }

    public MongoClientSettings ConnectionString { get; internal set; }
    public string DatabaseName { get; internal set; }
}