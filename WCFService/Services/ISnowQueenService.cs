using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFService.Model;

namespace WCFService.Services
{
	[ServiceContract]
	public interface IShowData
	{
		[OperationContract]
		ObservableCollection<MainModel> Show();
	}
	[ServiceContract]
	public interface IAddData
	{
		[OperationContract]
		void Add(MainModel mainModel);
	}
}
