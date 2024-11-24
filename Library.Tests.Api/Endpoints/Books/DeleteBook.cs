using System.Net;
using Library.Contracts.Domain;
using Library.Test.Utils.Tests.Api.Helpers;
using Library.Tests.Api.TestFixtures;

namespace Library.Tests.Api.Endpoints.Books;

[TestFixture]
public class DeleteBook : GlobalSetUp
{
    private Book? _book;
    private Book? _testBook;

    [OneTimeSetUp]
    public new async Task OneTimeSetUp()
    {
        await LibraryHttpService.CreateDefaultUser();
        await LibraryHttpService.AuthorizeLikeDefaultUser();
    }

    [SetUp]
    public async Task SetUp()
    {
        _book = DataHelper.CreateBook();
        await LibraryHttpService.PostBook(_book);
    }

    [Test]
    public async Task DeleteBook_WhenBookExists_ReturnOk()
    {
        var newBook = new Book()
        {
            Title = "ToDelete",
            Author = "None"
        };

        var bookCreated = await LibraryHttpService.PostBook(newBook);
        HttpResponseMessage response = await LibraryHttpService.DeleteBook(newBook.Title, newBook.Author);
        var jsonString = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(jsonString.Contains("ToDelete by None deleted"));
        });
    }

    //Delete book if book exist in library return Ok
    [Test]
    public async Task DeleteBook_IfExistInLibrary_return_Ok()
    {
        //Arrange
        _testBook = _book;

        //Act
        HttpResponseMessage response = await LibraryHttpService.DeleteBook(_testBook.Title, _testBook.Author);
        var jsonResult = await response.Content.ReadAsStringAsync();

        //Asserts
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(jsonResult, Is.Not.Null);
        });
    }

    //Delete book if book does not exist return not found
    [Test]
    public async Task DeleteBook_IfNotExistInLibrary_return_NotFound()
    {
        //Arrange 
        _testBook = new Book
        {
            Title = "NotExistingTitle",
            Author = "NotExistingAuthor",
            YearOfRelease = 1900
        };

        //Act
        HttpResponseMessage response = await LibraryHttpService.DeleteBook(_testBook.Title, _testBook.Author);
        var jsonResult = await response.Content.ReadAsStringAsync();

        //Assets
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(jsonResult, Is.Not.Null);
        });
    }
}