using System.Windows.Controls;
using Notebook;

namespace Ежедневник.AddNoteView
{
    /// <summary>
    /// Логика взаимодействия для AddNoteView.xaml
    /// </summary>
    public partial class AddNoteView : UserControl
    {
        public AddNoteView(AddNoteViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
