using System.ComponentModel;

namespace Crc32WpfApplication.ViewModels {

    public class BaseViewModel : INotifyPropertyChanged {

        /// <inheritdoc />
        /// <summary>
        /// Событие для обработчика изменения свойства 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Подпрограмма обработчик изменения свойства 
        /// </summary>
        /// <param name="propertyName"></param>
        /// ReSharper disable once VirtualMemberNeverOverridden.Global
        protected virtual void OnPropertyChanged( string propertyName = "" ) =>
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );

        /// <summary>
        /// Подпрограмма обработчик изменения свойства 
        /// </summary>
        /// <param name="e"></param>
        /// ReSharper disable once VirtualMemberNeverOverridden.Global
        protected virtual void OnPropertyChanged( PropertyChangedEventArgs e ) => PropertyChanged?.Invoke( this, e );
    }
}