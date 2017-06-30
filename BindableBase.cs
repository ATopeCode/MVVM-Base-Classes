using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utils
{
	public class BindableBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public BindableBase ()
		{
		}

		public bool SetProperty<T>(ref T propertyBackStore, T newValue, [CallerMemberName] string propertyName = "")
		{
			if (Equals(propertyBackStore, newValue))
				return false;

			propertyBackStore = newValue;
			if (PropertyChanged != null)
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName)
				);

			return true;
		}
	}
}
