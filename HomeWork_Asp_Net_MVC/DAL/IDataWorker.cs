using NotesProcessor;
using System.Collections;

namespace DAL
{
    public interface IDataWorker
    {
        public void WriteToBD (MyNote newNote);
        public List<MyNote> ReadALLFromBD();
        public void EditFromBD (MyNote noteForEdit);

        public void DeleteFromBD(MyNote noteForDelete);

    }
}
