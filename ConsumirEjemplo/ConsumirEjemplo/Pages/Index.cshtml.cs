using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ConsumirEjemplo.Pages;

public class IndexModel : PageModel
{
    static HttpClient client = new HttpClient();

    public async Task<IActionResult> OnGetAsync()
    {
        List<WeatherForecast>  climaList = await RunAsync();
        return Page();

    }

    public async Task<ActionResult> OnPostAsync()
    {
        List<WeatherForecast>  climaList = await RunAsync();
        return Page();
    }


        static async Task<List<WeatherForecast>> RunAsync()
    {
        List<WeatherForecast> climaList = new List<WeatherForecast>();
        // I Liga BASE del API
        client.BaseAddress = new Uri("https://localhost: 7161/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/son"));
        try
        {
            //Path interno del end point
            HttpResponseMessage Res = await client.GetAsync("WeatherForecast");
            //Checar si el estatus es correcto del HttpClient if (Res.IsSuccessStatusCode)
            {
                //Obtener el response recibido web api
                var apiResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing la respuesta del web api y guardarlo en la lista
                climaList = JsonConvert.DeserializeObject<List<WeatherForecast>>(apiResponse);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        //Regresa la lista de usuario leida del API return climaList:

        return climaList;
    }
}

