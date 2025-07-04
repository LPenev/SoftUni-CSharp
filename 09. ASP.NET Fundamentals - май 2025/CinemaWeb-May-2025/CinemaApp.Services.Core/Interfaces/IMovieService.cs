﻿using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Core.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();

    Task AddAsync(MovieFormViewModel model);

    Task <MovieDetailsViewModel> GetByIdAsync (string id);

    Task<MovieFormViewModel> GetByIdToEditAsync(string id);

    Task UpdateAsync(MovieFormViewModel model);

    Task SoftDeleteAsync(string id);
    Task HardDeleteAsync(string id);
}
