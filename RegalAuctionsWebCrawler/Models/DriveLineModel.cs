using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class DrivelineModel : BaseModel
    {
    }

    public static class DrivelineModelFactory
    {
        public static List<DrivelineModel> GetDrivelineModels()
        {
            return new List<DrivelineModel>
        {
            new DrivelineModel { Id = "driveline-2WD", Value = "2WD", Label = "2WD" },
            new DrivelineModel { Id = "driveline-4WD", Value = "4WD", Label = "4WD" }
        };
        }
    }

}
