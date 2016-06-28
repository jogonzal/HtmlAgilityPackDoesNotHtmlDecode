using HtmlAgilityPack;

namespace HapParserSample
{
	public class HtmlParse
	{
		public static HtmlDocument Parse(string html)
		{
			var doc = new HtmlDocument()
			{
			};
			doc.LoadHtml(html);
			return doc;
		}
	}
}
