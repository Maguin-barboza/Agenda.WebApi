namespace Agenda.WebApi.Helpers
{
    public class Paginations
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public int? Id { get; set; } = null;
		public string Nome { get; set; } = string.Empty;
		public int? TipoId { get; set; } = null;
    }
}