using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuperheroName.Pages
{
	public class ResultModel : PageModel
    {
        public string HeroName { set; get; } = "";
        public string Month { set; get; } = "";
        public string MonthHero { set; get; } = "";
        public string ImgPath { set; get; } = "";
        public string Description { set; get; } = "";

        public static List<string> months = new List<string> {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
        };

        public static List<string> descriptions = new List<string> {
            "Your hero represents the promise of new beginnings and fresh starts, embracing the beauty of nature's rebirth.",
            "Your hero radiates warmth and energy, embracing the joy of sunny days and outdoor adventures.",
            "Your hero embodies resilience and fortitude, standing strong in the face of adversity like a towering mountain in a snowstorm.",
            "Your hero is a beacon of hope and renewal, embracing change and growth like the vibrant colors of autumn leaves."
        };



        List<string> superheroesByMonth = new List<string>
        {
            "The Flash (Barry Allen)",       // January
            "Black Panther (T'Challa)",      // February
            "Green Arrow (Oliver Queen)",    // March
            "Captain America (Steve Rogers)",// April
            "Iron Man (Tony Stark)",         // May
            "Batman (Bruce Wayne)",          // June
            "Spider-Man (Peter Parker)",     // July
            "Superman (Clark Kent/Kal-El)",  // August
            "Hawkeye (Clint Barton)",        // September
            "Nightwing (Dick Grayson)",      // October
            "Hulk (Bruce Banner)",           // November
            "Deadpool (Wade Wilson)"         // December
        };

        public void OnGet()
        {
            int monthValue = 0;
            int seasonValue = 0;

            if (Request.Query.ContainsKey("name"))
            {
                HeroName = Request.Query["name"].ToString() ?? "";
            }

            if (Request.Query.ContainsKey("month"))
            {
                int.TryParse(Request.Query["month"], out monthValue);
            }

            if (Request.Query.ContainsKey("season"))
            {
                int.TryParse(Request.Query["season"], out seasonValue);
            }

            Month = months[monthValue-1];
            MonthHero = superheroesByMonth[monthValue-1];
            Description = descriptions[seasonValue];
            ImgPath = "/images/" + monthValue + ".jpeg";
        }
    }
}
