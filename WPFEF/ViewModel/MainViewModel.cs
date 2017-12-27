using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WPFEF.Annotations;
using WPFEF.WCFService;

namespace WPFEF.ViewModel
{
	class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
			IShowData data = new ShowDataClient();
			DataViewModel = data.Show();

			TextViewModel = GetDataFromTXT();
		}

		public ObservableCollection<MainModel> TextViewModel { get; set; }
		public ObservableCollection<MainModel> DataViewModel { get; set; }

		private MainModel selecteddata;
		public MainModel SelectedData
		{
			get => selecteddata;
			set
			{
				selecteddata = value;
				OnPropertyChanged("SelectedData");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		private ObservableCollection<MainModel> GetDataFromTXT()
		{
			string currentFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\SnowQueen.txt";
			ObservableCollection<MainModel> textViewModel = new ObservableCollection<MainModel>();
			string[] dataFile = File.ReadAllLines(currentFile);
			foreach (var lineData in dataFile)
			{
				try
				{
					JObject jObject = JObject.Parse(lineData);
					textViewModel.Add(new MainModel
					{
						Name = jObject.Value<string>("Name"),
						Price = jObject.Value<double>("Price"),
						Count = jObject.Value<int>("Count")
				});
				}
				catch
				{
					throw;
				}
			}
			return FindUniqueData(textViewModel);
		}

		private ObservableCollection<MainModel> FindUniqueData(ObservableCollection<MainModel> textViewModel)
		{
			ObservableCollection<MainModel> uniqueDataCollection = new ObservableCollection<MainModel>();
			try
			{
				foreach (var textData in textViewModel)
				{
					var result = DataViewModel.Any(x => x.Name == textData.Name && x.Price == textData.Price &&
					                       x.Count == textData.Count);
					if (!result)
					{
						uniqueDataCollection.Add(textData);
					}

				}
			}
			catch
			{
				
			}
			return uniqueDataCollection;

		}
	}
}