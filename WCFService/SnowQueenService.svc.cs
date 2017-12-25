using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFService.Model;

namespace WCFService
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "SnowQueenService" в коде, SVC-файле и файле конфигурации.
	// ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы SnowQueenService.svc или SnowQueenService.svc.cs в обозревателе решений и начните отладку.
	public class AddRecord : ISnowQueenService
	{

		public void Add(MainModel mainModel)
		{
			
		}


		public List<MainModel> Show()
		{
			return null;
		}
	}
}
