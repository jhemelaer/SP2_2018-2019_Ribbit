using System;
using System.Linq;

namespace test_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //scraper voorbeeld van gouden gids

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.yellowpages.com/search?search_terms=Software&geo_location_terms=Sydney2C+ND");

            var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='business-name']").ToList();

            foreach (var item in HeaderNames)
            {
                Console.WriteLine(item.InnerText);
            }


        }
    }
}
