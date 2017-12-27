using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFService.Model;
using WCFService.EFSnowQueen;

namespace WCFService.Services
{
	public class SnowQueenService : IShowData, IAddData
	{
		public ObservableCollection<MainModel> Show()
		{
			var dataDb = new ObservableCollection<MainModel>();
			try
			{
				using (var db = new SnowQueen())
				{
					foreach (var order in db.Orders)
					{
						var model = new MainModel
						{
							Name = order.Products.productName,
							Count = order.countOfProduct.GetValueOrDefault(0),
							Price = Convert.ToDouble(order.priceOfProduct.GetValueOrDefault(0))
						};
						dataDb.Add(model);
					}
				}
			}
			catch
			{
				// ignored
			}
			return dataDb;
		}
		public void Add(MainModel mainModel)
		{
			try
			{
				if (mainModel == null) return;
				using (var db = new SnowQueen())
				{
					var order = new Orders
					{
						priceOfProduct = Convert.ToDecimal(mainModel.Price),
						countOfProduct = mainModel.Count,
						id_product = GetProductId(mainModel.Name)
					};
					db.Orders.Add(order);
					db.SaveChanges();
				}
			}
			catch
			{
				//ignored
			}

		}

		private static int GetProductId(string productName)
		{
			using (var db = new SnowQueen())
			{
				if (db.Products.SingleOrDefault(x => x.productName == productName) == null)
				{
					var newProduct = new Products
					{
						productName = productName
					};
					db.Products.Add(newProduct);
					db.SaveChanges();
				}
				return db.Products.Single(x => x.productName == productName).id;
			}
		}
	}
}
