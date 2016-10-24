using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Facebook;
using GlobanetTest.FacebookApi;
using GlobanetTest.FacebookApi.Model;

namespace GlobanetTest.App
{
    class Program
    {
        private static string clientId = "1649782095313979";
        private static string clientSecret = "b07f23c5fdcb125df2657084b37d28df";
        private static string pageId = "695941003897570";
        private static string filename = "comments.xml";

        static void Main(string[] args)
        {
            CollectAndSaveData(clientId, clientSecret, pageId, filename).Wait();
            //program.CollectAndSaveData(args[0], args[1], args[2], args[3]).Wait();
        }

        private static async Task CollectAndSaveData(string clientId , string clientSecret, string pageId, string filename)
        {
            var connector = new FacebookConnector(clientId, clientSecret);
            var postList = await connector.GetPostsByPageIdAsync(pageId);
            var posts = postList.Data;
            if (!posts.Any())
            {
                return;
            }

            var comments = await connector.GetCommentsByPostIdAsync(posts[0].Id);
            SaveAsXml(comments, filename);
        }

        private static void SaveAsXml<T>(T data, string filename)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using(var fileStream = File.Create(filename))
            using (var xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings {Indent = true}))
            {
                xmlSerializer.Serialize(xmlWriter, data);
            }
        }
    }
}
