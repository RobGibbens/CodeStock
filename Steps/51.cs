//CodeStock.iOS/Views/ConferencesView.cs
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using CodeStock.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace CodeStock.iOS.Views
{
    [Register("ConferencesView")]
    public class ConferencesView : MvxTableViewController
    {
        public static readonly NSString CellIdentifier = new NSString("ConferenceCell");
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Title = "Conferences";

            View = new UIView(UIScreen.MainScreen.Bounds) { BackgroundColor = UIColor.White };

            TableView = new UITableView(UIScreen.MainScreen.Bounds);

            var source = new MvxStandardTableViewSource(
                TableView,
                UITableViewCellStyle.Subtitle,
                CellIdentifier,
                "TitleText Name; DetailText Start",
                UITableViewCellAccessory.DisclosureIndicator
            );

            TableView.Source = source;

            var set = this.CreateBindingSet<ConferencesView, ConferencesViewModel>();
            set.Bind(source).To(vm => vm.Conferences);
            //TODO : Add SelectionChangedCommand binding
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowConferenceCommand);
            set.Apply();

            TableView.ReloadData();
        }


        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 0))
            {
                this.TableView.ContentInset = new UIEdgeInsets(this.TopLayoutGuide.Length, 0, 0, 0);
            }
        }
    }
}