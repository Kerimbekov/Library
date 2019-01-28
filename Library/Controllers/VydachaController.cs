using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class VydachaController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public VydachaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var vm = new VydachaBindingModel();
            vm.ReaderItems = _appDbContext.Readers;
            vm.BookItems = _appDbContext.Books;
   
            return View(vm);
           
        }

        [HttpPost]
        public RedirectToRouteResult Submit([FromForm]VydachaBindingModel vydacha)
        {
           //gde to zdes vylitat oshibka,kak ya ponyal vhodyashi parametr vydacha
           //zahodit v metod pustym,ne uspel razobratsya v chem prichina
            var reader =
              _appDbContext.Readers.SingleOrDefault(
                  s => s.ReaderId == vydacha.SelectedValue.ReaderId);

            foreach(Book book in vydacha.MultiValue)
            {
                
                if (book.InStock > 0) //esli v biblioteke net etoi knigi to vydavatsya ne budet
                {
                    reader.ReaderBooks.Add(book);
                    var bookChosen =
                       _appDbContext.Books.SingleOrDefault(
                           s => s.BookId == book.BookId);
                    bookChosen.InStock--;
                }
            }
             return RedirectToRoute(new { controller = "Books", action = "Index" });
        }
    }
}