using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Contracts;

public interface IMovieRepository : IRepository<Movie, Guid>
{
}
