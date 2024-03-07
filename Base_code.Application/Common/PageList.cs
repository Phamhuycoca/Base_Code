using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Common
{
    public class PageList<T>
    {
        public List<T>? items { get; set; }
        public int totalItems { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        /*   public string? orderBy {  get; set; }
           public string? orderDirection {  get; set; }
           public string? keyword { get; set; }*/

        /* public PageList(List<T> items,int totalItems,int page,int limit,string orderBy,string orderDirection,string keyword)
         {
             this.items = items;
             this.totalItems = totalItems;
             this.page = page;
             this.limit = limit;
             this.orderBy = orderBy;
             this.orderDirection = orderDirection;
             this.keyword = keyword;
         }*/
        public PageList(List<T> items, int totalItems, int page, int limit)
        {
            this.items = items;
            this.totalItems = totalItems;
            this.page = page;
            this.limit = limit;
        }
        public bool HasPreviousPage => (page > 1);
        public bool HasNextPage => (page < totalItems);
        public int FirstPage => (page - 1) * limit + 1;
        public int LastPage => Math.Min(page * limit, totalItems);
        public static PageList<T> listData(IEnumerable<T> data, int page, int limit)
        {
            var count = data.Count();
            var items = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new PageList<T>(items, count, page, limit);
        }

    }
}
