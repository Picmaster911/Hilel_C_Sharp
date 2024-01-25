using MyNoteProcessor;
using NoteContracs;
using System.Collections.ObjectModel;
using System.Linq;
using Wpf_UI.ViewModel.Elements;

namespace Wpf_UI.Infrastructure
{
    class CreatorNotes : ICreatorNotes
    {
        public List<NoteViewModel> MyNotesVM { get; set; }
        public List<MyNote> MyNotes { get; set; }

        private INoteProcessor _noteProcessor;

        public ObservableCollection <NoteViewModel> ObsNoteViewModel { get; set; }

    public CreatorNotes(INoteProcessor noteProcessor)
        {
            _noteProcessor = noteProcessor;
            CreateNoteViewModel();
            CreateObserNote();
        }

        public void CreateNoteViewModel()
        {
            var MyNotes = (List<MyNote>)_noteProcessor.ReadALLFromBD();
            MyNotesVM = MyNotes.Select(x => new NoteViewModel(_noteProcessor, this)
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value,
                Priority = x.Priority,
                myNote = x
            }).ToList();
        }

        public void CreateObserNote()
        {
            ObsNoteViewModel = new ObservableCollection<NoteViewModel>();
            MyNotesVM.ForEach(x => ObsNoteViewModel.Add(x));
        }
    }
}
