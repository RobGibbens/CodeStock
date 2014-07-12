//CodeStock.Core/App.cs
using Cirrious.CrossCore.IoC;
using CodeStock.Core.ViewModels;

namespace CodeStock.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            //TODO : Initialize Automapper
            var bootstrapper = new Bootstrapper();
            bootstrapper.Automapper();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ConferencesViewModel>();
        }
    }
}                

                