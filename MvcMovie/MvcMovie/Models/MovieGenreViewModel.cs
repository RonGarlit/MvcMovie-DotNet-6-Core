using Microsoft.AspNetCore.Mvc.Rendering;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-6.0

namespace MvcMovie.Models
{
	public class MovieGenreViewModel
	{
		public List<Movie>? Movies { get; set; }
		public SelectList? Genres { get; set; }
		public string? MovieGenre { get; set; }
		public string? SearchString { get; set; }
	}
}