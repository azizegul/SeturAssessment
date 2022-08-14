namespace PhoneBook.Contact.Test;

public class PersonHandlerTest
{
    private static Guid _personId = Guid.NewGuid();

    private List<Person> _personList = new()
    {
        new Person()
        {
            Id = _personId,
            Name = "Azize",
            Surname = "Aydoğdu",
            Company = "Setur"
        },
        new Person()
        {
            Id = new Guid(),
            Name = "Gül",
            Surname = "Kara",
            Company = "Ds",
        }
    };

    [Fact]
    public void GetPersonsQuery_Should_Return_Person_List()
    {
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(k => k.Persons).ReturnsDbSet(_personList);

        var getPersonsQueryHandler = new GetPersonsQueryHandler(mockContext.Object);

        var result = getPersonsQueryHandler.Handle(new GetPersonsQuery(), new CancellationToken()).Result;

        Assert.True(result.Count > 0);
    }

    [Fact]
    public void GetPersonQuery_Should_Return_Person()
    {
        var mockContext = new Mock<IApplicationDbContext>();
        mockContext.Setup(k => k.Persons).ReturnsDbSet(_personList);

        var getPersonQueryHandler = new GetPersonQueryHandler(mockContext.Object);

        var result = getPersonQueryHandler.Handle(new GetPersonQuery(_personId), new CancellationToken()).Result;

        Assert.True(result.FullName == result.Name + " " + result.Surname);
    }
}