using Library.Test.Utils.Tests.Ui.Fixtures;
using Library.Test.Utils.Tests.Ui.PageObjects;
using NUnit.Framework.Interfaces;

namespace Library.Tests.Ui.Tests;

[TestFixture]
public class WebTablePageTests
{
    private readonly BrowserSetUpBuilder _browserSetUp = new();
    private WebTablePage Page { get; set; }

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Page = await _browserSetUp
            .WithBrowser(BrowserType.Chromium)
            .WithChannel("chrome")
<<<<<<< HEAD
            .InHeadlessMode(false)
=======
            .InHeadlessMode(true)
>>>>>>> bdfedbb27f6c9eb7883d05d7d7ba1be0f09aed19
            .WithSlowMo(100)
            .WithTimeout(10000)
            .WithVideoSize(1900, 1080)
            .SaveVideo("videos/")
            .WithArgs("--start-maximized")
            .OpenNewPage<WebTablePage>();
        _browserSetUp.AddRequestResponseLogger();
        await Page.Open();
    }

    [SetUp]
    public async Task SetUp()
    {
        var traceName = TestContext.CurrentContext.Test.ClassName + "/" + TestContext.CurrentContext.Test.Name;
        await _browserSetUp.StartTracing(traceName);
    }

    [Test]
    public async Task CheckIfWebTablePageDisplayed()
    {
        var title = await Page.Title.TextContentAsync();
        Assert.That(title, Is.EqualTo("Web Tables"));
        Assert.That(title, Is.EqualTo(Page.ExpectedTitle));
    }

    
    [Test]
    public async Task AddNewRecord()
    {
        await Page.AddNewRecord();

        var searchValue = Page.NRFirstName;
        await Page.Search(searchValue);

        var tableContent = await Page.Table.InnerTextAsync();
        bool isRecordInTable = !string.IsNullOrEmpty(tableContent) && 
            tableContent.Contains(Page.NRFirstName) && 
            tableContent.Contains(Page.NRLastName) && 
            tableContent.Contains(Page.NREmail) && 
            tableContent.Contains(Page.NRAge) && 
            tableContent.Contains(Page.NRSalary) && 
            tableContent.Contains(Page.NRDepartment);

        Assert.That(isRecordInTable, Is.True);
    }

    [Test]
    public async Task DeleteCierraRecord()
    {
        Page.NRFirstName = "Cierra";
        await Page.Search(Page.NRFirstName);
        await Page.DeleteCierraBtn.ClickAsync();
        await Page.Search(Page.NRFirstName);
        var tableContent = await Page.Table.InnerTextAsync();
        bool isRecordInTable = !string.IsNullOrEmpty(tableContent) &&
            tableContent.Contains(Page.NRFirstName) &&
            tableContent.Contains(Page.NRLastName) &&
            tableContent.Contains(Page.NREmail) &&
            tableContent.Contains(Page.NRAge) &&
            tableContent.Contains(Page.NRSalary) &&
            tableContent.Contains(Page.NRDepartment);
        Assert.That(isRecordInTable, Is.False);
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            await _browserSetUp.Screenshot(
                TestContext.CurrentContext.Test.ClassName,
                TestContext.CurrentContext.Test.Name);
        }

        var tracePAth = Path.Combine(
            "playwright-traces",
            $"{TestContext.CurrentContext.Test.ClassName}",
            $"{TestContext.CurrentContext.Test.Name}.zip");
        await _browserSetUp.StopTracing(tracePAth);
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _browserSetUp.Page!.CloseAsync();
        await _browserSetUp.Context!.CloseAsync();
    }
}