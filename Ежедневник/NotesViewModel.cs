using System.Collections.ObjectModel;
using System.Windows.Input;
using CommonInformation;
using DatabaseController.Models;
using DatabaseController.Repozitorys;

namespace Notebook 
{
    public class NotesViewModel : BaseNotifcationObject
    {
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        
        public ICommand DeleteNoteCommand { get; private set; }

        private void InitCommands()
        {
            DeleteNoteCommand = new RelayCommand(o => DeleteNoteExecute());
        }

        private void FetchDataFromDatabase()
        {
            var notes = NoteRepozitory.GetAll();
            if (notes == null)
            {
                return;
            }
            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }
        public NotesViewModel()
        {
            InitCommands();
            FetchDataFromDatabase();
        }

        private void DeleteNoteExecute()
        {

        }
    }
}
