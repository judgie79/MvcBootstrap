using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MvcBootstrap.Controls
{
	public class Modal
	{
		private const string MODAL_DEFAULT_LAYOUT = @"
		<div id=""{0}"" class=""modal hide fade"">
			{1}
			{2}
			{3}
		</div>
		";
		
		private const string MODAL_DEFAULT_HEADER = @"
		<div class=""modal-header"">
			<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
			<h3>{0}</h3>
			{1}
		</div>";

		private const string MODAL_DEFAULT_CONTENT = @"
		<div class=""modal-body"">
			{0}
		</div>
		";

		private const string MODAL_DEFAULT_FOOTER = @"
		<div class=""modal-footer"">
			{0}
			<a href=""#"" class=""btn"">{1}</a>
			<a href=""#"" class=""btn btn-primary"">{2}</a>
		</div>
		";

		private string _layoutTemplate = string.Empty;
		private string _headerTemplate = string.Empty;
		private string _contentTemplate = string.Empty;
		private string _footerTemplate = string.Empty;

		private string _content = string.Empty;
		private string _header = string.Empty;
		private string _footer = string.Empty;

		private string _title = string.Empty;
		private string _closeBtnTitle = string.Empty;
		private string _saveBtnTitle = string.Empty;

		private string _id = string.Empty;


		public Modal(string id)
		{
			_id = id;
		}

		public Modal(string id, string title, string closeBtnTitle, string saveBtnTitle)
		{
			_id = id;
			_title = title;
			_closeBtnTitle = closeBtnTitle;
			_saveBtnTitle = saveBtnTitle;
		}

		public Modal LayoutTemplate(Func<dynamic, HelperResult> template)
		{
			_layoutTemplate = template(null).ToHtmlString();
			return this;
		}

		public Modal HeaderTemplate(Func<dynamic, HelperResult> template)
		{
			_headerTemplate = template(null).ToHtmlString();
			return this;
		}

		public Modal ContentTemplate(Func<dynamic, HelperResult> template)
		{
			_contentTemplate = template(null).ToHtmlString();
			return this;
		}

		public Modal FooterTemplate(Func<dynamic, HelperResult> template)
		{
			_footerTemplate = template(null).ToHtmlString();
			return this;
		}


		public Modal Content(Func<dynamic, HelperResult> template)
		{
			_content = template(null).ToHtmlString();
			return this;
		}

		public Modal Header(Func<dynamic, HelperResult> template)
		{
			_header = template(null).ToHtmlString();
			return this;
		}

		public Modal Footer(Func<dynamic, HelperResult> template)
		{
			_footer = template(null).ToHtmlString();
			return this;
		}

		public MvcHtmlString Render()
		{
			if (string.IsNullOrWhiteSpace(_headerTemplate))
			{
				_headerTemplate = string.Format(MODAL_DEFAULT_HEADER, _title, _header);
			}

			if (string.IsNullOrWhiteSpace(_contentTemplate))
			{
				_contentTemplate = string.Format(MODAL_DEFAULT_CONTENT, _content);
			}

			if (string.IsNullOrWhiteSpace(_footerTemplate))
			{
				_footerTemplate = string.Format(MODAL_DEFAULT_FOOTER, _footer, _closeBtnTitle, _saveBtnTitle);
			}

			if (string.IsNullOrWhiteSpace(_layoutTemplate))
			{
				_layoutTemplate = string.Format(MODAL_DEFAULT_LAYOUT, _id, _headerTemplate, _contentTemplate, _footerTemplate);
			}

			return new MvcHtmlString(_layoutTemplate);
		}
	}

}
