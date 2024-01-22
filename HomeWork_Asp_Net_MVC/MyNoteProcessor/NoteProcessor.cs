using DAL;
using NoteContracs;
using System.Collections;

namespace MyNoteProcessor
{
    public class NoteProcessor:INoteProcessor
    {
        private IDataWorker<MyNote> _dataWorker;
        public NoteProcessor(IDataWorker<MyNote> dataWorker)
        {
            _dataWorker= dataWorker;   
        }

        public void DeleteFromBD(MyNote noteForDelete)
        {
            _dataWorker.DeleteFromBD(noteForDelete);
        }

        public void EditFromBD(MyNote noteForEdit)
        {
            _dataWorker.EditFromBD(noteForEdit);
        }

        public IEnumerable GetSortNotes()
        {
            var sortNotes = _dataWorker.ReadALLFromBD().ToList();
            var reult = sortNotes.OrderBy(x => x.Priority).ToList();
            return reult;
        }

        public IEnumerable ReadALLFromBD()
        {
            var allNotes = _dataWorker.ReadALLFromBD();
            return allNotes;
        }

        public void WriteToBD(MyNote newNote)
        {
            _dataWorker.WriteToBD(newNote);
        }

        public int GetLastElement()
        {
            var sortNotes = _dataWorker.ReadALLFromBD().ToList().Last();
            return sortNotes.Id;
        }
    }
}
