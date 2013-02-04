using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages;
using System.Web.Mvc;

namespace MvcBootstrap.Controls
{
	

	public class Tab
	{
		public class TabContent
		{
			public const string DEFAULT_CSS_CLASSES = "tab-pane";

			public string CssClass { get; set; }

			public string Title { get; set; }

			public string Id { get; set; }

			public string Content { get; set; }

			public bool IsActive { get; set; }

			public string NavContent { get; set; }
		}
		
		private const string DEFAULT_UL_NAV_CSS_CLASSES = @"nav nav-tabs";
		private const string DEFAULT_TAB_CONTENT_CONTAINER_CSS_CLASSES = @"tab-content";
		
		private List<TabContent> _items = new List<TabContent>();
		
		private string _ulNavCssClasses;
		private string _tabContentContainerCssClasses;

		private string _id;

		public Tab (string id)
		{
			_id = id;
			_ulNavCssClasses = DEFAULT_UL_NAV_CSS_CLASSES;
			_tabContentContainerCssClasses = DEFAULT_TAB_CONTENT_CONTAINER_CSS_CLASSES;
		}

		public Tab (string id, string ulNavCssClasses)
		{
			_id = id;
			_ulNavCssClasses = ulNavCssClasses;
			_tabContentContainerCssClasses = DEFAULT_TAB_CONTENT_CONTAINER_CSS_CLASSES;
		}

		public Tab AddTab(string id, string title, string cssClass, bool isActive, Func<dynamic, HelperResult> template)
		{
			var newTab = new TabContent()
				{
					Id = id,
					Title = title,
					CssClass = string.IsNullOrWhiteSpace(cssClass) ? TabContent.DEFAULT_CSS_CLASSES : TabContent.DEFAULT_CSS_CLASSES + " " + cssClass,
					Content = template(null).ToHtmlString(),
					IsActive = isActive,
					NavContent = string.Empty
				};

			
			_items.Add(newTab);

			return this;
		}

		public Tab AddTab(string id, string cssClass, bool isActive, Func<dynamic, HelperResult> navTemplate, Func<dynamic, HelperResult> contentTemplate)
		{
			var newTab = new TabContent()
			{
				Id = id,
				CssClass = string.IsNullOrWhiteSpace(cssClass) ? TabContent.DEFAULT_CSS_CLASSES : TabContent.DEFAULT_CSS_CLASSES + " " + cssClass,
				Content = contentTemplate(null).ToHtmlString(),
				IsActive = isActive,
				NavContent = navTemplate(null).ToHtmlString(),
			};


			_items.Add(newTab);

			return this;
		}

		public MvcHtmlString Render()
		{
			TagBuilder ulBuilder = new TagBuilder("ul");
			ulBuilder.AddCssClass(_ulNavCssClasses);
			ulBuilder.Attributes.Add("id", _id);

			TagBuilder tabContentContainerBuilder = new TagBuilder("div");
			tabContentContainerBuilder.AddCssClass(_tabContentContainerCssClasses);

			foreach (var tabContent in _items)
			{
				TagBuilder li = new TagBuilder("li");

				if (tabContent.IsActive)
				{
					li.AddCssClass("active");
				}

				TagBuilder a = new TagBuilder("a");
				a.Attributes.Add("href", "#" + tabContent.Id);
				a.Attributes.Add("data-toggle", "tab");

				if (string.IsNullOrWhiteSpace(tabContent.NavContent))
					a.SetInnerText(tabContent.Title);
				else
					a.InnerHtml = tabContent.NavContent;

				li.InnerHtml = a.ToString(TagRenderMode.Normal);
				
				ulBuilder.InnerHtml += li.ToString(TagRenderMode.Normal);

				TagBuilder tabContentBuilder = new TagBuilder("div");
				if (tabContent.IsActive)
				{
					tabContentBuilder.AddCssClass("active");
				}
				tabContentBuilder.AddCssClass(tabContent.CssClass);

				tabContentBuilder.Attributes.Add("id", tabContent.Id);
				tabContentBuilder.InnerHtml = tabContent.Content;

				tabContentContainerBuilder.InnerHtml += tabContentBuilder.ToString(TagRenderMode.Normal);
			}

			return new MvcHtmlString(ulBuilder.ToString(TagRenderMode.Normal) + tabContentContainerBuilder.ToString(TagRenderMode.Normal));
		}
	}
	
}
