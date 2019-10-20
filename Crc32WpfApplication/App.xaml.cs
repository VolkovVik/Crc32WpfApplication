using System.Windows;
using Crc32WpfApplication.ViewModels;

namespace Crc32WpfApplication {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        /// <summary>
        /// Данные для привязки элементов
        /// </summary>
        public static readonly ApplicationViewModel MyWindows =
            new ApplicationViewModel( "0x00000000", "0x00000000", "0xFFFFFFFF", "" );
    }
}
