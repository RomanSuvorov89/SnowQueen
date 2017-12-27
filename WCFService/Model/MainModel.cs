using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WCFService.Model
{
	public class MainModel : INotifyPropertyChanged
	{
		private string name;
		private double price;
		private int count;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public double Price
		{
			get { return price; }
			set
			{
				price = value;
				OnPropertyChanged("Price");
			}
		}
		public int Count
		{
			get { return count; }
			set
			{
				count = value;
				OnPropertyChanged("Count");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null) 
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}