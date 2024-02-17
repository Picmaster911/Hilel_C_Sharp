using NoteContracs;
using System.Collections;


namespace MyNoteProcessor
{
    public interface INoteProcessor
    {
        public IEnumerable<MyNote> ReadALLFromBD();
        public void WriteToBD(MyNote newNote);
        public void EditFromBD(MyNote noteForEdit);
        public void DeleteFromBD(MyNote noteForDelete);
        public IEnumerable GetSortNotes();
        public int GetLastElement();
    }
}
