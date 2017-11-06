using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommonInformation;
using CommonInformation.ModalWindow;
using DatabaseController.Models;
using DatabaseController.Repozitorys;
// ReSharper disable UseStringInterpolation

namespace Notebook 
{
    public class NotesViewModel : BaseNotifcationObject
    {
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();


        public ICommand AddNewNoteCommand { get; private set; }
        public ICommand EditNoteCommand { get; private set; }
        public ICommand DeleteNoteCommand { get; private set; }
       
        public ICommand MoveToArchveCommand { get; private set; }

        private void InitCommands()
        {
            AddNewNoteCommand = new RelayCommand(o => AddNewNoteExecute());
            EditNoteCommand = new RelayCommand(EditNoteExecute);
            DeleteNoteCommand = new RelayCommand(DeleteNoteExecute);
            MoveToArchveCommand = new RelayCommand(ArchiveNoteExecute);
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

        private void AddNewNoteExecute()
        {
            var viewModel = new AddEditNoteViewModel();
            var view = new AddEditNoteView(viewModel);
            view.WindowSettings.Title = LanguageDictionary.GetValue("AddNote");
            var result = ModalWindowPresenter.ShowModalOkCancel(view);
            if (!result)
            {
                return;
            }
            //throw new Exception("test");
            try
            {
                // ReSharper disable once PossibleNullReferenceException
                NoteRepozitory.Insert(viewModel.Note);
                FetchDataFromDatabase();
            }
            catch (Exception e)
            {
                ModalWindowPresenter.ShowErrorMessage("AddNoteException", e);
            }
        }
        private void EditNoteExecute(object obj)
        {
            var viewModel = new AddEditNoteViewModel();
            var note = obj as Note;

            if (note == null)
            {
                ModalWindowPresenter.ShowErrorMessage("EditNoteInputError");
                return;
            }

            var clone = note.Clone();
            viewModel.Note = clone;
            var view = new AddEditNoteView(viewModel);
            view.WindowSettings.Title = LanguageDictionary.GetValue("EditNote");
            var result = ModalWindowPresenter.ShowModalOkCancel(view);
            if (result != true)
            {
                return;
            }

            try
            {
                // ReSharper disable once PossibleNullReferenceException
                NoteRepozitory.Update(clone);
                FetchDataFromDatabase();
            }
            catch (Exception e)
            {
                ModalWindowPresenter.ShowErrorMessage("EditNoteException", e);
            }
        }
        private void DeleteNoteExecute(object obj)
        {
            var confirmationViewSettings = new ModalWindowSettings
            {
                Title = LanguageDictionary.GetValue("Confirmation"),
                ResizeMode = ResizeMode.NoResize
            };
            var confirmationView = ControlsCreator.GetSimpleTextView("DeleteNoteConfirmation", confirmationViewSettings);

            var result = ModalWindowPresenter.ShowModalOkCancel(confirmationView);

            if (result != true)
            {
                return;
            }
            var note = obj as Note;

            try
            {
                // ReSharper disable once PossibleNullReferenceException
                NoteRepozitory.Delete(note.Id);
                FetchDataFromDatabase();
            }
            catch (Exception e)
            {
                ModalWindowPresenter.ShowErrorMessage("DeleteNoteException", e);
            }
        }

        private void ArchiveNoteExecute(object obj)
        {

        }
    }
}
