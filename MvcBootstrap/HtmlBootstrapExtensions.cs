﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcBootstrap.Controls;

namespace MvcBootstrap
{
	/// <summary>
	/// Extension class for encapsulation all bootstrap helpers (@Html.Bootstrap().*)
	/// and adding the helpers to the Bootstrap class
	/// </summary>
	public static class HtmlBootstrapExtensions
	{
		/// <summary>
		/// Encapsulating all bootstrap helpers (@Html.Bootstrap().*)
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <returns></returns>
		public static Bootstrap Bootstrap(this HtmlHelper htmlHelper)
		{
			return new Bootstrap();
		}

		/// <summary>
		/// Adds the Modal extension to the Bootstrap class
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Modal Modal(this Bootstrap htmlHelper, string id)
		{
			return new Modal(id);
		}

		/// <summary>
		/// Adds the Modal extension to the Bootstrap class
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <param name="id"></param>
		/// <param name="title"></param>
		/// <param name="closeBtnTitle"></param>
		/// <param name="saveBtnTitle"></param>
		/// <returns></returns>
		public static Modal Modal(this Bootstrap htmlHelper, string id, string title, string closeBtnTitle, string saveBtnTitle)
		{
			return new Modal(id, title, closeBtnTitle, saveBtnTitle);
		}
	}
}