using Microsoft.Playwright;


namespace Library.Test.Utils.Tests.Ui.PageObjects
{
    public class RadioButtonPage : IBasePage
    {
        public IPage? Page { get; set; }
        public string Url { get; } = "https://demoqa.com/radio-button";
        public string ExpectedTitle { get; } = "Radio Button";

        public ILocator Title => Page!.Locator("xpath=//h1[text()='Radio Button']");
        public ILocator YesRadioButton => Page!.Locator("label[for='yesRadio']");
        public ILocator ImpressiveRadioButton => Page!.Locator("label[for='impressiveRadio']");
        public ILocator NoRadioButton => Page!.Locator("label[for='noRadio']");
        public ILocator YesRadioButtonText => Page!.Locator("xpath=//label[@for='yesRadio']");
        public ILocator ImpressiveRadioButtonText => Page!.Locator("xpath=//label[@for='impressiveRadio']");
        public ILocator NoRadioButtonText => Page!.Locator("xpath=//label[@for='noRadio']");
        public string YesRadioButtonTextValue { get; } = "Yes";
        public string ImpressiveRadioButtonTextValue { get; } = "Impressive";
        public string NoRadioButtonTextValue { get; } = "No";

        public ILocator Output => Page!.Locator(".mt-3");
        public string OutputStartText { get; } = "You have selected ";
        

        public async Task Open()
        {
            await Page!.GotoAsync(Url);
        }

        public async Task ClickYesRadioButton()
        {
            await YesRadioButton.ClickAsync();
        }

        public async Task ClickImpressiveRadioButton()
        {
            await ImpressiveRadioButton.ClickAsync();
        }

        public async Task ClickNoRadioButton()
        {
            await NoRadioButton.ClickAsync();
        }

        public async Task<object> CheckIfButtonIsClicable(string buttonName)
        {
            ILocator radioButton = buttonName.ToLower() switch
            {
                "yes" => YesRadioButton,
                "impressive" => ImpressiveRadioButton,
                "no" => NoRadioButton,
                _ => throw new ArgumentException("Invalid button name")
            };

            var isButtonEnabled = await radioButton.IsEnabledAsync();
            if (isButtonEnabled)
            {
                await radioButton.ClickAsync();
                var outputText= await Output.TextContentAsync();
                return outputText;
            }
            else return false;
        }
    }
}
