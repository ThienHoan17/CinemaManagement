using MoviStore.Models;
using MoviStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MovieService : IMovieService
    {
        private MovieDbContext dbContext;

        public MovieService(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Movie GetMovieById(int movieId)
        {
            return dbContext.Movies.Single(x => x.Id == movieId);
        }
        public List<MovieVm> Search(string query)
        {

            var moviesQuery = dbContext.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(query))
            {
                moviesQuery = moviesQuery.Where(x => x.Name.Contains(query));
            }

            var movies = moviesQuery.Select(x => new MovieVm
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                Director = x.Director,
                ImageUrl = x.ImageUrl,
                Ownner = x.Ownner,
                ShowDate = x.ShowDate,
                Year = x.Year

            }).ToList();
            return movies;
        }

        public Movie Create(Movie model)
        {
            model.ImageUrl = "/star-wars-jedi-fallen-order-danh-gia.jpg";

            var categories = dbContext.Movies.Add(model);
            dbContext.SaveChanges();
            return model;
        }
        public Movie Update(Movie model)
        {
            var movieDb = dbContext.Movies.Single(x => x.Id == model.Id);
            movieDb.Name = model.Name;
            movieDb.CategoryId = model.CategoryId;
            movieDb.Director = model.Director;
            movieDb.Ownner = model.Ownner;
            movieDb.Year = model.Year;
            var categories = dbContext.Movies.Update(movieDb);
            dbContext.SaveChanges();
            return movieDb;
        }
        public List<Category> GetCategories()
        {
            var categories = dbContext.Categories.ToList();
            return categories;
        }
    }
}
