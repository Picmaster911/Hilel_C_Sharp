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
                if (needNodes != null && noteForEdit.Value !=null && noteForEdit.Name != null) 
                {
                    needNodes.Value = noteForEdit.Value;
                    needNodes.Name = noteForEdit.Name;
                    needNodes.Priority = noteForEdit.Priority;  
                }
                db.SaveChanges();
            }
        }

        public List<MyNote> ReadALLFromBD()
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
                if(newNote.Name != null && newNote.Value != null)
                {
                    allNotes.Add(newNote);
                    db.SaveChanges();
                }           
            }
           
        }

        public void DeleteFromBD(MyNote noteForDelete)
        {
            using (var db = new AppDbContext())
            {

                var forDelete = db.MyNotes.Where(x => x.Id == noteForDelete.Id).FirstOrDefault();
                if (forDelete != null)
                {
                    db.MyNotes.Remove(forDelete);
                    db.SaveChanges();
                }
            }

        }
    }
}
