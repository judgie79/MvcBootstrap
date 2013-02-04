using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MvcBootstrap.Controls
{
	public class Accordion
	{
		public class AccordionItem
		{
			public string Id { get; set; }
			public string Title { get; set; }
			public string HeaderContent { get; set; }
			public string Content { get; set; }

			public bool Active { get; set; }
		}
		
		private string _id;

		private List<AccordionItem> _items = new List<AccordionItem>();

		public Accordion(string id)
		{
			_id = id;
		}

		public Accordion AddItem(string id, bool active, string title, Func<dynamic, HelperResult> template)
		{
			AccordionItem item = new AccordionItem()
			{
				Id = id,
				Content = template(null).ToHtmlString(),
				Title = title,
				HeaderContent = string.Empty,
				Active = active
			};

			_items.Add(item);

			return this;
		}

		public Accordion AddItem(string id, bool active, Func<dynamic, HelperResult> headerTemplate, Func<dynamic, HelperResult> contentTemplate)
		{
			AccordionItem item = new AccordionItem()
			{
				Id = id,
				Content = contentTemplate(null).ToHtmlString(),
				Title = string.Empty,
				HeaderContent = headerTemplate(null).ToHtmlString(),
				Active = active
			};

			_items.Add(item);

			return this;
		}


		public MvcHtmlString Render()
		{
			TagBuilder accordion = new TagBuilder("div");
			accordion.Attributes.Add("id", _id);
			accordion.AddCssClass("accordion");

			foreach (var item in _items)
			{
				TagBuilder accordionGroup = new TagBuilder("div");
				accordionGroup.AddCssClass("accordion-group");

				TagBuilder accordionGroupHeading = new TagBuilder("div");
				accordionGroupHeading.AddCssClass("accordion-heading");

				TagBuilder linkHeading = new TagBuilder("a");

				linkHeading.AddCssClass("accordion-toggle");
				linkHeading.Attributes.Add("data-toggle", "collapse");
				linkHeading.Attributes.Add("data-parent", "#" + _id);
				linkHeading.Attributes.Add("href", "#" + item.Id);

				if (string.IsNullOrWhiteSpace(item.HeaderContent))
				{
					linkHeading.SetInnerText(item.Title);
				}
				else
				{
					linkHeading.InnerHtml = item.HeaderContent;
				}

				TagBuilder accordionBody = new TagBuilder("div");
				accordionBody.AddCssClass("accordion-body collapse");

				if (item.Active)
					accordionBody.AddCssClass("in");

				accordionBody.Attributes.Add("id", item.Id);

				TagBuilder accordionInner = new TagBuilder("div");
				accordionInner.AddCssClass("accordion-inner");
				accordionInner.InnerHtml = item.Content;

				accordionBody.InnerHtml = accordionInner.ToString(TagRenderMode.Normal);
				accordionGroupHeading.InnerHtml = linkHeading.ToString(TagRenderMode.Normal);
				
				accordionGroup.InnerHtml = accordionGroupHeading.ToString(TagRenderMode.Normal);
				accordionGroup.InnerHtml += accordionBody.ToString(TagRenderMode.Normal);


				accordion.InnerHtml += accordionGroup.ToString(TagRenderMode.Normal);
			}

			return new MvcHtmlString(accordion.ToString(TagRenderMode.Normal));
		}
	}
}
