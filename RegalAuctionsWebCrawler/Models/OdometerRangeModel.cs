using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class OdometerRangeModel
    {
        public int MinOdometer { get; set; }
        public int MaxOdometer { get; set; }
    }

    public static class OdometerRangeModelFactory
    {
        public static OdometerRangeModel GetOdometerRangeModel(int minOdometer, int maxOdometer)
        {
            return new OdometerRangeModel
            {
                MinOdometer = minOdometer,
                MaxOdometer = maxOdometer
            };
        }
    }

}
