using System.Windows.Input;
using CommonInformation;

namespace Notebook
{
    public class AddNoteViewModel :BaseNotifcationObject
    {
        public ICommand CreateNoteCommand { get; private set; }

        public AddNoteViewModel()
        {
            CreateNoteCommand = new RelayCommand(CreateNoteExecute);
        }
        
        private void CreateNoteExecute(object o)
        {
            return;
        }
    }
}
