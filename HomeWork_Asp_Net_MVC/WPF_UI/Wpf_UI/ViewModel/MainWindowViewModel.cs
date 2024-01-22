using DAL;
using MyNoteProcessor;
using NoteContracs;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf_UI.Infrastructure;
using Wpf_UI.Infrastructure.Commands;
using Wpf_UI.View;
using Wpf_UI.ViewModel.Elements;

namespace Wpf_UI.ViewModel
{
    internal class MainWindowViewModel: ViewModelBase
    {
        INoteProcessor _noteProcessor;
        public NoteViewModel SelectedItem { get; set; } 
        private ObservableCollection<NoteViewModel> _obsNoteViewModel;
        public ObservableCollection<NoteViewModel> ObsNoteViewModel 
        {
            get => _obsNoteViewModel;
            set => _obsNoteViewModel = value;       
        }       
   
        private CreatorNotes _creatorNotes;
        public MainWindowViewModel(CreatorNotes creatorNotes, INoteProcessor noteProcessor)
        {
            _noteProcessor = noteProcessor;
            _creatorNotes = creatorNotes;
            _obsNoteViewModel = _creatorNotes.ObsNoteViewModel;
            #region Commands
            DeleteNoteCommand = new LambdaCommand(
                DeleteNote,
                CanDeleteNote
                );
            ShowWindowEditeCommand = new LambdaCommand(
              ShowWindowEdite,
              CanShowWindowEdite
              );

            ShowWindowAddNoteCommand = new LambdaCommand(
             ShowWindowAddNote,
             CanShowWindowAddNote
             );
            #endregion
        }


        #region Commands
        #region DeleteNoteCommand
        public ICommand DeleteNoteCommand { get; }
       
        private void DeleteNote(object p)
        {
            var noteVMforDelete = (NoteViewModel)p;
            ObsNoteViewModel.Remove(noteVMforDelete);
            _noteProcessor.DeleteFromBD( new MyNote() { Id = noteVMforDelete.Id });
        }
        private bool CanDeleteNote(object p) => true;
        #endregion

        #region ShowWindowEditeCommand
        public ICommand ShowWindowEditeCommand { get; set; }

        private void ShowWindowEdite(object p)
        {
            var NoteContext = (NoteViewModel)p;
            EditeNoteWindow editeNoteWindow = new EditeNoteWindow();
            editeNoteWindow.DataContext = NoteContext;
            editeNoteWindow.Show();
        }
        private bool CanShowWindowEdite(object p) => true;
        #endregion


        #region ShowWindowAddNoteCommand
        public ICommand ShowWindowAddNoteCommand { get; set; }

        private void ShowWindowAddNote(object p)
        {
            var newNoteContext = new NoteViewModel(_noteProcessor, _creatorNotes);
            AddNewNoteWindow editeNoteWindow = new AddNewNoteWindow();
            editeNoteWindow.DataContext = newNoteContext;
            editeNoteWindow.Show();
        }
        private bool CanShowWindowAddNote(object p) => true;
        #endregion
        #endregion
    }
}
