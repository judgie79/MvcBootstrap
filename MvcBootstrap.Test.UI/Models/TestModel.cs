using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBootstrap.Test.UI.Models
{
	public class TestModel
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Name { get; set; }
	}
}