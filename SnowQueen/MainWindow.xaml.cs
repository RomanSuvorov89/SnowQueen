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
using SnowQueen.Model;
using SnowQueen.WCFService;

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
			AddButton.IsEnabled = EnabledButton.IsCorrect();
		}

		private void ButtonAddClick(object sender, RoutedEventArgs e)
		{
			var mainModel = new MainModel
			{
				Name = ProductName.Text,
				Price = Convert.ToDouble(PriceProduct.Text),
				Count = Int32.Parse(CountProduct.Text)
			};

			IAddData newData = new AddDataClient();
			newData.Add(mainModel);

			ProductName.Text = "";
			PriceProduct.Text = "";
			CountProduct.Text = "";
		}

		private void ProductName_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			string imgSource;
			if (ProductName.Text == "")
			{
				imgSource = "images/not.png";
				EnabledButton.IsCorrectName = false;
			}
			else
			{
				imgSource = "images/ok.png";
				EnabledButton.IsCorrectName = true;
			}
			ImgPName.Source = new BitmapImage (new Uri(imgSource, UriKind.Relative));
			AddButton.IsEnabled = EnabledButton.IsCorrect();
		}

		private void PriceProduct_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			string imgSource;
			if (PriceProduct.Text == "" || !Double.TryParse(PriceProduct.Text, out double result))
			{
				imgSource = "images/not.png";
				EnabledButton.IsCorrectPrice = false;
			}
			else
			{
				imgSource = "images/ok.png";
				EnabledButton.IsCorrectPrice = true;
			}
			ImgPPrice.Source = new BitmapImage(new Uri(imgSource, UriKind.Relative));
			AddButton.IsEnabled = EnabledButton.IsCorrect();
		}

		private void CountProduct_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			string imgSource;
			if (CountProduct.Text == "" || !Int32.TryParse(CountProduct.Text, out int result))
			{
				imgSource = "images/not.png";
				EnabledButton.IsCorrectCount = false;
			}
			else
			{
				imgSource = "images/ok.png";
				EnabledButton.IsCorrectCount = true;
			}
			ImgPCount.Source = new BitmapImage(new Uri(imgSource, UriKind.Relative));
			AddButton.IsEnabled = EnabledButton.IsCorrect();
		}
	}
}
