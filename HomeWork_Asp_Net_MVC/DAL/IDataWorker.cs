using NotesProcessor;
using System.Collections;

namespace DAL
{
    public interface IDataWorker
    {
        public void WriteToBD (MyNote newNote);
        public IEnumerable ReadALLFromBD();
        public void EditFromBD (MyNote noteForEdit);

    }
}
