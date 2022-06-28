using Microsoft.AspNetCore.Mvc.Rendering;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-6.0

namespace MvcMovie.Models
{
	//	The movie-genre view model will contain:
	//
	//	A list of movies.
	//	A SelectList containing the list of genres. This allows the user to select a genre from the list.
	//	MovieGenre, which contains the selected genre.
	//	SearchString, which contains the text users enter in the search text box.

	public class MovieGenreViewModel
	{
		public List<Movie>? Movies { get; set; }
		public SelectList? Genres { get; set; }
		public string? MovieGenre { get; set; }
		public string? SearchString { get; set; }
	}
}