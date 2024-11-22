using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test.Utils.Tests.Ui.PageObjects
{
    public class WebTablePage : IBasePage
    {
        public IPage? Page { get; set; }
        public string Url { get; } = "https://demoqa.com/webtables";
        public string ExpectedTitle { get; } = "Web Tables";
        public ILocator Title => Page!.Locator("xpath=//h1[contains(text(),\"Web Tables\")]");
        public ILocator AddNewRecordBtn => Page!.Locator("id=addNewRecordButton");
        public ILocator SearchBox => Page!.Locator("id=searchBox");
        public ILocator Table => Page!.Locator("xpath=//div[@class='rt-table']");
        public ILocator TableRows => Page!.Locator("xpath=//div[@class='rt-tr-group']");
        public ILocator TableHeader => Page!.Locator("xpath=///div[@class='rt-thead -header']");
        public ILocator RegistrationForm => Page!.Locator("xpath=//div[@class='modal-content']");
        public ILocator FirstNameInput => Page!.Locator("id=firstName");
        public ILocator LastNameInput => Page!.Locator("id=lastName");
        public ILocator EmailInput => Page!.Locator("id=userEmail");
        public ILocator AgeInput => Page!.Locator("id=age");
        public ILocator SalaryInput => Page!.Locator("id=salary");
        public ILocator DepartmentInput => Page!.Locator("id=department");
        public ILocator SubmitBtn => Page!.Locator("id=submit");
        public ILocator DeleteCierraBtn => Page!.Locator("id=delete-record-1");

        public string NRFirstName { get; set; } = "Ganna";
        public string NRLastName { get; } = "Liubimova";
        public string NREmail { get; } = "some@email.com";
        public string NRAge { get; } = "25";
        public string NRSalary { get; } = "1000";
        public string NRDepartment { get; } = "QA";
        public async Task Open()
        {
            await Page!.GotoAsync(Url);
        }

        public async Task<WebTablePage> AddNewRecord()
        {
            await AddNewRecordBtn.ClickAsync();
            await FirstNameInput.FillAsync(NRFirstName);
            await LastNameInput.FillAsync(NRLastName);
            await EmailInput.FillAsync(NREmail);
            await AgeInput.FillAsync(NRAge);
            await SalaryInput.FillAsync(NRSalary);
            await DepartmentInput.FillAsync(NRDepartment);
            await SubmitBtn.ClickAsync();
            return this;
        }

        public async Task CheckRecordInTable()
        {
            var table = await Table.GetAttributeAsync("innerText");
            var isRecordInTable = table.Contains(NRFirstName) && table.Contains(NRLastName) && table.Contains(NREmail) && table.Contains(NRAge) && table.Contains(NRSalary) && table.Contains(NRDepartment);
            if (!isRecordInTable)
            {
                throw new Exception("Record is not in the table");
            }
        }



        public async Task<WebTablePage> Search(string searchValue)
        {
            await SearchBox.FillAsync(searchValue);
            return this;
        }



    }
}
