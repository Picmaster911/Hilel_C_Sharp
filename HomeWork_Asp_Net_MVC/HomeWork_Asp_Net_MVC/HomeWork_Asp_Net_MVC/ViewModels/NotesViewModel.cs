using MyNoteProcessor;
using NoteContracs;

namespace HomeWork_Asp_Net_MVC.ViewModels
{
    public class NotesViewModel
    {
        private INoteProcessor _noteProcessor;
        public List <MyNote> MyNotesList { get; set; }
        public MyNote MyNote;

        public NotesViewModel(INoteProcessor noteProcessor)
        {
            _noteProcessor = noteProcessor;
            ReadAllNotes();
        }

        public void ReadAllNotes()
        {
            MyNotesList = (List<MyNote>)_noteProcessor.ReadALLFromBD();
        }
        public void SortByPriority()
        {
            MyNotesList = (List<MyNote>)_noteProcessor.GetSortNotes();
        }
    }
}
