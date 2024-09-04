using System.Data.Common;

internal class SqlClientFactory
{
    public static DbProviderFactory Instance { get; set; }
}