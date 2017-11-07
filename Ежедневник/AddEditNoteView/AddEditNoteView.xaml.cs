

using System.Windows;
using CommonInformation.ModalWindow;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для AddEditNoteView.xaml
    /// </summary>
    public partial class AddEditNoteView : IModalWindowSettings
    {
        public AddEditNoteView(AddEditNoteViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public ModalWindowSettings WindowSettings { get; } = new ModalWindowSettings
        {
            MinWidth = 300,
            MinHeight = 400,
            ResizeMode = ResizeMode.CanResize
        };
    }
}
