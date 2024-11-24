namespace Library.Tests.Ui.Tests;
<<<<<<< HEAD

//TODO: cover with tests
[TestFixture]
public class RadioButtonPageTests
{
}
=======
using Library.Test.Utils.Tests.Ui.Fixtures;
using Library.Test.Utils.Tests.Ui.PageObjects;
using static Library.Test.Utils.Tests.Ui.Fixtures.BrowserType;
using Microsoft.Playwright;

[TestFixture]
public class RadioButtonPageTests
{
    private readonly BrowserSetUpBuilder _browserSetUp = new();
    private RadioButtonPage Page { get; set; }

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Page = await _browserSetUp
            .WithBrowser(Chromium)
            .InHeadlessMode(true)
            .WithChannel("chrome")
            .WithSlowMo(100)
            .WithTimeout(10000)
            .WithViewportSize(1900, 1080)
            .WithVideoSize(1900, 1080)
            .SaveVideo("videos/")
            .WithArgs("--start-maximized")
            .OpenNewPage<RadioButtonPage>();
        _browserSetUp.AddRequestResponseLogger();
        await Page!.Open();
    }
    [Test]
    public async Task ChecjIfRadioButtonPageDisplayed()
    {
        var title = await Page.Title.TextContentAsync();
        Assert.That(title, Is.EqualTo("Radio Button"));
        Assert.That(title, Is.EqualTo(Page.ExpectedTitle));
    }
    [Test]
    public async Task CheckIfAllLabelsAreDisplayed()
    {
        var yesRadioButtonText = await Page.YesRadioButtonText.TextContentAsync();
        var impressiveRadioButtonText = await Page.ImpressiveRadioButtonText.TextContentAsync();
        var noRadioButtonText = await Page.NoRadioButtonText.TextContentAsync();
        Assert.Multiple(() =>
        {
            Assert.That(yesRadioButtonText, Is.EqualTo("Yes"));
            Assert.That(impressiveRadioButtonText, Is.EqualTo("Impressive"));
            Assert.That(noRadioButtonText, Is.EqualTo("No"));
        });
    }
    [Test]
    [TestCase("Yes")]
    [TestCase("Impressive")]
    public async Task CheckIfRadioButtonIsClickable(string buttonName)
    {
        var result = await Page.CheckIfButtonIsClicable(buttonName);

        Assert.That(await Page.Output.TextContentAsync(), Is.EqualTo($"You have selected {buttonName}"));
    }

    [TestCase("No")]
    public async Task CheckIfRadioButtonIsntClickable(string buttonName)
    {
        var result = await Page.CheckIfButtonIsClicable(buttonName);

        Assert.That(result, Is.False);
    }
}  
>>>>>>> bdfedbb27f6c9eb7883d05d7d7ba1be0f09aed19
