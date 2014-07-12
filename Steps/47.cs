//CodeStock.iOS/Views/ConferenceView.cs
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using CodeStock.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace CodeStock.iOS.Views
{
    //TODO : Create conference view
    [Register("ConferenceView")]
    public class ConferenceView : MvxTableViewController
    {
        public static readonly NSString CellIdentifier = new NSString("SessionListCell");
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View = new UIView() { BackgroundColor = UIColor.White };

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            TableView = new UITableView(UIScreen.MainScreen.Bounds);
            var source = new MvxStandardTableViewSource(
                TableView,
                UITableViewCellStyle.Subtitle,
                CellIdentifier,
                "TitleText Title; DetailText Start"
            );

            TableView.Source = source;

            var set = this.CreateBindingSet<ConferenceView, ConferenceViewModel>();
            set.Bind(source).To(vm => vm.Sessions);
            set.Apply();

            TableView.ReloadData();
        }
    }
}