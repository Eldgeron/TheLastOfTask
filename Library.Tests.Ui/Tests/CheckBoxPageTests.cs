using Library.Test.Utils.Tests.Ui.Fixtures;
using Library.Test.Utils.Tests.Ui.PageObjects;
using static Library.Test.Utils.Tests.Ui.Fixtures.BrowserType;
using BrowserType = Microsoft.Playwright.BrowserType;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Tests.Ui.Tests;

[TestFixture]
public class CheckBoxPageTests
{
    private readonly BrowserSetUpBuilder _browserSetUp = new();
    private CheckBoxPage Page { get; set; }

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
            //.WithArgs("--start-maximized")
            .WithArgs("--kiosk")
            .OpenNewPage<CheckBoxPage>();
        _browserSetUp.AddRequestResponseLogger();
        await Page!.Open();
    }
    [SetUp]
    public async Task SetUp()
    {
        await Page.Page.ReloadAsync();
    }

    [Test]
    public async Task ChecjIfCheckBoxPageDisplayed()
    {
        var title = await Page.Title.TextContentAsync();

        Assert.That(title, Is.EqualTo("Check Box"));
        Assert.That(title, Is.EqualTo(Page.ExpectedTitle));
    }

    [Test]
    public async Task CheckIfAllStructureExpandedWhenPressExpandeAllBtn()
    {
        await Page.ExpandeAll.ClickAsync();

        bool isHomeVisible = await Page.Home.IsVisibleAsync();
        bool isDesktopVisible = await Page.Desktop.IsVisibleAsync();
        bool isNotesVisible = await Page.Notes.IsVisibleAsync();
        bool isCommandsVisible = await Page.Commands.IsVisibleAsync();
        bool isDocumentsVisible = await Page.Documents.IsVisibleAsync();
        bool isWorkSpaceVisible = await Page.WorkSpace.IsVisibleAsync();
        bool isReactVisible = await Page.React.IsVisibleAsync();
        bool isAngularVisible = await Page.Angular.IsVisibleAsync();
        bool isVeuVisible = await Page.Veu.IsVisibleAsync();
        bool isOfficeVisible = await Page.Office.IsVisibleAsync();
        bool isPublicVisible = await Page.Public.IsVisibleAsync();
        bool isPrivateVisible = await Page.Private.IsVisibleAsync();
        bool isClassifiedVisible = await Page.Classified.IsVisibleAsync();
        bool isGeneralVisible = await Page.General.IsVisibleAsync();
        bool isDownloadsVisible = await Page.Downloads.IsVisibleAsync();
        bool isWordFileVisible = await Page.WordFile.IsVisibleAsync();
        bool isExcelFileVisible = await Page.ExcelFile.IsVisibleAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isHomeVisible, Is.True);
            Assert.That(isDesktopVisible, Is.True);
            Assert.That(isNotesVisible, Is.True);
            Assert.That(isCommandsVisible, Is.True);
            Assert.That(isDocumentsVisible, Is.True);
            Assert.That(isWorkSpaceVisible, Is.True);
            Assert.That(isReactVisible, Is.True);
            Assert.That(isAngularVisible, Is.True);
            Assert.That(isVeuVisible, Is.True);
            Assert.That(isOfficeVisible, Is.True);
            Assert.That(isPublicVisible, Is.True);
            Assert.That(isPrivateVisible, Is.True);
            Assert.That(isClassifiedVisible, Is.True);
            Assert.That(isGeneralVisible, Is.True);
            Assert.That(isDownloadsVisible, Is.True);
            Assert.That(isWordFileVisible, Is.True);
            Assert.That(isExcelFileVisible, Is.True);
        });
    }

    [Test]
    public async Task CheckIfAllStructureCollapsedWhenPressCollapseAllBtn()
    {
        await Page.ExpandeAll.ClickAsync();
        await Page.CollapseAll.ClickAsync();

        bool isHomeVisible = await Page.Home.IsVisibleAsync();
        bool isDesktopVisible = await Page.Desktop.IsVisibleAsync();
        bool isNotesVisible = await Page.Notes.IsVisibleAsync();
        bool isCommandsVisible = await Page.Commands.IsVisibleAsync();
        bool isDocumentsVisible = await Page.Documents.IsVisibleAsync();
        bool isWorkSpaceVisible = await Page.WorkSpace.IsVisibleAsync();
        bool isReactVisible = await Page.React.IsVisibleAsync();
        bool isAngularVisible = await Page.Angular.IsVisibleAsync();
        bool isVeuVisible = await Page.Veu.IsVisibleAsync();
        bool isOfficeVisible = await Page.Office.IsVisibleAsync();
        bool isPublicVisible = await Page.Public.IsVisibleAsync();
        bool isPrivateVisible = await Page.Private.IsVisibleAsync();
        bool isClassifiedVisible = await Page.Classified.IsVisibleAsync();
        bool isGeneralVisible = await Page.General.IsVisibleAsync();
        bool isDownloadsVisible = await Page.Downloads.IsVisibleAsync();
        bool isWordFileVisible = await Page.WordFile.IsVisibleAsync();
        bool isExcelFileVisible = await Page.ExcelFile.IsVisibleAsync();
        Assert.Multiple(() =>
        {
            Assert.That(isHomeVisible, Is.True);
            Assert.That(isDesktopVisible, Is.False);
            Assert.That(isNotesVisible, Is.False);
            Assert.That(isCommandsVisible, Is.False);
            Assert.That(isDocumentsVisible, Is.False);
            Assert.That(isWorkSpaceVisible, Is.False);
            Assert.That(isReactVisible, Is.False);
            Assert.That(isAngularVisible, Is.False);
            Assert.That(isVeuVisible, Is.False);
            Assert.That(isOfficeVisible, Is.False);
            Assert.That(isPublicVisible, Is.False);
            Assert.That(isPrivateVisible, Is.False);
            Assert.That(isClassifiedVisible, Is.False);
            Assert.That(isGeneralVisible, Is.False);
            Assert.That(isDownloadsVisible, Is.False);
            Assert.That(isWordFileVisible, Is.False);
            Assert.That(isExcelFileVisible, Is.False);
        });
    }

    [Test]
    public async Task CheckIfAllCheckBoxesCheckedWhenClickOnHomeCheckBox()
    {
        await Page.ExpandeAll.ClickAsync();
        await Page.Home.ClickAsync();

        bool isHomeChecked = await Page.Home.IsCheckedAsync();
        bool isDesktopChecked = await Page.Desktop.IsCheckedAsync();
        bool isNotesChecked = await Page.Notes.IsCheckedAsync();
        bool isCommandsChecked = await Page.Commands.IsCheckedAsync();
        bool isDocumentsChecked = await Page.Documents.IsCheckedAsync();
        bool isWorkSpaceChecked = await Page.WorkSpace.IsCheckedAsync();
        bool isReactChecked = await Page.React.IsCheckedAsync();
        bool isAngularChecked = await Page.Angular.IsCheckedAsync();
        bool isVeuChecked = await Page.Veu.IsCheckedAsync();
        bool isOfficeChecked = await Page.Office.IsCheckedAsync();
        bool isPublicChecked = await Page.Public.IsCheckedAsync();
        bool isPrivateChecked = await Page.Private.IsCheckedAsync();
        bool isClassifiedChecked = await Page.Classified.IsCheckedAsync();
        bool isGeneralChecked = await Page.General.IsCheckedAsync();
        bool isDownloadsChecked = await Page.Downloads.IsCheckedAsync();
        bool isWordFileChecked = await Page.WordFile.IsCheckedAsync();
        bool isExcelFileChecked = await Page.ExcelFile.IsCheckedAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isHomeChecked, Is.True);
            Assert.That(isDesktopChecked, Is.True);
            Assert.That(isNotesChecked, Is.True);
            Assert.That(isCommandsChecked, Is.True);
            Assert.That(isDocumentsChecked, Is.True);
            Assert.That(isWorkSpaceChecked, Is.True);
            Assert.That(isReactChecked, Is.True);
            Assert.That(isAngularChecked, Is.True);
            Assert.That(isVeuChecked, Is.True);
            Assert.That(isOfficeChecked, Is.True);
            Assert.That(isPublicChecked, Is.True);
            Assert.That(isPrivateChecked, Is.True);
            Assert.That(isClassifiedChecked, Is.True);
            Assert.That(isGeneralChecked, Is.True);
            Assert.That(isDownloadsChecked, Is.True);
            Assert.That(isWordFileChecked, Is.True);
            Assert.That(isExcelFileChecked, Is.True);
        });
    }

    [Test]
    public async Task CheckIfAllElementsDisplayedInResultWhenCheckedAllCheckBoxes()
    {
        await Page.ExpandeAll.ClickAsync();
        await Page.Home.ClickAsync();

        string output = await Page.Output.TextContentAsync();

        Assert.That(output, Does.StartWith(Page.OtputStartText));
        Assert.That(output, Does.Contain("home"));
        Assert.That(output, Does.Contain("desktop"));
        Assert.That(output, Does.Contain("notes"));
        Assert.That(output, Does.Contain("commands"));
        Assert.That(output, Does.Contain("documents"));
        Assert.That(output, Does.Contain("workspace"));
        Assert.That(output, Does.Contain("react"));
        Assert.That(output, Does.Contain("angular"));
        Assert.That(output, Does.Contain("veu"));
        Assert.That(output, Does.Contain("office"));
        Assert.That(output, Does.Contain("public"));
        Assert.That(output, Does.Contain("private"));
        Assert.That(output, Does.Contain("classified"));
        Assert.That(output, Does.Contain("general"));
        Assert.That(output, Does.Contain("downloads"));
        Assert.That(output, Does.Contain("wordFile"));
        Assert.That(output, Does.Contain("excelFile"));
    }
    [Test]
    public async Task CheckIfAllCheckBoxesUncheckedWhenClickOnHomeCheckBoxTwice()
    {
        await Page.ExpandeAll.ClickAsync();
        await Page.Home.ClickAsync();
        await Page.Home.ClickAsync();

        bool isHomeChecked = await Page.Home.IsCheckedAsync();
        bool isDesktopChecked = await Page.Desktop.IsCheckedAsync();
        bool isNotesChecked = await Page.Notes.IsCheckedAsync();
        bool isCommandsChecked = await Page.Commands.IsCheckedAsync();
        bool isDocumentsChecked = await Page.Documents.IsCheckedAsync();
        bool isWorkSpaceChecked = await Page.WorkSpace.IsCheckedAsync();
        bool isReactChecked = await Page.React.IsCheckedAsync();
        bool isAngularChecked = await Page.Angular.IsCheckedAsync();
        bool isVeuChecked = await Page.Veu.IsCheckedAsync();
        bool isOfficeChecked = await Page.Office.IsCheckedAsync();
        bool isPublicChecked = await Page.Public.IsCheckedAsync();
        bool isPrivateChecked = await Page.Private.IsCheckedAsync();
        bool isClassifiedChecked = await Page.Classified.IsCheckedAsync();
        bool isGeneralChecked = await Page.General.IsCheckedAsync();
        bool isDownloadsChecked = await Page.Downloads.IsCheckedAsync();
        bool isWordFileChecked = await Page.WordFile.IsCheckedAsync();
        bool isExcelFileChecked = await Page.ExcelFile.IsCheckedAsync();
        Assert.Multiple(() =>
        {
            Assert.That(isHomeChecked, Is.False);
            Assert.That(isDesktopChecked, Is.False);
            Assert.That(isNotesChecked, Is.False);
            Assert.That(isCommandsChecked, Is.False);
            Assert.That(isDocumentsChecked, Is.False);
            Assert.That(isWorkSpaceChecked, Is.False);
            Assert.That(isReactChecked, Is.False);
            Assert.That(isAngularChecked, Is.False);
            Assert.That(isVeuChecked, Is.False);
            Assert.That(isOfficeChecked, Is.False);
            Assert.That(isPublicChecked, Is.False);
            Assert.That(isPrivateChecked, Is.False);
            Assert.That(isClassifiedChecked, Is.False);
            Assert.That(isGeneralChecked, Is.False);
            Assert.That(isDownloadsChecked, Is.False);
            Assert.That(isWordFileChecked, Is.False);
            Assert.That(isExcelFileChecked, Is.False);
        });
    }

    [Test]
    public async Task CheckIfNoElementsDisplayedInResultWhenAllUnchecked()
    {
        await Page.ExpandeAll.ClickAsync();
        await Page.Home.ClickAsync();
        await Page.Home.ClickAsync();

        bool output = await Page.Output.IsVisibleAsync();

        Assert.That(output, Is.False);
    }

    [Test]
    [TestCase("Home")]
    [TestCase("Desktop")]
    [TestCase("Notes")]
    [TestCase("Commands")]
    [TestCase("Documents")]
    [TestCase("WorkSpace")]
    [TestCase("React")]
    [TestCase("Angular")]
    [TestCase("Veu")]
    [TestCase("Office")]
    [TestCase("Public")]
    [TestCase("Private")]
    [TestCase("Classified")]
    [TestCase("General")]
    [TestCase("Downloads")]
    [TestCase("WordFile")]
    [TestCase("ExcelFile")]
    public async Task CheckIfCheckBoxCheckedWhenClickOnIt(string checkBoxName)
    {
        await Page.ExpandeAll.ClickAsync();

        var checkBoxProperty = typeof(CheckBoxPage).GetProperty(checkBoxName)?.GetValue(Page) as ILocator;

        await checkBoxProperty.ClickAsync();

        bool isCheckBoxChecked = await checkBoxProperty.IsCheckedAsync();
        Assert.That(isCheckBoxChecked, Is.True);

    }

}