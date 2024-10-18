using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Books.Pages;

public class IndexModel : PageModel
{
    static HttpClient client = new HttpClient();


    public IList<Book> BookList { get; set; }

    //public void OnPost()
    //{


    //}

    //public void OnGet()
    //{

    //}

    public async Task<IActionResult> OnGetAsync()
    {
        BookList = new List<Book>();
        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        BookList = new List<Book>();
        BookList = await RunAsync();
        return Page();
    }


    static async Task<List<Book>> RunAsync()
    {
        List<Book> list = new List<Book>();
        // I Liga BASE del API
        client.BaseAddress = new Uri("https://localhost:7249/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Console.WriteLine("SSSSSS");
        try
        {
            //Path interno del end point
            HttpResponseMessage Res = await client.GetAsync("api/Book");
            Console.WriteLine("SSS");
            //Checar si el estatus es correcto del HttpClient if (Res.IsSuccessStatusCode)
            {
                //Obtener el response recibido web api
                var apiResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing la respuesta del web api y guardarlo en la lista
                Console.WriteLine("pre");
                Console.WriteLine(apiResponse);
                list = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                Console.WriteLine(list);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return list;
        }
        //Regresa la lista de usuario leida del API return climaList:

        return list;
    }
}

