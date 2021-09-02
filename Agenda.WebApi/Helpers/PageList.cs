using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Agenda.WebApi.Helpers
{
    public class PageList<T>: List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        
        public PageList(List<T> items, int currentPage, int pageSize, int totalPages)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            this.AddRange(items);
        }

        public static async Task<PageList<T>> GetPageList(IQueryable<T> source, int currentPage, int pageSize)
        {
            int totalRegistros = await source.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalRegistros / (double)pageSize);
            List<T> items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            
            return new PageList<T>(items, currentPage, pageSize, totalPages);
        }
    }
}