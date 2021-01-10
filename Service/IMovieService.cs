using MoviStore.Models;
using MoviStore.ViewModel;
using System.Collections.Generic;

namespace Service
{
    public interface IMovieService
    {
        Movie Create(Movie model);
        List<Category> GetCategories();
        Movie GetMovieById(int movieId);
        List<MovieVm> Search(string query);
        Movie Update(Movie model);
    }
}