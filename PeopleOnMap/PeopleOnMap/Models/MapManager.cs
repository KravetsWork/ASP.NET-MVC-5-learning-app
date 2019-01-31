using System.Web;
using System.Xml;

namespace PeopleOnMap.Models
{
    public class MapManager
    {
        const string API_KEY = "AIzaSyCmorpN8D2Cbn_DLE5JVXUdOd9i72Y-k_o";
        const string URL_API = "https://www.google.ru/maps/api/geocode/xml?key=" + API_KEY + "&address=";
        const string XML_PATH = "GeocodeResponse/result/geometry/location/"; 

        public static void SetCoord(Person person)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(URL_API + HttpUtility.UrlEncode(person.address));
            person.lat = xml.SelectSingleNode(XML_PATH + "lat").InnerText;
            person.lng = xml.SelectSingleNode(XML_PATH + "lng").InnerText;
        }

    }
}