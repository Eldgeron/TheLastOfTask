using Microsoft.Playwright;

namespace Library.Test.Utils.Tests.Ui.PageObjects
{
    public class TextBoxPage : IBasePage
    {
        public IPage? Page { get; set; }

        public string Url => "https://demoqa.com/text-box";

        public string ExpectedTitle { get; } = "Text Box";

        public ILocator TextBoxForm => Page!.Locator("id=userForm");
        public ILocator Title => Page!.Locator("xpath=//h1[contains(text(),\"Text Box\")]");

        public ILocator FullNameLable => Page!.Locator("id=userName-label");

        public ILocator FullNameInput => Page!.Locator("id=userName");

        public ILocator EmailLabel => Page!.Locator("id=userEmail-label");

        public ILocator EmailInput => Page!.Locator("id=userEmail");

        public ILocator CurrentAddressLabel => Page!.Locator("id=currentAddress-label");

        public ILocator CurrentAddressInput => Page!.Locator("id=currentAddress");

        public ILocator PermanentAddressLabel => Page!.Locator("id=permanentAddress-label");

        public ILocator PermanentAddressInput => Page!.Locator("id=permanentAddress");

        public ILocator SubmitButton => Page!.Locator("id=submit");

        public ILocator Output => Page!.Locator("id=output");


        public async Task Open()
        {
            await Page!.GotoAsync(Url);
        }


        public async Task<TextBoxPage> EnterFullName(string fullName)
        {
            await FullNameInput.FillAsync(fullName);
            return this;
        }

        public async Task<TextBoxPage> EnterEmail(string email)
        {
            await EmailInput.FillAsync(email);
            return this;
        }

        public async Task<TextBoxPage> EnterCurrentAddress(string currentAddress)
        {
            await CurrentAddressInput.FillAsync(currentAddress);
            return this;
        }

        public async Task<TextBoxPage> EnterPermanentAddress(string permanentAddress)
        {
            await PermanentAddressInput.FillAsync(permanentAddress);
            return this;
        }

        public async Task<TextBoxPage> ClickSubmitBtn()
        {
            await SubmitButton.ClickAsync();
            return this;
        }
    }
}
