//CodeStock.Core/App.cs
using Cirrious.CrossCore.IoC;
using CodeStock.Core.ViewModels;

namespace CodeStock.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            //TODO : Register new ViewModel to be first screen
            RegisterAppStart<ConferencesViewModel>();
        }
    }
}