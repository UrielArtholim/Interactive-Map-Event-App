using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Event_App.ViewModels.Base
{
	public class BaseViewModel: INotifyPropertyChanged, INotifyCollectionChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		public event NotifyCollectionChangedEventHandler? CollectionChanged;

		private bool _isBusy;
		private string? _title;
		protected bool initialized;

		public bool IsBusy
		{
			get => this._isBusy;
			set => this.SetProperty(ref this._isBusy, value);
		}

		public string Title
		{
			get => this._title;
			set => this.SetProperty(ref this._title, value);
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			MainThread.BeginInvokeOnMainThread(() => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
		}

		protected virtual void OnCollectionChanged()
		{
			MainThread.BeginInvokeOnMainThread(() => this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace)));
		}

		protected void RefreshCollection()
		{
			this.OnCollectionChanged();
		}


		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}

	}
}
