using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Agenda.WebApi.Helpers
{
    public static class HttpResponseExtension
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int totalPages, int totalItemsPerPage, int totalItems)
        {
            var paginationHeader = new PaginationHeader(currentPage, totalPages, totalItemsPerPage, totalItems);

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}