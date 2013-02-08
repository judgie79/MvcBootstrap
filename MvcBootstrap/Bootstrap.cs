using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcBootstrap
{
	public class Bootstrap
	{
		public HtmlHelper Helper { get; private set; }
		
		public Bootstrap(HtmlHelper helper)
		{
			Helper = helper;
		}
	}

	public class Bootstrap<TModel> : Bootstrap
	{
		public Bootstrap(HtmlHelper<TModel> helper)
			: base(helper)
		{
			Helper = helper;
		}

		public new HtmlHelper<TModel> Helper { get; private set; }

		public Bootstrap(HtmlHelper helper)
			: base(helper)
		{

		}
	}

	//public class BootstrapFor<TModel>
	//{
	//    public HtmlHelper<TModel> Helper { get; private set; }

	//    public BootstrapFor(HtmlHelper<TModel> helper)
	//    {
	//        Helper = helper;
	//    }
	//}
}
