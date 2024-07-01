using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class SeatsModel : BaseModel
    {
    }

    public static class SeatsModelFactory
    {
        public static List<SeatsModel> GetSeatsModels()
        {
            return new List<SeatsModel>
        {
            new SeatsModel { Id = "seats-1", Value = "1", Label = "1" },
            new SeatsModel { Id = "seats-12", Value = "12", Label = "12" },
            new SeatsModel { Id = "seats-2", Value = "2", Label = "2" },
            new SeatsModel { Id = "seats-3", Value = "3", Label = "3" },
            new SeatsModel { Id = "seats-4", Value = "4", Label = "4" },
            new SeatsModel { Id = "seats-5", Value = "5", Label = "5" },
            new SeatsModel { Id = "seats-6", Value = "6", Label = "6" },
            new SeatsModel { Id = "seats-7", Value = "7", Label = "7" },
            new SeatsModel { Id = "seats-8", Value = "8", Label = "8" },
            new SeatsModel { Id = "seats-9", Value = "9", Label = "9" },
            new SeatsModel { Id = "seats-Other", Value = "Other", Label = "Other" }
        };
        }
    }

}
