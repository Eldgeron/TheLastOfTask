using System.Net;
using Bogus;
using Library.Contracts.Domain;
using Library.Tests.Api.TestFixtures;
using Library.Test.Utils.Tests.Api.Helpers;
using Newtonsoft.Json;

namespace Library.Tests.Api.Endpoints.Books;

[TestFixture]
public class GetBooks : GlobalSetUp
{
    private Book? _testBook;
    private Book? _book;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        await LibraryHttpService.CreateDefaultUser();
        await LibraryHttpService.AuthorizeLikeDefaultUser();

        var faker = new Faker();
        _testBook = new Book
        {
            Author = "Kotaro Isaka",
            Title = faker.Random.AlphaNumeric(4),
            YearOfRelease = 2004
        };

        await LibraryHttpService.PostBook(_testBook);
    }

    [SetUp]
    public async Task SetUp()
    {
        _book = DataHelper.CreateBook();
        await LibraryHttpService.PostBook(_book);
    }

    [Test]
    public async Task GetBooksByTitle_WhenBookExists_ReturnOk()
    {
        HttpResponseMessage response = await LibraryHttpService.GetBooksByTitle(_testBook.Title);

        var jsonString = await response.Content.ReadAsStringAsync();

        var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books.Count, Is.GreaterThan(0));
            Assert.That(books[0].Title, Is.EqualTo(_testBook.Title));
            Assert.That(books[0].Author, Is.EqualTo("Kotaro Isaka"));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(2004));
        });
    }

    [Test]
    public async Task GetBooksByAuthor_WhenBookExists_ReturnOk()
    {
        HttpResponseMessage response = await LibraryHttpService.GetBooksByAuthor("Kotaro Isaka");

        var jsonString = await response.Content.ReadAsStringAsync();

        var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books.Count, Is.GreaterThan(0));
            Assert.That(books[0].Title, Is.EqualTo(_testBook.Title));
            Assert.That(books[0].Author, Is.EqualTo("Kotaro Isaka"));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(2004));
        });
    }

    //Get Book by Title If title exist return Ok
    [Test]
    public async Task GetBookByTitle_IfTitleExist_Return_Ok()
    {
        //Act
        HttpResponseMessage response = await LibraryHttpService.GetBooksByTitle(_testBook.Title);
        var jsonResult = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonResult);

        //aSSERT
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books.Count, Is.GreaterThan(0));
            Assert.That(books[0].Title, Is.EqualTo(_testBook.Title));
            Assert.That(books[0].Author, Is.EqualTo("Kotaro Isaka"));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(2004));
        });
    }

    //Get Book by title If title does not exist return Not Found
    [Test]
    public async Task GetBookByTitle_IfTitleNotExist_Return_NotFound()
    {
        //Arrange
        _book.Title = "NotExistingTitle";

        //Act
        HttpResponseMessage response = await LibraryHttpService.GetBooksByTitle(_book.Title);
        var jsonResult = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(jsonResult, Is.Not.Null);
        });
    }

    //Get Book By Author if Author exist return Ok
    [Test]
    public async Task GetBookByAuthor_IfAuthorExist_Return_Ok()
    {             //Arrange
        _book = _testBook;

        //Act
        HttpResponseMessage response = await LibraryHttpService.GetBooksByAuthor(author: _book.Author);
        var jsonResult = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonResult);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books.Count, Is.GreaterThan(0));
            Assert.That(books[0].Title, Is.EqualTo(_testBook.Title));
            Assert.That(books[0].Author, Is.EqualTo(_testBook.Author));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(_testBook.YearOfRelease));
        });
    }

    //Get Book by Author if Author does not exist return Not Foud
    [Test]
    public async Task GetBookByAuthor_IfAuthorNotExist_Return_NotFound()
    {
        //Arrange
        _book.Author = "NotExistingAuthor";

        //Act
        HttpResponseMessage response = await LibraryHttpService.GetBooksByAuthor(_book.Author);
        var jsonResult = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(jsonResult, Is.Not.Null);
        });
    }

    [OneTimeTearDown]
    public new async Task OneTimeTearDown()
    {
        await LibraryHttpService.DeleteBook(_testBook.Title, _testBook.Author);
    }
}