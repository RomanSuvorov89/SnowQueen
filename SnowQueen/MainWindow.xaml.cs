using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SnowQueen.SnowQueenService;

namespace SnowQueen
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonAddClick(object sender, RoutedEventArgs e)
		{
			var mainModel = new MainModel
			{
				name = ProductName.Text,
				price = Convert.ToDouble(PriceProduct.Text),
				count = Int32.Parse(CountProduct.Text)
			};
			IAddData newData = new AddDataClient();
			newData.Add(mainModel);
		}
	}
}
