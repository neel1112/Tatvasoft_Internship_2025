using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Entities.Models.Request
{
    public class UserRequestModel
    {
        public string SortBy { get; set; } = "Name";
        public string SortDirection { get; set; } = "asc";

        public string Search { get; set; } = string.Empty;

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 0;
    }
}
