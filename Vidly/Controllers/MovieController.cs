using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie/List

        public ActionResult MovieList()
        {
            var movies = _context.Movie.Include(c => c.Genre).ToList();

            return View(movies);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(newviewmodel viewmodel)
        {
           /* if (!ModelState.IsValid)
            {
                var viewmodels = new newviewmodel
                {
                    genre = _context.Genre.ToList(),
                    movie = viewmodel.movie
                };
                return View("EditMovieDetails",viewmodels);

            }*/
                if (viewmodel.movie.MovieId == 0)
            {
                viewmodel.movie.DateAdded = DateTime.Now;
                _context.Movie.Add(viewmodel.movie);
            }
            else
            {
                var movieindb = _context.Movie.Single(m => m.MovieId == viewmodel.movie.MovieId);
                movieindb.MovieName = viewmodel.movie.MovieName;
                movieindb.NumberInStock = viewmodel.movie.NumberInStock;
                movieindb.GenreId = viewmodel.movie.GenreId;
                
                movieindb.ReleaseDate = viewmodel.movie.ReleaseDate;

            }
           // try
            //{
                _context.SaveChanges();
            //}
           
            return RedirectToAction("MovieList","Movie");
        }
        public ActionResult New()
        {
            var genres = _context.Genre.ToList();

            var viewmodel = new newviewmodel
            {
                genre = genres
            };
            return View("EditMovieDetails",viewmodel);
        }
        public ActionResult EditMovieDetails(int id)
        {
            var movies = _context.Movie.SingleOrDefault(c => c.MovieId == id);

            if (movies == null)
                return HttpNotFound();

            var viewmodel = new newviewmodel
            {
                genre = _context.Genre.ToList(),
                movie = movies
            };

            
            return View(viewmodel);
        }
        
        // GET: Movie/edit/ 1-









        /*  public ActionResult Edit(int id)
                                             {

                                                 return Content("ID=" +id);
                                             }
                                             */
        /* public ActionResult Index(int? pageIndex, string sortBy)
         {
             if (!pageIndex.HasValue)
                 pageIndex = 1;
             if (String.IsNullOrWhiteSpace(sortBy))
                 sortBy = "HELLO";

                return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));

         }
         */
    }
}