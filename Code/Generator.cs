using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebsiteUpdater.Code {
    public static class Generator {

        // //*[@id="idname"]/code
        // //*[@id="head"]
        //ToDo: make sure that it is actually the code tag

        internal static readonly HtmlDocument Document = new();
        private static readonly string HeadString = new StreamReader($"{Reference.WebsiteDirectory}/{Reference.HeadPart}").ReadToEnd();
        private static readonly string NavigationString = new StreamReader($"{Reference.WebsiteDirectory}/{Reference.NavigationPart}").ReadToEnd();
        private static readonly string FooterString = new StreamReader($"{Reference.WebsiteDirectory}/{Reference.FooterPart}").ReadToEnd();
        private static readonly string ScriptsString = new StreamReader($"{Reference.WebsiteDirectory}/{Reference.ScriptsPart}").ReadToEnd();

        internal static void Load() => Document.Load(new StreamReader($"{Reference.WebsiteDirectory}/{Reference.MainTemplate}"));

        internal static void Generate() {
            HtmlNode? Head = Document.DocumentNode.SelectSingleNode("//*[@id=\"head\"]");
            HtmlNode? Navigation = Document.DocumentNode.SelectSingleNode("//*[@id=\"navigation\"]");
            HtmlNode? Footer = Document.DocumentNode.SelectSingleNode("//*[@id=\"footer\"]");
            HtmlNode? Scripts = Document.DocumentNode.SelectSingleNode("//*[@id=\"scripts\"]");
            HtmlNodeCollection? Content = Document.DocumentNode.SelectNodes("//*[@id=\"content\"]");

            Head.ReplaceNode(HeadString, Document);
            Navigation.ReplaceNode(NavigationString, Document);
            Footer.ReplaceNode(FooterString, Document);
            Scripts.ReplaceNode(ScriptsString, Document);

            foreach (HtmlNode htmlNode in Content) {
                htmlNode.ReplaceNode(new StreamReader($"{Reference.WebsiteDirectory}/{htmlNode.InnerHtml}.html").ReadToEnd(), Document);
            }
            
            Document.Save(new StreamWriter($"{Reference.WebsiteDirectory}/out.html"));
        }

        internal static void Generate(HtmlDocument htmlDocument, string element, string newNode) {
            HtmlNodeCollection? elementNodes = htmlDocument.DocumentNode.SelectNodes("//*[@id=\"element\"]");
            foreach (HtmlNode node in elementNodes) {
                if (node.InnerHtml == element) {
                    node.ReplaceNode(newNode, htmlDocument);
                }
            }
            htmlDocument.Save(new StreamWriter($"{Reference.WebsiteDirectory}/out2.html"));
        }

        internal static void ReplaceNode(this HtmlNode oldNode, string newNode, HtmlDocument htmlDocument) {
            HtmlNode? tempNode = htmlDocument.CreateElement("temp");
            tempNode.InnerHtml = newNode;
            HtmlNode? currentNode = oldNode;
            foreach (HtmlNode tempChildNode in tempNode.ChildNodes) {
                oldNode.ParentNode.InsertAfter(tempChildNode, currentNode);
                currentNode = tempChildNode;
            }
            oldNode.Remove();
        }

    }
}
