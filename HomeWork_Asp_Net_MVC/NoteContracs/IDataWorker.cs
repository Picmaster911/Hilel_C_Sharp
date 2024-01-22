using NoteContracs;

namespace DAL
{
    public interface IDataWorker<T> where T : class
    {
        public IEnumerable<T> ReadALLFromBD();
        public void WriteToBD (MyNote newNote);   
        public void EditFromBD (MyNote noteForEdit);
        public void DeleteFromBD(MyNote noteForDelete);

    }
}
