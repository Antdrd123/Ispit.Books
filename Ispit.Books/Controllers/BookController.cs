using Ispit.Books.Data;
using Ispit.Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Books.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        public BookController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: BookController1
        public ActionResult Index()
        {
            var books = _context.Books.Include("Author").Include("Publisher").ToList();
            return View(books);
        }

        // GET: BookController1/Details/5
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include("Author").Include("Publisher").FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        // GET: BookController1/Create
        public ActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Publishers = _context.Publishers.ToList();

            return View();
        }

        // POST: BookController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                book.UserId = _userManager.GetUserId(User);
                _context.Books.Add(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController1/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Publishers = _context.Publishers.ToList();
            
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
          

            return View(book);
        }

        // POST: BookController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                book.UserId = _userManager.GetUserId(User);
                _context.Books.Update(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController1/Delete/5
        public ActionResult Delete(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }
            var book = _context.Books.Include("Author").Include("Publisher").FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        // POST: BookController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
