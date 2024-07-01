using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class ReserveRangeModel
    {
        public int MinReserve {  get; set; } = 0;
        public int MaxReserve { get; set; }
        public bool? UnReservedOnly { get; set; }
    }
    public static class ReserveModelFactory
    {
        public static ReserveRangeModel GetReserveRangeModel(int minReserve, int maxReserve, bool? unReservedOnly)
        {
            return new ReserveRangeModel
            {
                MinReserve = minReserve,
                MaxReserve = maxReserve,
                UnReservedOnly = unReservedOnly
            };
        }
    }
}
