using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class YearRangeModel
    {
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }

    public static class YearRangeModelFactory
    {
        public static YearRangeModel GetYearRangeModel(int minYear, int maxYear)
        {
            return new YearRangeModel
            {
                MinYear = minYear,
                MaxYear = maxYear
            };
        }
    }

}
