using BookClubProject.Data;
using BookClubProject.Interfaces;
using BookClubProject.Models;
using BookClubProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookClubProject.Controllers
{
    public class BookClubController : Controller
    {
        private readonly IBookClubRepository _bookClubRepository;
        private readonly IPhotoService _photoService;

        public BookClubController(IBookClubRepository bookClubRepository,IPhotoService photoService) 
        {
            _bookClubRepository = bookClubRepository;
            _photoService = photoService;
        }
        public async  Task <IActionResult> Index()
        {
            IEnumerable<BookClub> bookClubs = await _bookClubRepository.GetAll();
            return View(bookClubs);
        }public async Task<IActionResult> Details(int id)
        {
            BookClub bookClub = await _bookClubRepository.GetByIdAsync(id);
            return View(bookClub);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookClubViewModel BookClubVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(BookClubVM.Image);
                var bookClub = new BookClub
                {
                    Image = result.Url.ToString(),
                    Description = BookClubVM.Description,
                    BookName = BookClubVM.BookName,
                    price = BookClubVM.price

                };
                _bookClubRepository.Add(bookClub);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Failed processing your photo");
                return View(BookClubVM);

            }
            return View(BookClubVM);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}
