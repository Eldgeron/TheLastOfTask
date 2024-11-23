using Library.Test.Utils.Tests.Ui.Fixtures;
using Library.Test.Utils.Tests.Ui.PageObjects;
using static Library.Test.Utils.Tests.Ui.Fixtures.BrowserType;
using BrowserType = Microsoft.Playwright.BrowserType;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;

namespace Library.Tests.Ui.Tests;

[TestFixture]
public class TextBoxPageTests
{
    private readonly BrowserSetUpBuilder _browserSetUp = new();
    private TextBoxPage Page { get; set; }

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
            //Dont forget to change the path to the folder where you want to save the video
            .SaveVideo("C:\\Users\\ganna\\source\\repos\\lesson_32\\videos")
            .WithArgs("--start-maximized")
            .OpenNewPage<TextBoxPage>();
        _browserSetUp.AddRequestResponseLogger();
        await Page!.Open();
    }

    [Test]
    public async Task ChecjIfTextBoxPageDisplayed()
    {
        var title = await Page.Title.TextContentAsync();

        Assert.That(title, Is.EqualTo("Text Box"));
        Assert.That(title, Is.EqualTo(Page.ExpectedTitle));
    }

    [Test]
    public async Task CheckIfAllLabelsAreDisplayed()
    {
        var userNameLabel = await Page.FullNameLable.TextContentAsync();
        var userEmailLabel = await Page.EmailLabel.TextContentAsync();
        var currentAddressLabel = await Page.CurrentAddressLabel.TextContentAsync();
        var permanentAddressLabel = await Page.PermanentAddressLabel.TextContentAsync();
        var submitButton = await Page.SubmitButton.TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(userNameLabel, Is.EqualTo("Full Name"));
            Assert.That(userEmailLabel, Is.EqualTo("Email"));
            Assert.That(currentAddressLabel, Is.EqualTo("Current Address"));
            Assert.That(permanentAddressLabel, Is.EqualTo("Permanent Address"));
            Assert.That(submitButton, Is.EqualTo("Submit"));
        });
    }

    [Test]
    public async Task CheckIfAllElementsPresentOnThePage()
    {
        bool isTextBoxFormPresent = await Page.TextBoxForm.IsVisibleAsync();
        bool isTitlePresent = await Page.Title.IsVisibleAsync();
        bool isFullNameLabelPresent = await Page.FullNameLable.IsVisibleAsync();
        bool isFullNameInputPresent = await Page.FullNameInput.IsVisibleAsync();
        bool isEmailLabelPresent = await Page.EmailLabel.IsVisibleAsync();
        bool isEmailInputPresent = await Page.EmailInput.IsVisibleAsync();
        bool isCurrentAddressLabelPresent = await Page.CurrentAddressLabel.IsVisibleAsync();
        bool isCurrentAddressInputPresent = await Page.CurrentAddressInput.IsVisibleAsync();
        bool isPermanentAddressLabelPresent = await Page.PermanentAddressLabel.IsVisibleAsync();
        bool isPermanentAddressInputPresent = await Page.PermanentAddressInput.IsVisibleAsync();
        bool isSubmitButtonPresent = await Page.SubmitButton.IsVisibleAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isTextBoxFormPresent, Is.True);
            Assert.That(isTitlePresent, Is.True);
            Assert.That(isFullNameLabelPresent, Is.True);
            Assert.That(isFullNameInputPresent, Is.True);
            Assert.That(isEmailLabelPresent, Is.True);
            Assert.That(isEmailInputPresent, Is.True);
            Assert.That(isCurrentAddressLabelPresent, Is.True);
            Assert.That(isCurrentAddressInputPresent, Is.True);
            Assert.That(isPermanentAddressLabelPresent, Is.True);
            Assert.That(isPermanentAddressInputPresent, Is.True);
            Assert.That(isSubmitButtonPresent, Is.True);
        });
    }

    [Test]
    public async Task CheckIfAllPlaceholdersDisplayed()
    {
        bool isFullNamePlaseholder = await Page.FullNameInput.GetAttributeAsync("placeholder") == "Full Name";
        bool isEmailPlaseholder = await Page.EmailInput.GetAttributeAsync("placeholder") == "name@example.com";
        bool isCurrentAddressPlaseholder = await Page.CurrentAddressInput.GetAttributeAsync("placeholder") == "Current Address";
        bool isPermanentAddressPlaseholder = await Page.PermanentAddressInput.GetAttributeAsync("placeholder") != null;

        Assert.Multiple(() =>
        {
            Assert.That(isFullNamePlaseholder, Is.True);
            Assert.That(isEmailPlaseholder, Is.True);
            Assert.That(isCurrentAddressPlaseholder, Is.True);
            Assert.That(isPermanentAddressPlaseholder, Is.False);
        });
    }

    [Test]
    public async Task FillAllInputsAndPressSubmitBtn()
    {
        await Page.EnterFullName("Some Name");
        await Page.EnterEmail("some@mail.add");
        await Page.EnterCurrentAddress("Some Current Address");
        await Page.EnterPermanentAddress("Some Permanent Address");
        await Page.ClickSubmitBtn();

        var output = await Page.Output.TextContentAsync();

       Assert.Multiple(() =>
       {
           Assert.That(output, Is.Not.Null);
           Assert.That(output, Does.Contain("Some Name"));
           Assert.That(output, Does.Contain("some@mail.add"));
           Assert.That(output, Does.Contain("Some Current Address"));
           Assert.That(output, Does.Contain("Some Permanent Address"));
       });
    }

    [Test]
    public async Task Video()
    {
        var browser = await Playwright.CreateAsync(); 
        var chromium = await browser.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
        { 
            Headless = false 
        }); 
        var context = await chromium.NewContextAsync(new BrowserNewContextOptions 
        { 
            ViewportSize = new ViewportSize { Width = 1900, Height = 1080 }, 
            RecordVideoDir = "C:\\Users\\ganna\\source\\repos\\lesson_32\\videos", 
            RecordVideoSize = new RecordVideoSize { Width = 1900, Height = 1080 } }); 
        var page = await context.NewPageAsync(); 
        await page.GotoAsync("https://demoqa.com/text-box");
       
        // Виконайте деякі дії на сторінці
        await page.CloseAsync(); 
        await context.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _browserSetUp.Page!.CloseAsync();
        await _browserSetUp.Context!.CloseAsync();
    }
}