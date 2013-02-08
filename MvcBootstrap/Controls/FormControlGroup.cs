using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace MvcBootstrap.Controls
{
	public class FormControlGroupFor<TModel, TValue>
	{
		private HtmlHelper<TModel> _helper;

		private TagBuilder _controlGroupBuilder;
		private TagBuilder _controlsBuilder;

		//<div class="control-group">
		//    <label class="control-label" for="inputEmail">Email</label>
		//    <div class="controls">
		//        <input type="text" id="inputEmail" placeholder="Email">
		//    </div>
		//</div>

		public FormControlGroupFor(HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
		{
			_helper = helper;

			_controlGroupBuilder = new TagBuilder("div");
			_controlGroupBuilder.AddCssClass("control-group");

			MvcHtmlString label = LabelExtensions.LabelFor(_helper, expression, new { @class = "control-label" });
			_controlGroupBuilder.InnerHtml += label.ToHtmlString();

			_controlsBuilder = new TagBuilder("div");
			_controlsBuilder.AddCssClass("controls");

			MvcHtmlString editor = EditorExtensions.EditorFor(_helper, expression);

			_controlsBuilder.InnerHtml += editor.ToHtmlString();
		}

		public MvcHtmlString Render()
		{
			_controlGroupBuilder.InnerHtml += _controlsBuilder.ToString(TagRenderMode.Normal);


			return new MvcHtmlString(_controlGroupBuilder.ToString(TagRenderMode.Normal));
		}

	}
}
