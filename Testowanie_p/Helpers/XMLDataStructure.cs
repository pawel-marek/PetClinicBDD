using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using NUnit.Framework;


namespace PetClinic.Helpers
{
    public abstract class BaseParser
    {
        protected string GetPathToFile(string fileName)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            string path = Path.GetDirectoryName(ass.Location);

            return Path.Combine(path, fileName);         
        }
    }


    public class XmListStructure : BaseParser
    {
        private string fileName = @"TestConfiguration\TestData.xml";

        public  List<string> ParseXml(string selector)
        {
            var xmlDoc = new XPathDocument(GetPathToFile(fileName));
            var xmlNavigator = xmlDoc.CreateNavigator();

            var results = ParseItem(xmlNavigator.Select(selector));
            return results;
        }

        private List<string> ParseItem(XPathNodeIterator navigator)
        {
            var results = new List<string>();

            while (navigator.MoveNext())
            {
                var current = navigator.Current;
                if (current == null)
                    continue;

                if (current.Name == "Value")
                {
                    results.Add(current.InnerXml);
                }             
            }
            return results;
        }

    }

    public class XmUrlsStructure : BaseParser
    {
        private string fileName = @"TestConfiguration\UrlsData.xml";

         public string ParseXml(string selector)
        {
            var xmlDoc = new XPathDocument(GetPathToFile(fileName));
            var xmlNavigator = xmlDoc.CreateNavigator();

            string results = ParseItem(xmlNavigator.Select(selector));

            return results;
        }

        private string ParseItem(XPathNodeIterator navigator)
        {
            string result = null;

            while (navigator.MoveNext())
            {
                var current = navigator.Current;
                if (current == null)
                    continue;

                if (current.Name == "Value")
                {
                    result = current.InnerXml;
                }
            }
            return result;
        }


    }

}
