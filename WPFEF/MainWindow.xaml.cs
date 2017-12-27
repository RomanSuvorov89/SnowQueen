using System;
using System.Collections.Generic;
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
using WPFEF.ViewModel;
using WPFEF.WCFService;

namespace WPFEF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainViewModel();
		}

		private void AddButton(object sender, RoutedEventArgs e)
		{
			var selectedData = ((Button)sender).Tag;
			var mainModel = selectedData as MainModel;
			IAddData newData = new AddDataClient();
			newData.Add(mainModel);
			ReloadWindow();
		}

		private void ReloadWindow()
		{
			DataContext = new MainViewModel();
		}
	}
}
