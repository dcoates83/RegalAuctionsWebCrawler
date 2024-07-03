using RegalAuctionsWebCrawler.Models;
using System.Collections.Specialized;
using System.Web;

public static class UrlHelper
{
    private const string BaseUrl = "https://www.regalauctions.com/inventory.php?a=listing&listType=detail&sort=lot-asc&unitsPerPage={0}&page={1}";

    public static string GenerateInventoryUrl(
        int unitsPerPage = 100,
        int page = 1,
        YearRangeModel? yearRange = null,
        OdometerRangeModel? odometerRange = null,
        List<BaseModel>? unitTypes = null,
        List<BaseModel>? makes = null,
        List<BaseModel>? transmissions = null,
        List<BaseModel>? engines = null,
        List<BaseModel>? drivelines = null,
        List<BaseModel>? fuelTypes = null,
        List<BaseModel>? seats = null)
    {
        string url = string.Format(BaseUrl, unitsPerPage, page);
        NameValueCollection queryParameters = HttpUtility.ParseQueryString(string.Empty);

        if (yearRange != null)
        {
            queryParameters["search[year][min]"] = yearRange.MinYear.ToString();
            queryParameters["search[year][max]"] = yearRange.MaxYear.ToString();
        }

        if (odometerRange != null)
        {
            queryParameters["search[odometer][min]"] = odometerRange.MinOdometer.ToString();
            queryParameters["search[odometer][max]"] = odometerRange.MaxOdometer.ToString();
        }

        AddListToQueryParameters(queryParameters, "unit_type", unitTypes);
        //AddListToQueryParameters(queryParameters, "make", makes);
        AddListToQueryParameters(queryParameters, "transmission", transmissions);
        AddListToQueryParameters(queryParameters, "engine", engines);
        AddListToQueryParameters(queryParameters, "driveline", drivelines);
        AddListToQueryParameters(queryParameters, "fuel_type", fuelTypes);
        AddListToQueryParameters(queryParameters, "seats", seats);

        return $"{url}&{queryParameters}";
    }

    private static void AddListToQueryParameters(
        NameValueCollection queryParameters,
        string key,
        List<BaseModel> models)
    {
        if (models != null && models.Count > 0)
        {
            foreach (BaseModel model in models)
            {
                queryParameters.Add($"search[{key}][]", model.Value);
            }
        }
    }

    public static string ChangePageNumber(string url, int newPageNumber)
    {
        UriBuilder uriBuilder = new(url);
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query.Set("page", newPageNumber.ToString());
        uriBuilder.Query = query.ToString();
        return uriBuilder.ToString();
    }
}
