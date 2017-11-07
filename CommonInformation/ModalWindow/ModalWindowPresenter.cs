using System.Windows;
using System.Windows.Input;
using CommonInformation.ModalWindow;

namespace CommonInformation
{
    public static class ModalWindowPresenter
    {
        public static bool ShowModal(FrameworkElement view, params ModalWindowControl[] items)
        {
            var wnd = new CommonModalWindow(view, items);
            var settingsView = view as IModalWindowSettings;
            if (settingsView?.WindowSettings != null)
            {
                SetWindowSettings(wnd, settingsView.WindowSettings);
            }
            return true==wnd.ShowDialog();
        }

        public static bool ShowModalOkCancel(FrameworkElement view)
        {
            return ShowModal(view, 
                ControlsCreator.GetOkButton(CloseCurrentWindowCommand), 
                ControlsCreator.GetCancelButton());
        }

        public static void ShowErrorMessage(string languageKey, params object[] items)
        {
            var errorViewsettings = new ModalWindowSettings
            {
                Title = LanguageDictionary.GetValue("Error"),
                ResizeMode = ResizeMode.CanResize
            };
            var view = ControlsCreator.GetSimpleTextView(languageKey,items);
            ShowModal(view, ControlsCreator.GetCustomCancelButton(LanguageDictionary.GetFormatValue("Close", items)));
        }

        public static ICommand CloseCurrentWindowCommand { get;} = new RelayCommand(o=>CloseCurrentWindowExecute());

        

        public static void CloseCurrentModalWindow(bool result=true)
        {
            foreach (Window wnd in Application.Current.Windows)
            {
                if (!wnd.IsActive)
                {
                    continue;
                }
                wnd.DialogResult = result;
                wnd.Close();
                return;
            }
        }

        private static void SetWindowSettings(Window wnd, ModalWindowSettings settings)
        {
            if (settings.MinHeight != 0)
            {
                wnd.MinHeight = settings.MinHeight;
            }
            if (settings.MinWidth != 0)
            {
                wnd.MinWidth = settings.MinWidth;
            }
            if (settings.MaxHeight != 0)
            {
                wnd.MaxHeight = settings.MaxHeight;
            }
            if (settings.MaxWidth != 0)
            {
                wnd.MaxWidth = settings.MaxWidth;
            }
            wnd.ResizeMode = settings.ResizeMode;
            wnd.WindowStartupLocation = settings.StartupLocation;
            wnd.Title = settings.Title;
            if (settings.Icon != null)
            {
                wnd.Icon = settings.Icon;
            }
        }
        private static void CloseCurrentWindowExecute()
        {
            CloseCurrentModalWindow();
        }
    }
}
