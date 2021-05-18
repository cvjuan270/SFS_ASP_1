using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
namespace SFS_ASP_1.Controllers.Helper
{
    public class LeeCdr
    {
        public static string[] GetCdr(string oRutCdrZip, string oRutCdrxml, string oRutRPTA)
        {
            
            string[] ReturnCdr = new string[3];

            if (!File.Exists(oRutCdrxml))
            {
               ZipFile.ExtractToDirectory(oRutCdrZip, oRutRPTA);
            }

            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(oRutCdrxml);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("cbc:ResponseCode");
            XmlNodeList elemList1 = doc.GetElementsByTagName("cbc:Description");
            XmlNodeList elemList2 = doc.GetElementsByTagName("DigestValue");
            ReturnCdr[0] = elemList[0].InnerXml;
            ReturnCdr[1] = elemList1[0].InnerXml;
            ReturnCdr[2] = elemList2[0].InnerXml;
            return ReturnCdr;
        }
        public static string GetXml(string oRutXml)
        {
            string ReturnCdr;
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(oRutXml);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("ds:DigestValue");
            ReturnCdr = elemList[0].InnerXml;
            return ReturnCdr;
        }
    }
}