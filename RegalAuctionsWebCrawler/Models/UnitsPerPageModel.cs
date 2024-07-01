using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class UnitsPerPageModel : BaseModel
    {
    }

    public static class UnitsPerPageModelFactory
    {
        public static List<UnitsPerPageModel> GetUnitsPerPageModels()
        {
            return new List<UnitsPerPageModel>
        {
            new UnitsPerPageModel { Id = "units-25", Value = "25", Label = "25" },
            new UnitsPerPageModel { Id = "units-50", Value = "50", Label = "50" },
            new UnitsPerPageModel { Id = "units-75", Value = "75", Label = "75" },
            new UnitsPerPageModel { Id = "units-100", Value = "100", Label = "100" }
        };
        }
    }

}
