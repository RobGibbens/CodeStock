//CodeStock.Core/ViewModels/ConferencesViewModel.cs
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using CodeStock.Core.Models;

namespace CodeStock.Core.ViewModels
{
    //TODO : Create new ViewModel
    public class ConferencesViewModel : MvxViewModel
    {
        public ConferencesViewModel()
        {
            this.Conferences = new List<Conference>();
        }

        public void Init()
        {
        }

        private List<Conference> _conferences;
        public List<Conference> Conferences
        {
            get
            {
                return _conferences;
            }
            set
            {
                _conferences = value;
                RaisePropertyChanged(() => Conferences);
            }
        }
    }
}