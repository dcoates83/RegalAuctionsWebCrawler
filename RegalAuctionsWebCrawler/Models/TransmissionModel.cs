using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class TransmissionModel: BaseModel
    {
    }

    public static class TransmissionModelFactory
    {
        public static List<TransmissionModel> GetTransmissionModels()
        {
            return new List<TransmissionModel>
        {
            new TransmissionModel { Id = "transmission-Automatic", Value = "Automatic", Label = "Automatic" },
            new TransmissionModel { Id = "transmission-Manual", Value = "Manual", Label = "Manual" }
        };
        }
    }

}
