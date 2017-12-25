using System;
using System.Collections.Generic;
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
		public List<MainModel> Show()
		{
			return null;
		}
		public void Add(MainModel mainModel)
		{
			if (mainModel != null)
				using (var db = new SnowQueen())
				{
					var product = db.Products.SingleOrDefault(x => x.productName == mainModel.name);
					if (product != null)
					{
						var order = new Orders
						{
							priceOfProduct = Convert.ToDecimal(mainModel.price),
							countOfProduct = mainModel.count,
							id_product = product.id
						};
						db.Orders.Add(order);
					}
					else
					{
						var newProduct = new Products
						{
							productName = mainModel.name
						};
					}
					db.SaveChanges();
				}
		}
	}
}
