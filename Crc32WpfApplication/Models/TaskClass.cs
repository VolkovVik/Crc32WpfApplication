using System;
using System.Threading.Tasks;

namespace Crc32WpfApplication.Models {
    internal static class TaskClass {

        /// <summary>
        /// 
        /// </summary>
        //public static async void StartAsync( object obj ) => await Task.Run( () => SelectCrc32() );

        /// <summary>
        /// 
        /// </summary>
        public static void Start( object obj ) => new Task( SelectCrc32 ).Start();

        /// <summary>
        /// 
        /// </summary>
        private static void SelectCrc32() {
            var crc32 = new Crc32Class();

            App.MyWindows.TableValue = string.Empty;

            var current    = Convert.ToUInt32( App.MyWindows.CurrentChecksum, 16 );
            var required   = Convert.ToUInt32( App.MyWindows.RequiredChecksum, 16 );
            var last_value = Crc32Class.ToBytes( Convert.ToUInt32( App.MyWindows.LastValue, 16 ) );

            current  ^= 0xFFFFFFFF;
            required ^= 0xFFFFFFFF;

            var previous        = crc32.UpChecksum( last_value, last_value.Length, current );
            var new_value       = crc32.Select( previous, required );
            var update_required = crc32.Checksum( new_value, new_value.Length, previous );

            App.MyWindows.RequiredChecksum = $"0x{update_required:X8}";
            App.MyWindows.LastValue        = $"0x{Crc32Class.ToUint( new_value )[ 0 ]:X8}";

            foreach ( var item in crc32.Table ) App.MyWindows.TableValue += $"0x{item:X8}, ";
        }
    }
}
