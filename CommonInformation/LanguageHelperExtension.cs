using System;
using System.Windows.Markup;

namespace CommonInformation
{
    public class LanguageHelperExtension : MarkupExtension
    {
        public string Key { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return LanguageDictionary.GetValue(Key);
        }
    }
}
