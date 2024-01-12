using DAL;
using NotesProcessor;
using System.ComponentModel.DataAnnotations;

namespace HomeWork_Asp_Net_MVC.ViewModels
{
    public class NotesViewModel
    {
        private IDataWorker _dataWorker;
        public List <MyNote> MyNotesList { get; set; }
        public MyNote MyNote;

        public NotesViewModel(IDataWorker dataWorker)
        {
            _dataWorker = dataWorker;
            ReadAllNotes();
        }

        public void ReadAllNotes()
        {
            MyNotesList = _dataWorker.ReadALLFromBD();
        }
    }
}
