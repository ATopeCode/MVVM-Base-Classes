using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utils
{
	public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Evento de la interfaz 'INotifyPropertyChanged' al que se suscribe automáticamente el motor XAML de Xamarin
        /// el evento correspondiente para realizar Binding entre esta ViewModel y su Vista asociada.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Este método realiza Binding desde la 'ViewModel' hacia la 'Vista' para la Propiedad cuyo nombre se indica como parámetro
        /// o en su defecto desde la cual se llama a este método (gracias al atributo [CallerMemberName]).
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad de la ViewModel con la que se desea hacer Binding hacia la View.
        /// En caso de no recibir valor se asigna el nombre del método/propiedad desde el
        /// cual se llama a este método.</</param>
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Este método realiza Binding desde la 'ViewModel' hacia la 'Vista' para la Propiedad cuyo nombre se indica como parámetro
        /// o en su defecto desde la cual se llama a este método (gracias al atributo [CallerMemberName]).
        /// Además asigna el nuevo valor al campo 'private' de la propiedad de la ViewModel con la que se quiere hacer Binding.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato de la propiedad de la ViewModel con la que se quiere hacer Binding.</typeparam>
        /// <param name="propertyBackStore">Parámetro que pasa por referencia el campo 'private' de la propiedad de la ViewModel con la que se quiere hacer Binding.</param>
        /// <param name="newValue">Valor que se le asigna a la propiedad de la ViewModel con la que se quiere hacer Binding.</param>
        /// <param name="propertyName">Nombre de la propiedad de la ViewModel con la que se desea hacer Binding. En caso de no recibir valor se asigna el nombre del método/propiedad desde el
        /// cual se llama a este método.</param>
        /// <returns></returns>
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
