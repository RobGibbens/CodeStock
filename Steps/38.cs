//CodeStock.Phone/Setup.cs
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using CodeStock.Core.Data;
using CodeStock.Phone.Data;
using Microsoft.Phone.Controls;

namespace CodeStock.Phone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            //TODO : Register interface implementation with IoC
            Mvx.RegisterType<ISQLitePlatform, SQLiteWP8Platform>();
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}