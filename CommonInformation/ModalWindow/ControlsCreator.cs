using System.Windows.Controls;
using System.Windows.Input;

namespace CommonInformation
{
    public static class ControlsCreator
    {
        public static ModalWindowControl GetOkButton(ICommand command = null, object commandParameter = null)
        {
            var button = GetButton("OK", ControlLocation.Right, command, commandParameter);
            ((Button) button.Item).IsDefault = true;
            return button;
        }

        public static ModalWindowControl GetCancelButton(ICommand command = null, object commandParameter = null)
        {
            var button = GetButton("Отмена", ControlLocation.Right, command, commandParameter);
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
    }
}
