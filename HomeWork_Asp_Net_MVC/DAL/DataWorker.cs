using NotesProcessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataWorker : IDataWorker
    {
        public void EditFromBD(MyNote noteForEdit)
        {
            using (var db = new AppDbContext())
            {
                var allNotes = db.MyNotes;
                var needNodes = allNotes.Where(x => x.Id == noteForEdit.Id).FirstOrDefault();
                if (needNodes != null) 
                {
                    needNodes.Value = noteForEdit.Value;
                    needNodes.Name = noteForEdit.Name;
                    needNodes.Priority = noteForEdit.Priority;  
                }
                db.SaveChanges();
            }
        }

        public IEnumerable ReadALLFromBD()
        {
            using (var db = new AppDbContext())
            {
                var allNotes = db.MyNotes.ToList();
                return allNotes;    
            }
        }

        public void WriteToBD(MyNote newNote)
        {
            using (var db = new AppDbContext())
            {
                var allNotes = db.MyNotes;
                allNotes.Add(newNote);
                db.SaveChanges();
            }
           
        }
    }
}
