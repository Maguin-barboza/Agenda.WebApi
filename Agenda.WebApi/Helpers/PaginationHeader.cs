namespace Agenda.WebApi.Helpers
{
	public class PaginationHeader
	{
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int TotalItemsPerPage { get; set; }
		public int TotalItems { get; set; }

		public PaginationHeader(int currentPage, int totalPages, int totalItemsPerPage, int totalItems)
		{
			this.CurrentPage = currentPage;
			this.TotalPages = totalPages;
			this.TotalItemsPerPage = totalItemsPerPage;
			this.TotalItems = totalItems;
		}
	}
}