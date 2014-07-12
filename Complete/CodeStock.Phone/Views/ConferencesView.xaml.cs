using System.Windows.Controls;
using Cirrious.MvvmCross.WindowsPhone.Views;
using CodeStock.Core.Models;
using CodeStock.Core.ViewModels;

namespace CodeStock.Phone.Views
{
    public partial class ConferencesView : MvxPhonePage
    {
        public ConferencesView()
        {
            InitializeComponent();
        }

        private void ConferencesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (ConferencesViewModel) this.ViewModel;
            var conference = this.ConferencesList.SelectedItem as Conference;
            viewModel.ShowConferenceCommand.Execute(conference);
        }
    }
}