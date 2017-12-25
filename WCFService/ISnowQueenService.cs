using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFService.Model;

namespace WCFService
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ISnowQueenService" в коде и файле конфигурации.
	[ServiceContract]
	public interface ISnowQueenService
	{
		[OperationContract]
		void Add(MainModel mainModel);

		[OperationContract]
		List<MainModel> Show();
	}
}
