//CodeStock.Store/Setup.cs
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Platform;
using Windows.UI.Xaml.Controls;
using CodeStock.Core.Data;
using CodeStock.Store.Data;

namespace CodeStock.Store
{
    public class Setup : MvxStoreSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            //TODO : Register interface implementation with IoC
            Mvx.RegisterType<ISQLitePlatform, SQLiteWinRTPlatform>();

            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}