using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Fantasy_Football.Models
{
    [Table("NflNews")]
    public class NflNews
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public NflNews() { }
        public NflNews(string title, string description, string link, DateTime date)
        {
            Title = title;
            Description = description;
            Link = link;
            Date = date;
        }
        public static async Task<List<NflNews>> GetFeeds()
        {
            string rssUrl = "http://rss.footballguys.com/bloggerrss.xml";
            List<NflNews> news = new List<NflNews>();

            try
            {
                WebRequest request = WebRequest.Create(rssUrl);
                WebResponse response = await request.GetResponseAsync();
                XmlReader reader = XmlReader.Create(response.GetResponseStream());
                XDocument xDoc = XDocument.Load(reader);
                //XNamespace ns = "http://www.w3.org/2005/Atom";


                var items = from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 date = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                             };
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        var newDescription = i.description.Replace("&quot;", @"""");
                        NflNews newNews = new NflNews(i.title, newDescription, i.link, Convert.ToDateTime(i.date));
                        news.Add(newNews);
                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }

            return news;
        }
    }
}
