using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class FuelTypeModel : BaseModel
    {
    }

    public static class FuelTypeModelFactory
    {
        public static List<FuelTypeModel> GetFuelTypeModels()
        {
            return new List<FuelTypeModel>
        {
            new FuelTypeModel { Id = "fuel_type-Gas", Value = "Gas", Label = "Gas" },
            new FuelTypeModel { Id = "fuel_type-Diesel", Value = "Diesel", Label = "Diesel" },
            new FuelTypeModel { Id = "fuel_type-Electric", Value = "Electric", Label = "Electric" }
        };
        }
    }

}
