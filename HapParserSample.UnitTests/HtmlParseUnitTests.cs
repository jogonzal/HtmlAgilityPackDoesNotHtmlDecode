using System.IO;
using System.Web;
using FluentAssertions;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HapParserSample.UnitTests
{
	[TestClass]
	public class HtmlParseUnitTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var fileContent = File.ReadAllText("myFile.html");
			HtmlDocument doc = HtmlParse.Parse(fileContent);
			HtmlNodeCollection imgNodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/img[1]");
			imgNodes.Should().HaveCount(1);
			imgNodes[0].Attributes.Should().HaveCount(1);
			var attribute = imgNodes[0].Attributes[0];
			attribute.Name.Should().Be("alt");
			string htmlDecodedValue = HttpUtility.HtmlDecode(attribute.Value);
			htmlDecodedValue.Should().Be("<");
			// attribute.Value.Should().Be("<");

			HtmlNodeCollection pNodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/p[1]");
			pNodes.Should().HaveCount(1);
			var encodedValue = pNodes[0].InnerText;
			var decodedValue  = HttpUtility.HtmlDecode(encodedValue);
			decodedValue.Should().Be("😁");
		}
	}
}
