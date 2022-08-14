using MongoDB.Driver;

namespace PhoneBook.Report.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    IMongoCollection<Domain.Entities.Report> Report { get; set; }
}