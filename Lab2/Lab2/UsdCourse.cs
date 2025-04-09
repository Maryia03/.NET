using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class UsdCourse
    {
        public static decimal Current = 0;
        public async static Task<decimal> GetUsdCourseAsync()
        {
            var wc = new HttpClient();
            var response = await wc.GetAsync("http://www.nbp.pl/kursy/xml/LastA.xml");
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.LoadXml(await response.Content.ReadAsStringAsync());
            foreach (System.Xml.XmlNode p in xd.GetElementsByTagName("pozycja"))
            {
                if (p.NodeType == System.Xml.XmlNodeType.Element)
                {
                    System.Xml.XmlElement pp = (System.Xml.XmlElement)p;
                    System.Xml.XmlElement w = (System.Xml.XmlElement)pp.GetElementsByTagName("kod_waluty")[0];
                    if (w != null && w.InnerText == "USD")
                    {
                        if (decimal.TryParse(pp.GetElementsByTagName("kurs_sredni")[0].InnerText, out decimal num))
                            return num;
                        else
                            return 1;
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
