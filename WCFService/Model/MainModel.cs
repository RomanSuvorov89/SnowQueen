using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFService.Model
{
	public class MainModel
	{
		private string Name { get; set; }
		private double Price { get; set; }
		private int Count { get; set; }

		public string name
		{
			get => Name;
			set => Name = value;
		}
		public double price
		{
			get => Price;
			set => Price = value;
		}
		public int count
		{
			get => Count;
			set => Count = value;
		}
	}
}