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
			var doc = HtmlParse.Parse(fileContent);
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/img[1]");
			nodes.Should().HaveCount(1);
			nodes[0].Attributes.Should().HaveCount(1);
			var attribute = nodes[0].Attributes[0];
			attribute.Name.Should().Be("alt");
			string htmlDecodedValue = HttpUtility.HtmlDecode(attribute.Value);
			htmlDecodedValue.Should().Be("&");
			attribute.Value.Should().Be("&");
		}
	}
}
