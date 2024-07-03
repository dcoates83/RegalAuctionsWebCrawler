namespace RegalAuctionsWebCrawler.Models
{
    public class UnitTypeModel : BaseModel
    {

    }

    public static class UnitTypeModelFactory
    {
        public static List<BaseModel> GetUnitTypeModels()
        {
            return
        [
            new UnitTypeModel { Id = "unit_type-C", Value = "C", Label = "Car" },
            new UnitTypeModel { Id = "unit_type-T", Value = "T", Label = "Truck" },
            new UnitTypeModel { Id = "unit_type-U", Value = "U", Label = "Sport Utility" },
            new UnitTypeModel { Id = "unit_type-V", Value = "V", Label = "Van" },
            new UnitTypeModel { Id = "unit_type-RV", Value = "RV", Label = "Recreational Vehicle" },
            new UnitTypeModel { Id = "unit_type-EQ", Value = "EQ", Label = "Equipment" },
            new UnitTypeModel { Id = "unit_type-M", Value = "M", Label = "Power Sport" },
            new UnitTypeModel { Id = "unit_type-other", Value = "other", Label = "Other" }
        ];
        }
    }

}
