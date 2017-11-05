using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommonInformation.ModalWindow;

namespace CommonInformation
{
    public static class ControlsCreator
    {
        public static ModalWindowControl GetOkButton(ICommand command = null, object commandParameter = null)
        {
            var button = GetButton(LanguageDictionary.GetValue("Ok"), ControlLocation.Right, command, commandParameter);
            ((Button) button.Item).IsDefault = true;
            return button;
        }

        public static ModalWindowControl GetCancelButton(ICommand command = null, object commandParameter = null)
        {
            var button = GetButton(LanguageDictionary.GetValue("Cancel"), ControlLocation.Right, command, commandParameter);
            ((Button)button.Item).IsCancel = true;
            return button;
        }
        public static ModalWindowControl GetCustomCancelButton(string text, ICommand command = null, object commandParameter = null)
        {
            var button = GetButton(text, ControlLocation.Right, command, commandParameter);
            ((Button)button.Item).IsCancel = true;
            return button;
        }
        public static ModalWindowControl GetButton(string text, ControlLocation location, ICommand command, object commandParameter)
        {
            var button = new Button
            {
                Command = command,
                CommandParameter = commandParameter,
                Content = text
            };
            var result = new ModalWindowControl
            {
                Location = location,
                Item = button
            };
            return result;
        }

        public static FrameworkElement GetSimpleTextView(string languageKey, ModalWindowSettings settings = null)
        {
            return new ConfirmationTextControl(LanguageDictionary.GetValue(languageKey), settings);
        }
        public static FrameworkElement GetSimpleTextView(string languageKey, params object[] items)
        {
            return new ConfirmationTextControl(LanguageDictionary.GetFormatValue(languageKey, items));
        }
        public static FrameworkElement GetSimpleTextView(string languageKey, ModalWindowSettings settings, params object[] items)
        {
            return new ConfirmationTextControl(LanguageDictionary.GetFormatValue(languageKey, items), settings);
        }
    }
}
