//CodeStock.Core/ViewModels/ConferencesViewModel.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using CodeStock.Core.Models;

namespace CodeStock.Core.ViewModels
{
    public class ConferencesViewModel : MvxViewModel
    {
        //TODO : Inject service
        private readonly ITekConfService _tekConfService;
        public ConferencesViewModel(ITekConfService tekConfService)
        {
            _tekConfService = tekConfService;
            this.Conferences = new List<Conference>();
        }

        public async void Init()
        {
            //TODO : Get conferences
            await GetConferences();
        }

        //TODO : Get conferences using service, set VM property
        public async Task GetConferences()
        {
            var conferences = await _tekConfService.GetConferences().ConfigureAwait(false);
            this.Conferences = conferences;
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