using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Models
{
    public class PagedList<T> : List<T>
        where T: Entity

    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<T>> CreateAsync(IEntityRepository<T> repository,
            int pageNumber, int pageSize, string[] includeNames = null)
        {
            var count = (await repository.GetAsync()).Count;
            var items = new List<T>();

            items = includeNames == null? 
                    await repository
                        .GetPageListAsync(
                            ((pageNumber - 1) * pageSize), 
                            pageSize
                        ) :
                    await repository
                        .GetPageListWithTwoIncludesAsync(
                            ((pageNumber - 1) * pageSize), 
                            pageSize, 
                            includeNames
                        );
            
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
