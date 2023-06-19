using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorPagesCurrency.Models;
using Newtonsoft.Json.Linq;

[Route("api/currency")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ExchangeRateController()
    {
        _httpClient = new HttpClient();
    }

    [HttpGet]
    public async Task<IActionResult> GetCurrencyExchangeRates()
    {
        Console.WriteLine();
        Console.WriteLine("GetCurrencyExchangeRates method called.");
        Console.WriteLine();
        string apiKey = "19a470d7d41c43bfaceb376a1b378974";
        string baseUrl = $"https://openexchangerates.org/api";

         string historicalUrl = $"{baseUrl}/historical/{{date}}.json?app_id={apiKey}";

        DateTime currentDate = DateTime.UtcNow;
        DateTime startDate = currentDate.AddDays(-1);

        var exchangeRateData = await GetExchangeRateData(startDate, currentDate, historicalUrl);


        IServiceProvider serviceProvider = HttpContext.RequestServices;
        await SeedData.UpdateExchangeRate(serviceProvider, exchangeRateData);

        return Ok(exchangeRateData);
    }

    private async Task<List<LastThirtyDaysRate>> GetExchangeRateData(DateTime startDate, DateTime endDate, string urlTemplate)
    {
        var exchangeRateData = new List<LastThirtyDaysRate>();

        // Iterate over the date range and make requests for each day
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            string formattedUrl = urlTemplate.Replace("{date}", date.ToString("yyyy-MM-dd"));

            Console.WriteLine();
            Console.WriteLine(formattedUrl);



            var response = await _httpClient.GetAsync(formattedUrl);

            //Console.WriteLine($"Htpp statusCode {response.StatusCode}");
            //Console.WriteLine($"Htpp content {response.Content}");
            string responseDataX = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Response Content: {responseDataX}");

            
            if(response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseData);
                decimal exchangeRate = json["rates"]["USD"].Value<decimal>(); 

                var responseDataTwo = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {responseDataTwo}");
                Console.WriteLine($"Exchange Rate {exchangeRate}");


                var data = new LastThirtyDaysRate
                {
                    ExchangeRateElement = exchangeRate,
                    dateTime = date
                };
                exchangeRateData.Add(data);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"ExchangeRateData Count: {exchangeRateData.Count}");
        Console.WriteLine($"ListExchange is Null: {exchangeRateData == null}");
        Console.WriteLine();


        return exchangeRateData;
    }
}