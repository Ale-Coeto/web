using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace SuperheroName.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { set; get; } = "";

    [BindProperty]
    public int Month { set; get; } = -1;

    [BindProperty]
    public int Season { set; get; } = -1;

    [BindProperty]
    public string Date { set; get; } = "";

    private List<string> letterNames = new List<string>
    {
        "Captain", "Wonder", "Super", "Phantom", "Dark", "Incredible", "Professor", "Iron", "Hawk", "Archer", "Steel", "Bolt",
        "Atomic", "Torch", "Space", "Mega", "Turbo", "Fantastic", "Invisible", "Night", "Silver", "Aqua", "Amazing", "Giant", "Rock", "Power"
    };

    public List<string>[] seasonMonthNames { get; } = new List<string>[] {
        new List<string> { "Bloom", "Blossom", "Raindrop", "Tulip", "Petal", "Fresh", "Daffodil", "Sprout", "Falcon", "Umbrella", "Butterfly", "Garden" },
        new List<string> { "Sunshine", "Sea", "Heatwave", "Tropical", "Sandcastle", "Seashell", "Palm", "Wave", "Flare", "Heat", "Hot", "Shark" },
        new List<string> { "Snowflake", "Freeze", "Blizzard", "Iceberg", "Frost", "Snowman", "Glacier", "Polar", "Blue", "Snow", "Ice", "Evergreen" },
        new List<string> { "Harvest", "Maple", "Wind", "Haystack", "Thunder", "Rustic", "Cider", "Cozy", "Leaves", "Eagle", "Ninja", "Cider" }
    };


    public string HeroName { set; get; } = "";
    public string Message { set; get; } = "";
    public int bday { set; get; }
    public int bmonth { set; get; }
    public int byear { set; get; }

    public bool correctName { set; get; } = true;
    public bool correctSeason { set; get; } = true;
    public bool correctMonth { set; get; } = true;
    public bool correctBirthday { set; get; } = true;
    public bool noBirthday { set; get; } = false;

    private void resetVars()
    {
        correctName = true;
        correctMonth = true;
        correctBirthday = true;
        noBirthday = false;
    }

    private string getName()
    {
        string hero = "";
        char firstLetter = Name[0];
        int value = char.ToLower(firstLetter) - 'a';

        hero += letterNames[value];
        hero += " ";
        hero += seasonMonthNames[Season][Month];

        return hero;
    }
    public void OnGet()
    {

    }

    public void OnPost()
    {
        resetVars();
        

        if (Date == null || Date == "")
        {
            correctBirthday = false;
            noBirthday = true;
            Message = "Please select or write your birthday!";
        } else
        {
            try
            {
                DateTime date = DateTime.ParseExact(Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (date > DateTime.Now)
                {
                    correctBirthday = false;
                    Message = "Please select a valid birthday!";
                }


                bmonth = date.Month;
                bday = date.Day;
                byear = date.Year;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = "Invalid birthday";
                correctBirthday = false;
            }
        }

        
        
        if (Month == -1)
        {
            correctMonth = false;
            Message = "Please select your favorite month!";
        }

        if (Season == -1)
        {
            correctSeason = false;
            Message = "Please select your favorite season!";
        }

        if (Name == "" || Name == null)
        {
            correctName = false;
            Message = "Please write your name!";
        }


        if (correctName && correctSeason && correctMonth && correctBirthday)
        {
            HeroName = getName();
            Response.Redirect($"Result?name={HeroName}&month={bmonth}&season={Season}");
        }
    }
}

