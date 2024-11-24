using System.Net;
using Library.Contracts.Domain;
using Library.Test.Utils.Tests.Api.Helpers;
using Library.Tests.Api.TestFixtures;
using Newtonsoft.Json;

namespace Library.Tests.Api.Endpoints.Books;

[TestFixture]
public class CreateBook : GlobalSetUp
{
    private Book? _book;
    private Book? _testBook;

    [OneTimeSetUp]
    public new async Task OneTimeSetUp()
    {
        await LibraryHttpService.CreateDefaultUser();
        await LibraryHttpService.AuthorizeLikeDefaultUser();
        //_book = DataHelper.CreateBook();
        _testBook = new Book
        {
            Author = "Author",
            Title = "Title",
            YearOfRelease = 1900
        };
        await LibraryHttpService.PostBook(_testBook);
    }

    [SetUp]
    public void SetUp()
    {
        _book = DataHelper.CreateBook();
    }

    [Test]
    public async Task CreateBook_WhenDataIsValid_ReturnCreated()
    {
        HttpResponseMessage response = await LibraryHttpService.PostBook(_book);

        var jsonString = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<Book>(jsonString);

        var booksDto = await MongoDbFixture.Books.GetItem(b => b.Title == books.Title);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(books.Title, Is.EqualTo(_book.Title));
            Assert.That(books.Author, Is.EqualTo(_book.Author));
            Assert.That(books.YearOfRelease, Is.EqualTo(_book.YearOfRelease));
            Assert.That(booksDto, Is.Not.Null);
            Assert.That(booksDto.Title, Is.EqualTo(_book.Title));
        });
    }

    [Test]
    public async Task CreateBook_WhenTokenIsInvalid_ReturnUnauthorized()
    {
        HttpResponseMessage response = await LibraryHttpService.PostBook("invalid", _book);

        var jsonString = await response.Content.ReadAsStringAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        });
    }

    //Create a new book with new title and author
    [Test]
    public async Task CreateBook_IfNewTitleAndNewAuthor_Return_Created()
    {
        //Act
        HttpResponseMessage response = await LibraryHttpService.PostBook(_book);
        var jsonResult = await response.Content.ReadAsStringAsync();
        var newBook = JsonConvert.DeserializeObject<Book>(jsonResult);

        //Asserts
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(newBook.Title, Is.EqualTo(_book.Title));
            Assert.That(newBook.Author, Is.EqualTo(_book.Author));
            Assert.That(newBook.YearOfRelease, Is.EqualTo(_book.YearOfRelease));
        });
    }

    //Create a new book with the same title but new author
    [Test]
    public async Task CreateBook_IfSameTitleNewAuthor_Return_Created()
    {
        //Assert
        _book.Title = "Title";

        //Act
        HttpResponseMessage response = await LibraryHttpService.PostBook(_book);
        var jsonResult = await response.Content.ReadAsStringAsync();
        var newBook = JsonConvert.DeserializeObject<Book>(jsonResult);

        //Asserts
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(newBook.Title, Is.EqualTo(_book.Title));
            Assert.That(newBook.Author, Is.EqualTo(_book.Author));
            Assert.That(newBook.YearOfRelease, Is.EqualTo(_book.YearOfRelease));
        });
    }

    //Create a book with new title but the same author
    [Test]
    public async Task CreateBook_IfNewTitleSameAuthor_Return_Created()
    {
        //Arrange
        _book.Author = "Author";

        //Act
        HttpResponseMessage response = await LibraryHttpService.PostBook(_book);
        var jsonResult = await response.Content.ReadAsStringAsync();
        var newBook = JsonConvert.DeserializeObject<Book>(jsonResult);

        //Asserts
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(newBook.Title, Is.EqualTo(_book.Title));
            Assert.That(newBook.Author, Is.EqualTo(_book.Author));
            Assert.That(newBook.YearOfRelease, Is.EqualTo(_book.YearOfRelease));
        });
    }

    //Create a book with the same title and author
    [Test]
    public async Task CreateBook_IfSameTitleAndAuthor_Return_BadRequest()
    {
        //Arrange
        _book = _testBook;

        //Act
        HttpResponseMessage response = await LibraryHttpService.PostBook(_book);
        var jsonResult = await response.Content.ReadAsStringAsync();

        //Asserts
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(jsonResult, Is.Not.Null);
        });
    }
}