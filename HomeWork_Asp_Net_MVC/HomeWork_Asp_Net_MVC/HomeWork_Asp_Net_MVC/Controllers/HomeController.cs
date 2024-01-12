using DAL;
using HomeWork_Asp_Net_MVC.Models;
using HomeWork_Asp_Net_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NotesProcessor;
using System.Diagnostics;

namespace HomeWork_Asp_Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  IDataWorker _dataWorker;
        private NotesViewModel _notesViewModel;
        public HomeController(ILogger<HomeController> logger, IDataWorker dataWorker, NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
            _logger = logger;
            _dataWorker = dataWorker;
            
        }

        public IActionResult Index()
        {
            _notesViewModel.ReadAllNotes();
            return View(_notesViewModel);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public RedirectResult Delete(MyNote newNote)
        {
            _dataWorker.DeleteFromBD(newNote);

            return Redirect("/");
        }

        public IActionResult EditeNote(MyNote editeNote)
        {
            return View(editeNote);
        }

        [HttpPost]
        public RedirectResult AddNewNote (MyNote newNote )
        {
            _dataWorker.WriteToBD(newNote);
            return Redirect("/");
        }
        [HttpPost]
        public JsonResult EditeSelectedNote([FromBody] MyNote newNote)
        {
            _dataWorker.EditFromBD(newNote);
            return Json(newNote);
        }
    }
}
