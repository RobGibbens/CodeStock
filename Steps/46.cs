//CodeStock.Droid/Views/ConferenceView.cs
using Android.App;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;

namespace CodeStock.Droid.Views
{
    //TODO : Create conference view
    [Activity(Label = "Conference")]
    public class ConferenceView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.ActionBar);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ConferenceView);
        }
    }
}