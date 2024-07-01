using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegalAuctionsWebCrawler.Models
{
    public class MakeModel : BaseModel
    {
    }

    public static class MakeModelFactory
    {
        public static List<MakeModel> GetMakeModels()
        {
            return new List<MakeModel>
        {
            new MakeModel { Id = "make-9_2", Value = "9 2", Label = "9 2" },
            new MakeModel { Id = "make-Acura", Value = "Acura", Label = "Acura" },
            new MakeModel { Id = "make-Arctic_Cat", Value = "Arctic Cat", Label = "Arctic Cat" },
            new MakeModel { Id = "make-Audi", Value = "Audi", Label = "Audi" },
            new MakeModel { Id = "make-Bmw", Value = "Bmw", Label = "Bmw" },
            new MakeModel { Id = "make-Bobcat", Value = "Bobcat", Label = "Bobcat" },
            new MakeModel { Id = "make-Brandt", Value = "Brandt", Label = "Brandt" },
            new MakeModel { Id = "make-Buick", Value = "Buick", Label = "Buick" },
            new MakeModel { Id = "make-Cadillac", Value = "Cadillac", Label = "Cadillac" },
            new MakeModel { Id = "make-Can_am", Value = "Can-am", Label = "Can-am" },
            new MakeModel { Id = "make-Cargo_Mate", Value = "Cargo Mate", Label = "Cargo Mate" },
            new MakeModel { Id = "make-Cf_Moto", Value = "Cf Moto", Label = "Cf Moto" },
            new MakeModel { Id = "make-Cfmoto", Value = "Cfmoto", Label = "Cfmoto" },
            new MakeModel { Id = "make-Chevrolet", Value = "Chevrolet", Label = "Chevrolet" },
            new MakeModel { Id = "make-Chrysler", Value = "Chrysler", Label = "Chrysler" },
            new MakeModel { Id = "make-Cimc", Value = "Cimc", Label = "Cimc" },
            new MakeModel { Id = "make-Cross_Trailers", Value = "Cross Trailers", Label = "Cross Trailers" },
            new MakeModel { Id = "make-Dodge", Value = "Dodge", Label = "Dodge" },
            new MakeModel { Id = "make-Ducati", Value = "Ducati", Label = "Ducati" },
            new MakeModel { Id = "make-Dutchmen", Value = "Dutchmen", Label = "Dutchmen" },
            new MakeModel { Id = "make-Fiat", Value = "Fiat", Label = "Fiat" },
            new MakeModel { Id = "make-Ford", Value = "Ford", Label = "Ford" },
            new MakeModel { Id = "make-Forest_River", Value = "Forest River", Label = "Forest River" },
            new MakeModel { Id = "make-Forest_River_Rockwoo", Value = "Forest River Rockwoo", Label = "Forest River Rockwoo" },
            new MakeModel { Id = "make-Freightliner", Value = "Freightliner", Label = "Freightliner" },
            new MakeModel { Id = "make-Genesis", Value = "Genesis", Label = "Genesis" },
            new MakeModel { Id = "make-Gio", Value = "Gio", Label = "Gio" },
            new MakeModel { Id = "make-Gmc", Value = "Gmc", Label = "Gmc" },
            new MakeModel { Id = "make-Great_Dane_Trailers", Value = "Great Dane Trailers", Label = "Great Dane Trailers" },
            new MakeModel { Id = "make-Gulf_Stream", Value = "Gulf Stream", Label = "Gulf Stream" },
            new MakeModel { Id = "make-Harley_davidson", Value = "Harley-davidson", Label = "Harley-davidson" },
            new MakeModel { Id = "make-Heartland", Value = "Heartland", Label = "Heartland" },
            new MakeModel { Id = "make-Heartland_Rv", Value = "Heartland Rv", Label = "Heartland Rv" },
            new MakeModel { Id = "make-Hino", Value = "Hino", Label = "Hino" },
            new MakeModel { Id = "make-Honda", Value = "Honda", Label = "Honda" },
            new MakeModel { Id = "make-Hyundai", Value = "Hyundai", Label = "Hyundai" },
            new MakeModel { Id = "make-Hyundai_Translead", Value = "Hyundai Translead", Label = "Hyundai Translead" },
            new MakeModel { Id = "make-Indian", Value = "Indian", Label = "Indian" },
            new MakeModel { Id = "make-Infiniti", Value = "Infiniti", Label = "Infiniti" },
            new MakeModel { Id = "make-International", Value = "International", Label = "International" },
            new MakeModel { Id = "make-Jayco", Value = "Jayco", Label = "Jayco" },
            new MakeModel { Id = "make-Jeep", Value = "Jeep", Label = "Jeep" },
            new MakeModel { Id = "make-John_Deere", Value = "John Deere", Label = "John Deere" },
            new MakeModel { Id = "make-Kawasaki", Value = "Kawasaki", Label = "Kawasaki" },
            new MakeModel { Id = "make-Kenworth", Value = "Kenworth", Label = "Kenworth" },
            new MakeModel { Id = "make-Keystone", Value = "Keystone", Label = "Keystone" },
            new MakeModel { Id = "make-Kia", Value = "Kia", Label = "Kia" },
            new MakeModel { Id = "make-Lakota", Value = "Lakota", Label = "Lakota" },
            new MakeModel { Id = "make-Lamborghini", Value = "Lamborghini", Label = "Lamborghini" },
            new MakeModel { Id = "make-Land_Rover", Value = "Land Rover", Label = "Land Rover" },
            new MakeModel { Id = "make-Lexus", Value = "Lexus", Label = "Lexus" },
            new MakeModel { Id = "make-Lincoln", Value = "Lincoln", Label = "Lincoln" },
            new MakeModel { Id = "make-Load_Trail", Value = "Load Trail", Label = "Load Trail" },
            new MakeModel { Id = "make-Marathon", Value = "Marathon", Label = "Marathon" },
            new MakeModel { Id = "make-Mastercraft", Value = "Mastercraft", Label = "Mastercraft" },
            new MakeModel { Id = "make-Mazda", Value = "Mazda", Label = "Mazda" },
            new MakeModel { Id = "make-Mercedes", Value = "Mercedes", Label = "Mercedes" },
            new MakeModel { Id = "make-Mercedes_benz", Value = "Mercedes-benz", Label = "Mercedes-benz" },
            new MakeModel { Id = "make-Middlebury_Trailers", Value = "Middlebury Trailers", Label = "Middlebury Trailers" },
            new MakeModel { Id = "make-Mini", Value = "Mini", Label = "Mini" },
            new MakeModel { Id = "make-Mitsubishi", Value = "Mitsubishi", Label = "Mitsubishi" },
            new MakeModel { Id = "make-Nissan", Value = "Nissan", Label = "Nissan" },
            new MakeModel { Id = "make-Pontiac", Value = "Pontiac", Label = "Pontiac" },
            new MakeModel { Id = "make-Porsche", Value = "Porsche", Label = "Porsche" },
            new MakeModel { Id = "make-Prolite", Value = "Prolite", Label = "Prolite" },
            new MakeModel { Id = "make-Ram", Value = "Ram", Label = "Ram" },
            new MakeModel { Id = "make-Saturn", Value = "Saturn", Label = "Saturn" },
            new MakeModel { Id = "make-Scion", Value = "Scion", Label = "Scion" },
            new MakeModel { Id = "make-Side_Dump_Industries", Value = "Side Dump Industries", Label = "Side Dump Industries" },
            new MakeModel { Id = "make-Sri_Homes_Ulc", Value = "Sri Homes Ulc", Label = "Sri Homes Ulc" },
            new MakeModel { Id = "make-Sterling", Value = "Sterling", Label = "Sterling" },
            new MakeModel { Id = "make-Stoughton_Trailers", Value = "Stoughton Trailers", Label = "Stoughton Trailers" },
            new MakeModel { Id = "make-Strick_Corp", Value = "Strick Corp", Label = "Strick Corp" },
            new MakeModel { Id = "make-Subaru", Value = "Subaru", Label = "Subaru" },
            new MakeModel { Id = "make-Sun_Valley", Value = "Sun Valley", Label = "Sun Valley" },
            new MakeModel { Id = "make-Sur_ron", Value = "Sur-ron", Label = "Sur-ron" },
            new MakeModel { Id = "make-Suzuki", Value = "Suzuki", Label = "Suzuki" },
            new MakeModel { Id = "make-Tesla", Value = "Tesla", Label = "Tesla" },
            new MakeModel { Id = "make-Toyota", Value = "Toyota", Label = "Toyota" },
            new MakeModel { Id = "make-Utility", Value = "Utility", Label = "Utility" },
            new MakeModel { Id = "make-Utility_Trailer_Manu", Value = "Utility Trailer Manu", Label = "Utility Trailer Manu" },
            new MakeModel { Id = "make-Utility_Trailers", Value = "Utility Trailers", Label = "Utility Trailers" },
            new MakeModel { Id = "make-Vanguard", Value = "Vanguard", Label = "Vanguard" },
            new MakeModel { Id = "make-Volkswagen", Value = "Volkswagen", Label = "Volkswagen" },
            new MakeModel { Id = "make-Volvo", Value = "Volvo", Label = "Volvo" },
            new MakeModel { Id = "make-Wabash", Value = "Wabash", Label = "Wabash" },
            new MakeModel { Id = "make-Western_Star", Value = "Western Star", Label = "Western Star" }
        };
        }
    }

}
