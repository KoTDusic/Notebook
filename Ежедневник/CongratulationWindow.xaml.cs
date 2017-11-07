using System.Windows;
using CommonInformation;
using CommonInformation.ModalWindow;

namespace Notebook
{
    public partial class CongratulationWindow : IModalWindowSettings
    {
        public CongratulationWindow()
        {
            InitializeComponent();
        }

        public ModalWindowSettings WindowSettings { get; } = new ModalWindowSettings
        {
            SizeToContent = SizeToContent.WidthAndHeight,
            Title = LanguageDictionary.GetValue("Congratulation")
        };
    }
}
