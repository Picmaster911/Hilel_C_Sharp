using NoteContracs;
using System.Collections.ObjectModel;
using Wpf_UI.ViewModel.Elements;

namespace Wpf_UI.Infrastructure
{
    internal interface ICreatorNotes
    {
        List<MyNote> MyNotes { get; set; }
        List<NoteViewModel> MyNotesVM { get; set; }

        public ObservableCollection<NoteViewModel> ObsNoteViewModel { get; set; }

        public void CreateNoteViewModel();
        public void CreateObserNote();
    }
}