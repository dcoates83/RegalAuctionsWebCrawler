using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class PageModel : BaseModel
    {
        public int PageNumber { get; set; }
    }

    public static class PageModelFactory
    {
        public static PageModel GetPageModel(int pageNumber)
        {
            return new PageModel
            {
                Id = $"page-{pageNumber}",
                Value = pageNumber.ToString(),
                Label = pageNumber.ToString(),
                PageNumber = pageNumber
            };
        }
    }

}
