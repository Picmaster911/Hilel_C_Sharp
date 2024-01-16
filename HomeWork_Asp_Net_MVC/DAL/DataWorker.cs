using NoteContracs;

namespace DAL
{
    public class DataWorker : IDataWorker<MyNote>
    {
        private readonly AppDbContext _appDbContext;
        public DataWorker(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void EditFromBD(MyNote noteForEdit)
        {
            var allNotes = _appDbContext.MyNotes;
            var needNodes = allNotes.Where(x => x.Id == noteForEdit.Id).FirstOrDefault();
            if (needNodes != null && noteForEdit.Value != null && noteForEdit.Name != null)
            {
                needNodes.Value = noteForEdit.Value;
                needNodes.Name = noteForEdit.Name;
                needNodes.Priority = noteForEdit.Priority;
            }
            _appDbContext.SaveChanges();
        }

        public IEnumerable<MyNote> ReadALLFromBD()
        {
            var allNotes = _appDbContext.MyNotes.ToList();
            return allNotes;
        }

        public void WriteToBD(MyNote newNote)
        {

            var allNotes = _appDbContext.MyNotes;
            if (newNote.Name != null && newNote.Value != null)
            {
                allNotes.Add(newNote);
                _appDbContext.SaveChanges();
            }
        }

        public void DeleteFromBD(MyNote noteForDelete)
        {
            var forDelete = _appDbContext.MyNotes.Where(x => x.Id == noteForDelete.Id).FirstOrDefault();
            if (forDelete != null)
            {
                _appDbContext.MyNotes.Remove(forDelete);
                _appDbContext.SaveChanges();
            }
        }

    }
}
