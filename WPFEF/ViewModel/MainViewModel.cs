using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
		}
		private MainModel selecteddata;
		//private ObservableCollection<MainModel> dataViewModel;
		public ObservableCollection<MainModel> DataViewModel { get; set; }

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
	}
}