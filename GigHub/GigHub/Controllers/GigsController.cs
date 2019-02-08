using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
       
        public ActionResult Create()
        {
            GigFormViewModel viewModel = new GigFormViewModel();
            viewModel.Genres = _context.Genres;

            return View(viewModel);
        }


    }
}