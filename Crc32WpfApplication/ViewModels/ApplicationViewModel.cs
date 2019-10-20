using System;
using System.Threading;
using Crc32WpfApplication.Models;

namespace Crc32WpfApplication.ViewModels {

    /// <summary>
    /// Класс ViewModel главной формы
    /// </summary>
    public class ApplicationViewModel : BaseViewModel {
        /// <summary>
        /// 
        /// </summary>
        private readonly SemaphoreSlim _semafor = new SemaphoreSlim( 1, 1 );

        /// <summary>
        /// Текущая контрольная сумма
        /// </summary>
        private string _currentChecksum;

        public string CurrentChecksum {
            get { return _currentChecksum; }
            set {
                _currentChecksum = value;
                OnPropertyChanged( nameof( CurrentChecksum ) );
            }
        }

        /// <summary>
        /// Требуемая контрольная сумма
        /// </summary>
        private string _requiredChecksum;

        public string RequiredChecksum {
            get { return _requiredChecksum; }
            set {
                _requiredChecksum = value;
                OnPropertyChanged( nameof( RequiredChecksum ) );
            }
        }

        /// <summary>
        /// Крайнее значение
        /// </summary>
        private string _lastValue;

        public string LastValue {
            get { return _lastValue; }
            set {
                _lastValue = value;
                OnPropertyChanged( nameof( LastValue ) );
            }
        }

        /// <summary>
        /// Таблица
        /// </summary>
        private string _tableValue;

        public string TableValue {
            get { return _tableValue; }
            set {
                _semafor.Wait();
                _tableValue = value;
                OnPropertyChanged( nameof( TableValue ) );
                _semafor.Release();
            }
        }

        public string TableValueLine {
            get { return _tableValue; }
            set {
                _semafor.Wait();
                _tableValue = value + Environment.NewLine;
                OnPropertyChanged( nameof( TableValue ) );
                _semafor.Release();
            }
        }

        /// <summary>
        /// Команда запуска 
        /// </summary>
        private RelayCommand _startCommand;
        
        public RelayCommand StartCommand {
            get {
                // ReSharper disable once ArrangeAccessorOwnerBody
                return _startCommand ?? ( _startCommand = new RelayCommand( TaskClass.Start ) );
            }
        }

        public ApplicationViewModel() {}

        public ApplicationViewModel( string current, string required, string value,string table) {
            _currentChecksum = current;
            _requiredChecksum = required;
            _lastValue = value;
            _tableValue = table;
        }
    }
}