using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PhoneBook.Report.Application.Common.Interfaces;
using PhoneBook.Report.Domain.Entities;
using PhoneBook.Report.Infrastructure.Persistence.Settings;

namespace PhoneBook.Report.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    private IMongoDatabase _db { get; set; }
    private MongoClient _mongoClient { get; set; }

    public ApplicationDbContext(IOptions<MongoDbSettings> configuration)
    {
        _mongoClient = new MongoClient(configuration.Value.Connection);
        _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

        Report = _db.GetCollection<Domain.Entities.Report>(nameof(Domain.Entities.Report));
        ReportData = _db.GetCollection<ReportData>(nameof(ReportData));
    }

    public IMongoCollection<Domain.Entities.Report> Report { get; set; }
    public IMongoCollection<ReportData> ReportData { get; set; }
    
}