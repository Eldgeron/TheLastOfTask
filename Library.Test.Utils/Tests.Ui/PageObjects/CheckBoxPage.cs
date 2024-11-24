using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Library.Test.Utils.Tests.Ui.PageObjects
{
    public class CheckBoxPage : IBasePage
    {
        public IPage? Page { get; set; }
        public string Url => "https://demoqa.com/checkbox";
        public string ExpectedTitle { get; } = "Check Box";
        public ILocator Title => Page!.Locator("xpath=//h1[contains(text(),\"Check Box\")]");
        public ILocator Home => Page!.Locator("xpath=//span[text()='Home']");
        public ILocator Desktop => Page!.Locator("xpath=//span[text()='Desktop']");
        public ILocator Notes => Page!.Locator("xpath=//span[text()='Notes']");
        public ILocator Commands => Page!.Locator("xpath=//span[text()='Commands']");
        public ILocator Documents => Page!.Locator("xpath=//span[text()='Documents']");
        public ILocator WorkSpace => Page!.Locator("xpath=//span[text()='WorkSpace']");
        public ILocator React => Page!.Locator("xpath=//span[text()='React']");
        public ILocator Angular => Page!.Locator("xpath=//span[text()='Angular']");
        public ILocator Veu => Page!.Locator("xpath=//span[text()='Veu']");
        public ILocator Office => Page!.Locator("xpath=//span[text()='Office']");
        public ILocator Public => Page!.Locator("xpath=//span[text()='Public']");
        public ILocator Private => Page!.Locator("xpath=//span[text()='Private']");
        public ILocator Classified => Page!.Locator("xpath=//span[text()='Classified']");
        public ILocator General => Page!.Locator("xpath=//span[text()='General']");
        public ILocator Downloads => Page!.Locator("xpath=//span[text()='Downloads']");
        public ILocator WordFile => Page!.Locator("xpath=//span[text()='Word File.doc']");
        public ILocator ExcelFile => Page!.Locator("xpath=//span[text()='Excel File.doc']");
        
        public ILocator ExpandeAll => Page!.Locator("xpath=//button[@title = 'Expand all']");
        public ILocator CollapseAll => Page!.Locator("xpath=//button[@title = 'Collapse all']");

        public ILocator Output => Page!.Locator("id=result");
        public string OtputStartText = "You have selected :";

        public async Task Open()
        {
            await Page!.GotoAsync(Url);
        }

    }
}
