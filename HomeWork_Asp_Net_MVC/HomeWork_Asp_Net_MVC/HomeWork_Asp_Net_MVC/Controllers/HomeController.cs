using DAL;
using HomeWork_Asp_Net_MVC.Models;
using HomeWork_Asp_Net_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MyNoteProcessor;
using NoteContracs;
using System.Diagnostics;

namespace HomeWork_Asp_Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NotesViewModel _notesViewModel;
        private INoteProcessor _noteProcessor1;
        public HomeController(ILogger<HomeController> logger,
            IDataWorker<MyNote> dataWorker,
            NotesViewModel notesViewModel,
            INoteProcessor noteProcessor)
        {
            _notesViewModel = notesViewModel;
            _logger = logger;
            _noteProcessor1 = noteProcessor;    
        }
        public IActionResult Index()
        { 
           return View(_notesViewModel);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public RedirectResult Delete(MyNote newNote)
        {
            _noteProcessor1.DeleteFromBD(newNote);

            return Redirect("/");
        }

        public IActionResult EditeNote(MyNote editeNote)
        {
            return View(editeNote);
        }

        [HttpPost]
        public RedirectResult AddNewNote (MyNote newNote )
        {
            _noteProcessor1.WriteToBD(newNote);
            return Redirect("/");
        }
        [HttpPost]
        public JsonResult EditeSelectedNote([FromBody] MyNote newNote)
        {
            _noteProcessor1.EditFromBD(newNote);
            return Json(newNote);
        }
        [HttpPost]
        public IActionResult EditeSelectedNoteAspNet(MyNote newNote)
        {
            _noteProcessor1.EditFromBD(newNote);
            return View("EditeNote", newNote);
        }
        public IActionResult SortByPriority()
        {
            _notesViewModel.SortByPriority();
            return View("Index", _notesViewModel);
        }
    }
}
