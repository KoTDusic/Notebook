using System.Collections.ObjectModel;
using CommonInformation.Models;
using CommonInformation.Repozitorys;

namespace Notebook 
{
    public class NotesViewModel : BaseNotifcationObject
    {
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        public NotesViewModel()
        {
            var notes = NoteRepozitory.GetAll();
            if (notes == null)
            {
                return;
            }
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
